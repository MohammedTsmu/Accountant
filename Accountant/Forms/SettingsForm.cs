using Accountant.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accountant.Forms
{
    public partial class SettingsForm : Form
    {
        private MainForm mainForm;


        public SettingsForm(MainForm parentForm)
        {
            InitializeComponent();
            mainForm = parentForm;
        }

        //public SettingsForm()
        //{
        //    InitializeComponent();
        //}

        //private void btnBackup_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnRestore_Click(object sender, EventArgs e)
        //{

        //}
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            chkAutoBackup.Checked = Properties.Settings.Default.AutoBackup;
            txtServerName.Text = Properties.Settings.Default.ServerName;
            txtBackupPath.Text = Properties.Settings.Default.BackupPath;
        }


        //private void btnBackup_Click(object sender, EventArgs e)
        //{
        //    using (var dialog = new SaveFileDialog())
        //    {
        //        dialog.Filter = "Backup Files (*.bak)|*.bak";
        //        dialog.Title = "Select Backup File";

        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            mainForm.BackupDatabase(dialog.FileName);
        //        }
        //    }
        //}

        //private void btnRestore_Click(object sender, EventArgs e)
        //{
        //    using (var dialog = new OpenFileDialog())
        //    {
        //        dialog.Filter = "Backup Files (*.bak)|*.bak";
        //        dialog.Title = "Select Backup File";

        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            mainForm.RestoreDatabase(dialog.FileName);
        //        }
        //    }
        //}

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string backupPath = Properties.Settings.Default.BackupPath;
            if (string.IsNullOrEmpty(backupPath))
            {
                MessageBox.Show("يرجى ضبط مسار النسخ الاحتياطي في الإعدادات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string backupFile = System.IO.Path.Combine(backupPath, $"AccountantDB_{DateTime.Now:yyyyMMddHHmmss}.bak");
            DatabaseUtilities.BackupDatabase(backupFile);
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Backup Files (*.bak)|*.bak";
                dialog.Title = "حدد ملف النسخ الاحتياطي";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DatabaseUtilities.RestoreDatabase(dialog.FileName, mainForm);
                }
            }
        }




        private void chkAutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoBackup = chkAutoBackup.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName = txtServerName.Text.Trim();
            Properties.Settings.Default.BackupPath = txtBackupPath.Text.Trim();
            Properties.Settings.Default.Save();

            MessageBox.Show("تم حفظ الإعدادات بنجاح.", "حفظ الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void btnBrowseBackupPath_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = dialog.SelectedPath;
                }
            }
        }

    }
}
