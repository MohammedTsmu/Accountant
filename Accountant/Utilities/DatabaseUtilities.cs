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
                    connection.Open();

                    // Terminate all active connections to the database
                    var terminateConnectionsQuery = @"
                USE master;
                ALTER DATABASE AccountantDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE";

                    using (var terminateCommand = new SqlCommand(terminateConnectionsQuery, connection))
                    {
                        terminateCommand.ExecuteNonQuery();
                    }

                    // Perform the backup
                    string query = $"BACKUP DATABASE AccountantDB TO DISK = '{backupPath}'";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Set the database back to multi-user mode
                    var multiUserQuery = @"
                ALTER DATABASE AccountantDB SET MULTI_USER";

                    using (var multiUserCommand = new SqlCommand(multiUserQuery, connection))
                    {
                        multiUserCommand.ExecuteNonQuery();
                    }

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

                    // Identify and kill all active connections to the database
                    string killConnectionsQuery = @"
                DECLARE @kill varchar(8000) = '';
                SELECT @kill = @kill + 'KILL ' + CONVERT(varchar(5), session_id) + ';'
                FROM sys.dm_exec_sessions
                WHERE database_id = DB_ID('AccountantDB');
                EXEC(@kill)";

                    using (var killCommand = new SqlCommand(killConnectionsQuery, connection))
                    {
                        killCommand.ExecuteNonQuery();
                    }

                    // Set the database to SINGLE_USER mode
                    var setSingleUserQuery = @"
                USE master;
                ALTER DATABASE AccountantDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE";

                    using (var singleUserCommand = new SqlCommand(setSingleUserQuery, connection))
                    {
                        singleUserCommand.ExecuteNonQuery();
                    }

                    // Restore the database with REPLACE
                    var restoreQuery = $@"
                RESTORE DATABASE AccountantDB 
                FROM DISK = '{restoreFile}' 
                WITH REPLACE";

                    using (var restoreCommand = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCommand.ExecuteNonQuery();
                    }

                    // Set the database back to MULTI_USER mode
                    var setMultiUserQuery = @"
                ALTER DATABASE AccountantDB SET MULTI_USER";

                    using (var multiUserCommand = new SqlCommand(setMultiUserQuery, connection))
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