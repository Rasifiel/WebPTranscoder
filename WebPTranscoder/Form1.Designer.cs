namespace WebPTranscoder {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.clipboard = new WK.Libraries.SharpClipboardNS.SharpClipboard(this.components);
      this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.trayMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // clipboard
      // 
      this.clipboard.MonitorClipboard = true;
      this.clipboard.ObservableFormats.All = true;
      this.clipboard.ObservableFormats.Files = true;
      this.clipboard.ObservableFormats.Images = true;
      this.clipboard.ObservableFormats.Others = true;
      this.clipboard.ObservableFormats.Texts = true;
      this.clipboard.ObserveLastEntry = true;
      this.clipboard.Tag = null;
      this.clipboard.ClipboardChanged += new System.EventHandler<WK.Libraries.SharpClipboardNS.SharpClipboard.ClipboardChangedEventArgs>(this.clipboard_ClipboardChanged);
      // 
      // trayIcon
      // 
      this.trayIcon.ContextMenuStrip = this.trayMenu;
      this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
      this.trayIcon.Text = "WebP transcoder";
      this.trayIcon.Visible = true;
      // 
      // trayMenu
      // 
      this.trayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.trayMenu.Name = "trayMenu";
      this.trayMenu.Size = new System.Drawing.Size(103, 28);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Name = "Form1";
      this.Text = "Form1";
      this.trayMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private WK.Libraries.SharpClipboardNS.SharpClipboard clipboard;
    private System.Windows.Forms.NotifyIcon trayIcon;
    private System.Windows.Forms.ContextMenuStrip trayMenu;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
  }
}

