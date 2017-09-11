namespace ohm_arduino_gui
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.sendTestDataBtn = new System.Windows.Forms.Button();
            this.comPortCombo = new System.Windows.Forms.ComboBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 2000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // sendTestDataBtn
            // 
            this.sendTestDataBtn.Location = new System.Drawing.Point(238, 11);
            this.sendTestDataBtn.Name = "sendTestDataBtn";
            this.sendTestDataBtn.Size = new System.Drawing.Size(125, 31);
            this.sendTestDataBtn.TabIndex = 0;
            this.sendTestDataBtn.Text = "Send test data";
            this.sendTestDataBtn.UseVisualStyleBackColor = true;
            this.sendTestDataBtn.Click += new System.EventHandler(this.sendTestDataBtn_Click);
            // 
            // comPortCombo
            // 
            this.comPortCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comPortCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortCombo.FormattingEnabled = true;
            this.comPortCombo.Location = new System.Drawing.Point(12, 17);
            this.comPortCombo.Name = "comPortCombo";
            this.comPortCombo.Size = new System.Drawing.Size(220, 21);
            this.comPortCombo.TabIndex = 1;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(12, 48);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(351, 201);
            this.logBox.TabIndex = 2;
            this.logBox.Text = "";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "OHM - Arduino";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(9, 257);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(166, 13);
            this.githubLink.TabIndex = 3;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "View About information on GitHub";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWindowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconMenu.Name = "notifyIconMenu";
            this.notifyIconMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.showWindowToolStripMenuItem.Text = "Show window";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 279);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.comPortCombo);
            this.Controls.Add(this.sendTestDataBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OpenHardwareMonitor - Arduino";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.notifyIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button sendTestDataBtn;
        private System.Windows.Forms.ComboBox comPortCombo;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

