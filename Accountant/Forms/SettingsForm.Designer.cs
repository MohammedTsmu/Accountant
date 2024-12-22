﻿namespace Accountant.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.chkAutoBackup = new System.Windows.Forms.CheckBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowseBackupPath = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBackup.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Appearance.Options.UseFont = true;
            this.btnBackup.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintReport.ImageOptions.SvgImage")));
            this.btnBackup.Location = new System.Drawing.Point(483, 257);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBackup.Size = new System.Drawing.Size(282, 78);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "انشاء نسخة احتياطية";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestore.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Appearance.Options.UseFont = true;
            this.btnRestore.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnRestore.Location = new System.Drawing.Point(483, 346);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRestore.Size = new System.Drawing.Size(282, 78);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "استعادة النسخة الاحتياطية";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // chkAutoBackup
            // 
            this.chkAutoBackup.AutoSize = true;
            this.chkAutoBackup.Location = new System.Drawing.Point(553, 452);
            this.chkAutoBackup.Name = "chkAutoBackup";
            this.chkAutoBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAutoBackup.Size = new System.Drawing.Size(212, 30);
            this.chkAutoBackup.TabIndex = 7;
            this.chkAutoBackup.Text = "اخذ نسخة عند الاغلاق";
            this.chkAutoBackup.UseVisualStyleBackColor = true;
            this.chkAutoBackup.CheckedChanged += new System.EventHandler(this.chkAutoBackup_CheckedChanged);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(260, 67);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(303, 33);
            this.txtServerName.TabIndex = 8;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(260, 106);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(303, 33);
            this.txtBackupPath.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(483, 542);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(282, 78);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "حفظ الاعدادات";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowseBackupPath
            // 
            this.btnBrowseBackupPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowseBackupPath.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseBackupPath.Appearance.Options.UseFont = true;
            this.btnBrowseBackupPath.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.btnBrowseBackupPath.Location = new System.Drawing.Point(483, 164);
            this.btnBrowseBackupPath.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnBrowseBackupPath.Name = "btnBrowseBackupPath";
            this.btnBrowseBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBrowseBackupPath.Size = new System.Drawing.Size(282, 78);
            this.btnBrowseBackupPath.TabIndex = 6;
            this.btnBrowseBackupPath.Text = "تغيير مسار الحفظ";
            this.btnBrowseBackupPath.Click += new System.EventHandler(this.btnBrowseBackupPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 67);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "اسم السيرفر";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 109);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(197, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "مسار النسخ الاحتياطية";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 661);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.chkAutoBackup);
            this.Controls.Add(this.btnBrowseBackupPath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private System.Windows.Forms.CheckBox chkAutoBackup;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtBackupPath;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnBrowseBackupPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}