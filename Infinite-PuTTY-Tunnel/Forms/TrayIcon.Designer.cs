namespace Infinite.PuTTY.Tunnel.Forms
{
    partial class TrayIcon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuTunnels = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparatorTwo = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTunnels,
            this.menuSparatorOne,
            this.menuSettings,
            this.menuAbout,
            this.menuSeparatorTwo,
            this.menuExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(272, 148);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_Opening);
            // 
            // menuTunnels
            // 
            this.menuTunnels.Enabled = false;
            this.menuTunnels.Name = "menuTunnels";
            this.menuTunnels.Size = new System.Drawing.Size(271, 26);
            this.menuTunnels.Text = "&Tunnels";
            // 
            // menuSparatorOne
            // 
            this.menuSparatorOne.Name = "menuSparatorOne";
            this.menuSparatorOne.Size = new System.Drawing.Size(268, 6);
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(271, 26);
            this.menuSettings.Text = "Configure Plink.exe Location";
            this.menuSettings.Click += new System.EventHandler(this.MenuSettings_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(271, 26);
            this.menuAbout.Text = "&About";
            this.menuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // menuSeparatorTwo
            // 
            this.menuSeparatorTwo.Name = "menuSeparatorTwo";
            this.menuSeparatorTwo.Size = new System.Drawing.Size(268, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(271, 26);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = global::Infinite.PuTTY.Tunnel.Properties.Resources.TrayIcon;
            this.notifyIcon.Text = "Infinite PuTTY Tunnel";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // TrayIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 255);
            this.Name = "TrayIcon";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.TrayIcon_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuTunnels;
        private System.Windows.Forms.ToolStripSeparator menuSparatorOne;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripSeparator menuSeparatorTwo;
    }
}