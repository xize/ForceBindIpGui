using System;
using System.Windows.Forms;

namespace src.ForceBindIPGui
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.installbtn = new System.Windows.Forms.Button();
            this.adapter = new System.Windows.Forms.TextBox();
            this.adapterbtn = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.notifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.context.SuspendLayout();
            this.SuspendLayout();
            // 
            // installbtn
            // 
            this.installbtn.Location = new System.Drawing.Point(12, 12);
            this.installbtn.Name = "installbtn";
            this.installbtn.Size = new System.Drawing.Size(113, 23);
            this.installbtn.TabIndex = 0;
            this.installbtn.Text = "Install ForceBindIP";
            this.installbtn.UseVisualStyleBackColor = true;
            this.installbtn.Click += new System.EventHandler(this.installbtn_Click);
            // 
            // adapter
            // 
            this.adapter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adapter.Enabled = false;
            this.adapter.Location = new System.Drawing.Point(12, 42);
            this.adapter.Name = "adapter";
            this.adapter.Size = new System.Drawing.Size(251, 20);
            this.adapter.TabIndex = 1;
            this.adapter.Text = "192.168.2.13";
            // 
            // adapterbtn
            // 
            this.adapterbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adapterbtn.Enabled = false;
            this.adapterbtn.Location = new System.Drawing.Point(269, 40);
            this.adapterbtn.Name = "adapterbtn";
            this.adapterbtn.Size = new System.Drawing.Size(120, 23);
            this.adapterbtn.TabIndex = 2;
            this.adapterbtn.Text = "listen to this adapter";
            this.adapterbtn.UseVisualStyleBackColor = true;
            this.adapterbtn.Click += new System.EventHandler(this.adapterbtn_Click);
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(12, 68);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(377, 23);
            this.progress.TabIndex = 3;
            // 
            // notifyicon
            // 
            this.notifyicon.ContextMenuStrip = this.context;
            this.notifyicon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyicon.Icon")));
            this.notifyicon.Text = "ForceBindIP Configuration Gui";
            this.notifyicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyicon_MouseDoubleClick);
            // 
            // context
            // 
            this.context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 114);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.adapterbtn);
            this.Controls.Add(this.adapter);
            this.Controls.Add(this.installbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 153);
            this.MinimumSize = new System.Drawing.Size(415, 153);
            this.Name = "Window";
            this.Text = "ForceBindIP Configuration Gui v14.0.25420.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form1_OnFormClosing);
            this.Load += new System.EventHandler(this.Window_Load);
            this.context.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button installbtn;
        private Button adapterbtn;
        private NotifyIcon notifyicon;
        private ContextMenuStrip context;
        private ToolStripMenuItem exitToolStripMenuItem;
        public TextBox adapter;
        public ProgressBar progress;
    }
}

