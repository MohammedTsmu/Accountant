using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accountant.Utilities
{
    public static class DatabaseUtilities
    {
        public static void BackupDatabase(string backupPath)
        {
            try
            {
                string serverName = Properties.Settings.Default.ServerName;

                if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(backupPath))
                {
                    MessageBox.Show("يرجى ضبط اسم الخادم ومسار النسخ الاحتياطي في الإعدادات.", "إعدادات مفقودة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = new SqlConnection($"Data Source={serverName};Integrated Security=True"))
                {
                    var query = $"BACKUP DATABASE AccountantDB TO DISK = '{backupPath}'";
                    var command = new SqlCommand(query, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show($"تم النسخ الاحتياطي لقاعدة البيانات بنجاح إلى {backupPath}.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"فشل النسخ الاحتياطي: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void RestoreDatabase(string restoreFile, MainForm mainForm)
        {
            try
            {
                string serverName = Properties.Settings.Default.ServerName;

                if (string.IsNullOrEmpty(serverName))
                {
                    MessageBox.Show("يرجى ضبط اسم الخادم في الإعدادات أولاً.", "إعدادات مفقودة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = new SqlConnection($"Data Source={serverName};Integrated Security=True"))
                {
                    connection.Open();

                    // Terminate all active connections to the database
                    var terminateConnectionsQuery = @"
                ALTER DATABASE AccountantDB 
                SET SINGLE_USER WITH ROLLBACK IMMEDIATE";

                    using (var terminateCommand = new SqlCommand(terminateConnectionsQuery, connection))
                    {
                        terminateCommand.ExecuteNonQuery();
                    }

                    // Restore the database
                    var restoreQuery = $"RESTORE DATABASE AccountantDB FROM DISK = '{restoreFile}'";

                    using (var restoreCommand = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCommand.ExecuteNonQuery();
                    }

                    // Set the database back to multi-user mode
                    var multiUserQuery = @"
                ALTER DATABASE AccountantDB 
                SET MULTI_USER";

                    using (var multiUserCommand = new SqlCommand(multiUserQuery, connection))
                    {
                        multiUserCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                MessageBox.Show("تم استعادة قاعدة البيانات بنجاح. سيتم تحديث البيانات الآن.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Call ReloadData from MainForm
                mainForm.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"فشل الاستعادة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}