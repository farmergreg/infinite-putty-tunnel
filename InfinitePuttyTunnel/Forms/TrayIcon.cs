/**
 * Copyright (c) 2009, Joeri Bekker
 * Copyright (c) 2016, Gregory L. Dietsche
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Infinite.PuTTY.Tunnel.Properties;
using Infinite.PuTTY.Tunnel.Putty;

namespace Infinite.PuTTY.Tunnel.Forms
{
    public partial class TrayIcon : Form
    {
        private readonly AboutForm _aboutForm = new AboutForm();
        private readonly SessionManager _sessionManager = new SessionManager();

        public TrayIcon()
        {
            InitializeComponent();

            if (!File.Exists(Settings.Default.PlinkLocation))
            {
                ConfigurePlinkLocation();
            }
            StartSavedSessions();
        }

        private void StartSavedSessions()
        {
            if (Settings.Default.ActiveTunnels == null) return;
            foreach (var curTunnel in Settings.Default.ActiveTunnels)
            {
                var session = _sessionManager.Sessions.FirstOrDefault(s => s.Name == curTunnel && !s.IsActive);
                if(session!=null)StartSession(session);
            }
        }

        private void ConfigurePlinkLocation()
        {
            const string PlinkExe = "plink.exe";
            switch (MessageBox.Show(
                "Before you can use Infinite PuTTY Tunnel, it needs to have a working copy of plink.exe." +
                $"\n\nWould you like to download plink.exe from {Settings.Default.PlinkURL} ?" +
                "\n\nIf you choose NO, you can navigate to the location where you've stored plink.exe and choose that instead.",
                $"{Application.ProductName} - Download", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        using (var wc = new WebClient())
                        {
                            wc.DownloadFile(Settings.Default.PlinkURL, PlinkExe);
                            Settings.Default.PlinkLocation = PlinkExe;
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Download completed. Infinite PuTTY Tunnel is now ready to use.",
                                $"{Application.ProductName} - Download Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show($"There was an error while downloading {PlinkExe}. The error was: {ex.Message}",
                            $"{Application.ProductName} - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case DialogResult.No:
                    var openFileDialog = new OpenFileDialog
                    {
                        Filter = "plink.exe|plink.exe",
                        CheckFileExists = true,
                        FileName = PlinkExe,
                        Title = $"Please locate {PlinkExe}",
                        ValidateNames = true,
                    };

                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                    var plinkGuess = Path.Combine(openFileDialog.InitialDirectory, "PuTTY");
                    if (Directory.Exists(plinkGuess)) openFileDialog.InitialDirectory = plinkGuess;

                    if (DialogResult.OK == openFileDialog.ShowDialog(this))
                    {
                        Settings.Default.PlinkLocation = openFileDialog.FileName;
                    }
                    break;
            }

            if (!File.Exists(Settings.Default.PlinkLocation))
                MessageBox.Show(
                    $"Infinite PuTTY Tunnel is not configured correctly. Please set the location of {PlinkExe} using the menu on the system tray icon.",
                    $"{Application.ProductName} - Can't Find {PlinkExe}", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TrayIcon_Load(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (!_sessionManager.Sessions.Any(s => s.IsActive))
                    return;

                var sb = new StringBuilder();
                foreach (var curSession in _sessionManager.Sessions.Where(s => s.IsActive))
                {
                    sb.Append(curSession.Name);
                    sb.Append(":\n");
                    foreach (var curTunnel in curSession.Tunnels)
                    {
                        sb.Append('\t');
                        sb.Append(curTunnel);
                        sb.Append('\n');
                    }
                }
                notifyIcon.ShowBalloonTip(1000, "Current Tunnels", sb.ToString(), ToolTipIcon.Info);
            }
        }

        private void UpdateSessions()
        {
            menuTunnels.Enabled = false;

            if (!File.Exists(Settings.Default.PlinkLocation))
                return;

            menuTunnels.DropDownItems.Clear();

            foreach (var curSession in _sessionManager.Sessions)
            {
                menuTunnels.Enabled = true;

                var sessionItem = (ToolStripMenuItem) menuTunnels.DropDownItems.Add(curSession.Name);
                sessionItem.Tag = curSession;
                sessionItem.Click += MenuSession_Click;
                sessionItem.Checked = curSession.IsActive;
            }
        }

        private void MenuSession_Click(object sender, EventArgs e)
        {
            var sessionItem = sender as ToolStripMenuItem;
            var session = sessionItem?.Tag as PlinkSession;
            if (session == null) return;

            if (sessionItem.Checked)
            {
                session.Stop();
            }
            else
            {
                StartSession(session);
            }
        }

        #region Start Session
        private void StartSession(PlinkSession session)
        {
            session.WatchdogRestartHandler += SessionWatchdogRestartHandler;
            session.StartTunnelHandler += Session_StartTunnelHandler;
            session.Start();
        }

        private void Session_StartTunnelHandler(PlinkSession sender)
        {
            notifyIcon.ShowBalloonTip(1000, $"{Application.ProductName}", $"Started {sender.Name}", ToolTipIcon.Info);
        }

        private void SessionRestartTunnelHandler(PlinkSession sender)
        {
            notifyIcon.ShowBalloonTip(1000, $"{Application.ProductName}", $"Restarting {sender.Name}", ToolTipIcon.Info);
        }

        private void SessionWatchdogRestartHandler(PlinkSession sender)
        {
            notifyIcon.ShowBalloonTip(5000, $"{Application.ProductName}", $"Restarting {sender.Name} because it terminated unexpectedly.", ToolTipIcon.Error);
        }
        #endregion

        private void MenuExit_Click(object sender, EventArgs e)
        {
            _sessionManager.SaveActiveTunnels();

            foreach (var curSession in _sessionManager.Sessions)
                curSession.Stop();

            Application.Exit();
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            ConfigurePlinkLocation();
        }


        private void Menu_Opening(object sender, CancelEventArgs e)
        {
            UpdateSessions();
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            if (!_aboutForm.Visible)
                _aboutForm.ShowDialog();
        }
    }
}