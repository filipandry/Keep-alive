﻿namespace KeepAliveConfigurator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grdUrls = new System.Windows.Forms.DataGridView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTBNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTBSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTBOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTBDelete = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdUrls)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUrls
            // 
            this.grdUrls.AllowUserToAddRows = false;
            this.grdUrls.AllowUserToDeleteRows = false;
            this.grdUrls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUrls.Location = new System.Drawing.Point(0, 0);
            this.grdUrls.Name = "grdUrls";
            this.grdUrls.ReadOnly = true;
            this.grdUrls.Size = new System.Drawing.Size(634, 285);
            this.grdUrls.TabIndex = 0;
            this.grdUrls.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUrls_CellDoubleClick);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.grdUrls);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(634, 285);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 45);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Size = new System.Drawing.Size(709, 310);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTBNew,
            this.toolStripSeparator3,
            this.btnTBSave,
            this.toolStripSeparator2,
            this.btnTBOpen,
            this.toolStripSeparator1,
            this.btnTBDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(75, 183);
            this.toolStrip1.TabIndex = 0;
            // 
            // btnTBNew
            // 
            this.btnTBNew.Image = ((System.Drawing.Image)(resources.GetObject("btnTBNew.Image")));
            this.btnTBNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTBNew.Name = "btnTBNew";
            this.btnTBNew.Size = new System.Drawing.Size(73, 36);
            this.btnTBNew.Text = "New";
            this.btnTBNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTBNew.Click += new System.EventHandler(this.btnTBNew_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(73, 6);
            // 
            // btnTBSave
            // 
            this.btnTBSave.Image = ((System.Drawing.Image)(resources.GetObject("btnTBSave.Image")));
            this.btnTBSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTBSave.Name = "btnTBSave";
            this.btnTBSave.Size = new System.Drawing.Size(73, 36);
            this.btnTBSave.Text = "Save";
            this.btnTBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTBSave.Click += new System.EventHandler(this.btnTBSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(73, 6);
            // 
            // btnTBOpen
            // 
            this.btnTBOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnTBOpen.Image")));
            this.btnTBOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTBOpen.Name = "btnTBOpen";
            this.btnTBOpen.Size = new System.Drawing.Size(73, 36);
            this.btnTBOpen.Text = "Open";
            this.btnTBOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTBOpen.Click += new System.EventHandler(this.btnTBOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(73, 6);
            // 
            // btnTBDelete
            // 
            this.btnTBDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnTBDelete.Image")));
            this.btnTBDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTBDelete.Name = "btnTBDelete";
            this.btnTBDelete.Size = new System.Drawing.Size(73, 36);
            this.btnTBDelete.Text = "Delete";
            this.btnTBDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTBDelete.Click += new System.EventHandler(this.btnTBDelete_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(627, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL to ping";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(13, 19);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(222, 20);
            this.txtUrl.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(717, 384);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStripContainer1);
            this.tabPage1.Controls.Add(this.txtUrl);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(709, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "URLs setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkLog);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(709, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkLog
            // 
            this.chkLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLog.Location = new System.Drawing.Point(23, 18);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(75, 24);
            this.chkLog.TabIndex = 2;
            this.chkLog.Text = "Use log";
            this.chkLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Clear log";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdLogs);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(709, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grdLogs
            // 
            this.grdLogs.AllowUserToAddRows = false;
            this.grdLogs.AllowUserToDeleteRows = false;
            this.grdLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogs.Location = new System.Drawing.Point(3, 3);
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.ReadOnly = true;
            this.grdLogs.Size = new System.Drawing.Size(703, 352);
            this.grdLogs.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 423);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Keep alive | Configurator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUrls)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdUrls;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTBOpen;
        private System.Windows.Forms.ToolStripButton btnTBDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ToolStripButton btnTBSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnTBNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView grdLogs;
    }
}

