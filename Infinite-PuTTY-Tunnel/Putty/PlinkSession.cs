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
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Infinite.PuTTY.Tunnel.Properties;

namespace Infinite.PuTTY.Tunnel.Putty
{
    internal class PlinkSession : IDisposable
    {
        public delegate void PlinkSessionEventHandler(PlinkSession sender);

        public event PlinkSessionEventHandler WatchdogRestartHandler;
        public event PlinkSessionEventHandler StartTunnelHandler;

        public readonly IList<Tunnel> Tunnels = new List<Tunnel>();
        private readonly string _puttySessionKey;
        private Process _plink;

        public bool IsEnabled { get; private set; }

        private bool IsActive => _plink != null && !_plink.HasExited;

        public string Name => Uri.UnescapeDataString(_puttySessionKey);

        public PlinkSession(string sessionKey, string puttyPortForwards)
        {
            _puttySessionKey = sessionKey;

            foreach (var curTunnel in puttyPortForwards.Split(','))
            {
                if (!string.IsNullOrEmpty(curTunnel))
                {
                    Tunnels.Add(new Tunnel(curTunnel));
                }
            }
        }

        public void Start()
        {
            Start(_plink != null && _plink.HasExited);
        }

        public void Start(bool isRestart)
        {
            IsEnabled = true;
            if (IsActive) return;

            _plink = new Process
            {
                StartInfo =
                {
                    FileName = Settings.Default.PlinkLocation,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    Arguments = $"-batch -agent -N -load \"{Name}\""
                }
            };

            _plink.Exited += plink_Exited;
            _plink.EnableRaisingEvents = true;
            _plink.Start();

            if(isRestart)
                WatchdogRestartHandler?.Invoke(this);
            else
                StartTunnelHandler?.Invoke(this);
        }

        /// <summary>
        /// Watchdog: Try to restart the session because it exited unexpectedly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plink_Exited(object sender, EventArgs e)
        {
            try
            {
                Start(true);
            }
            catch
            {
                // do nothing
            }

            while (IsEnabled && !IsActive)
            {
                try
                {
                    Thread.Sleep(Settings.Default.WatchDogRetryDelayInMilliseconds);
                    if (IsEnabled && !IsActive)
                        Start(true);
                }
                catch
                {
                    // do nothing
                }
            }
        }

        public void Stop()
        {
            IsEnabled = false;
            if (_plink != null)
            {
                _plink.EnableRaisingEvents = false;
                if (!_plink.HasExited) _plink.Kill();
                _plink.Dispose();
                _plink = null;
            }
        }
        public void Dispose()
        {
            Stop();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}