﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Accountant.Models;
using Accountant.Forms;
using System.Data.SqlClient;

namespace Accountant
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //// This line of code is generated by Data Source Configuration Wizard
            //// Instantiate a new DBContext
            //Accountant.Models.AccountantDBEntities dbContext = new Accountant.Models.AccountantDBEntities();
            //// Call the Load method to get the data for the given DbSet from the database.
            //dbContext.Transactions.Load();
            //// This line of code is generated by Data Source Configuration Wizard
            //gridControl1.DataSource = dbContext.Transactions.Local.ToBindingList();
            SetDatesTo30Days();
            LoadTransactions();
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            var addTransactionForm = new AddTransactionForm();
            addTransactionForm.ShowDialog();

            // Refresh the GridControl after adding a transaction
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            using (var db = new AccountantDBEntities())
            {
                gridControl1.DataSource = db.Transactions.ToList();
            }
        }

        private void SetDatesTo30Days()
        {
            dateEditFrom.DateTime = DateTime.Today.AddDays(-30); // Default to 30 days ago
            dateEditTo.DateTime = DateTime.Today; // Default to today
        }

        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            // Get the selected transaction
            var selectedTransaction = gridView1.GetFocusedRow() as Transaction;

            if (selectedTransaction == null)
            {
                MessageBox.Show("الرجاء تحديد المعاملة لتحريرها.", "لا يوجد اختيار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open the EditTransactionForm
            var editTransactionForm = new EditTransactionForm(selectedTransaction);
            editTransactionForm.ShowDialog();

            // Refresh the GridControl
            LoadTransactions();
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            // Get the selected transaction
            var selectedTransaction = gridView1.GetFocusedRow() as Transaction;

            if (selectedTransaction == null)
            {
                MessageBox.Show("الرجاء تحديد المعاملة التي تريد حذفها.", "لا يوجد اختيار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذه المعاملة؟",
                                         "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new AccountantDBEntities())
                    {
                        var transaction = db.Transactions.Find(selectedTransaction.TransactionID);

                        if (transaction != null)
                        {
                            db.Transactions.Remove(transaction);
                            db.SaveChanges();
                        }
                    }

                    MessageBox.Show("تم حذف المعاملة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterTransactions();

        }

        //private void FilterTransactions()
        //{
        //    using (var db = new AccountantDBEntities())
        //    {
        //        try
        //        {
        //            var fromDate = dateEditFrom.DateTime.Date;
        //            var toDate = dateEditTo.DateTime.Date.AddDays(1).AddTicks(-1);
        //            var customerName = textEditCustomerName.Text.Trim();

        //            var query = db.Transactions.Where(t => t.DateAndTime >= fromDate && t.DateAndTime <= toDate);

        //            if (!string.IsNullOrEmpty(customerName))
        //            {
        //                query = query.Where(t => t.CustomerName.Contains(customerName));
        //            }

        //            var filteredTransactions = query.ToList();

        //            if (!filteredTransactions.Any())
        //            {
        //                MessageBox.Show("No transactions found for the selected criteria.", "Filter Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }

        //            gridControl1.DataSource = null;
        //            gridControl1.DataSource = filteredTransactions;

        //            var totalAmount = filteredTransactions.Sum(t => t.AmountReceived);
        //            lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"An error occurred while filtering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void FilterTransactions()
        {
            using (var db = new AccountantDBEntities())
            {
                try
                {
                    // Handle empty dates
                    var fromDate = dateEditFrom.EditValue == null
                        ? DateTime.MinValue
                        : dateEditFrom.DateTime.Date;
                    var toDate = dateEditTo.EditValue == null
                        ? DateTime.MaxValue
                        : dateEditTo.DateTime.Date.AddDays(1).AddTicks(-1);

                    var customerName = textEditCustomerName.Text.Trim();

                    var query = db.Transactions.Where(t => t.DateAndTime >= fromDate && t.DateAndTime <= toDate);

                    if (!string.IsNullOrEmpty(customerName))
                    {
                        query = query.Where(t => t.CustomerName.Contains(customerName));
                    }

                    var filteredTransactions = query.ToList();

                    if (!filteredTransactions.Any())
                    {
                        MessageBox.Show("لم يتم العثور على معاملات للمعايير المحددة.", "نتيجة التصفية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    gridControl1.DataSource = null;
                    gridControl1.DataSource = filteredTransactions;

                    var totalAmount = filteredTransactions.Sum(t => t.AmountReceived);
                    //lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";
                    lblTotalAmount.Text = $"اجمالي المبلغ الوارد: {totalAmount:N2}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطا ما اثناء التصفية: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        //private void btnPrintReport_Click(object sender, EventArgs e)
        //{
        //    // Get the filtered data from GridControl
        //    var filteredTransactions = gridView1.DataSource as List<Transaction>;

        //    if (filteredTransactions == null || !filteredTransactions.Any())
        //    {
        //        MessageBox.Show("No data to generate the report.", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Create and show the report
        //    var report = new Reports.TransactionReport();
        //    report.DataSource = filteredTransactions;
        //    var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);
        //    printTool.ShowPreview();
        //}

        //private void btnPrintReport_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Get the filtered data from GridControl
        //        var filteredTransactions = gridControl1.DataSource as List<Transaction>;

        //        if (filteredTransactions == null || !filteredTransactions.Any())
        //        {
        //            MessageBox.Show("No data to generate the report.", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Log filtered transactions for debugging
        //        foreach (var transaction in filteredTransactions)
        //        {
        //            Console.WriteLine($"Customer: {transaction.CustomerName}, Amount: {transaction.AmountReceived}");
        //        }

        //        // Create and configure the report
        //        var report = new Reports.TransactionReport();
        //        report.DataSource = filteredTransactions;

        //        // Preview the report
        //        var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);
        //        printTool.ShowPreview();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnPrintReport_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Get the filtered data from GridControl
        //        var filteredTransactions = gridControl1.DataSource as List<Transaction>;

        //        if (filteredTransactions == null || !filteredTransactions.Any())
        //        {
        //            MessageBox.Show("لا توجد بيانات لإنشاء التقرير.", "تقرير خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        // Create and configure the report
        //        var report = new Reports.TransactionReport();
        //        report.DataSource = filteredTransactions;
        //        report.DataMember = ""; // Ensure no specific data member is restricting the data

        //        //var fromDate = dateEditFrom.DateTime.Date;
        //        //var toDate = dateEditTo.DateTime.Date.AddDays(1).AddTicks(-1);
        //        report.Parameters["pFromDate"].Value = dateEditFrom.DateOnly;
        //        report.Parameters["pToDate"].Value = dateEditTo.DateOnly;

        //        // Pass parameters if needed
        //        if (report.Parameters["ReportTotal"] != null)
        //        {
        //            report.Parameters["ReportTotal"].Value = filteredTransactions.Sum(t => t.AmountReceived);
        //            report.Parameters["ReportTotal"].Visible = false; // Avoid asking for the parameter value
        //            report.Parameters["pFromDate"].Visible = false;
        //            report.Parameters["pToDate"].Visible = false;
        //        }

        //        // Preview the report
        //        var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);
        //        printTool.ShowPreview();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"حدث خطأ أثناء إنشاء التقرير: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                var filteredTransactions = gridControl1.DataSource as List<Transaction>;

                if (filteredTransactions == null || !filteredTransactions.Any())
                {
                    MessageBox.Show("لا توجد بيانات لإنشاء التقرير.", "تقرير خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Reports.TransactionReport
                {
                    DataSource = filteredTransactions,
                    DataMember = ""
                };

                // Set report parameters
                //report.Parameters["pFromDate"].Value = dateEditFrom.DateTime.Date;
                //report.Parameters["pToDate"].Value = dateEditTo.DateTime.Date;
                report.Parameters["pFromDate"].Value = dateEditFrom.DateOnly;
                report.Parameters["pToDate"].Value = dateEditTo.DateOnly;
                report.Parameters["ReportTotal"].Value = filteredTransactions.Sum(t => t.AmountReceived);

                report.Parameters["pFromDate"].Visible = false;
                report.Parameters["pToDate"].Visible = false;
                report.Parameters["ReportTotal"].Visible = false;

                var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);
                printTool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إنشاء التقرير: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        public void BackupDatabase(string backupPath)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=YourServerName;Integrated Security=True"))
                {
                    var query = $"BACKUP DATABASE AccountantDB TO DISK = '{backupPath}'";
                    var command = new SqlCommand(query, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("تم نسخ قاعدة البيانات احتياطيًا بنجاح.", "النسخ الاحتياطي", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"فشل النسخ الاحتياطي: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RestoreDatabase(string backupPath)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=YourServerName;Integrated Security=True"))
                {
                    var query = $"RESTORE DATABASE AccountantDB FROM DISK = '{backupPath}'";
                    var command = new SqlCommand(query, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("تم استعادة قاعدة البيانات بنجاح.", "استعادة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"فشل الاستعادة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.AutoBackup)
            {
                BackupDatabase("C:\\Backup\\AccountantDB.bak");
            }
        }

        private void svgImageBoxSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();

        }

        //public void ReloadData()
        //{
        //    try
        //    {
        //        using (var db = new AccountantDBEntities())
        //        {
        //            // Reload transactions into the GridControl
        //            gridControl1.DataSource = null;
        //            gridControl1.DataSource = db.Transactions.ToList();

        //            // Reset totals or filters if needed
        //            lblTotalAmount.Text = "اجمالي المبلغ الوارد: 0.00";
        //            SetDatesTo30Days(); // Resets date filters to last 30 days
        //        }

        //        MessageBox.Show("تم تحديث البيانات بنجاح.", "تحديث البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"فشل تحديث البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void ReloadData()
        {
            try
            {
                using (var db = new AccountantDBEntities())
                {
                    // Reload transactions into the GridControl
                    var transactions = db.Transactions.ToList();
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = transactions;

                    // Calculate the total amount
                    var totalAmount = transactions.Sum(t => t.AmountReceived);
                    lblTotalAmount.Text = $"اجمالي المبلغ الوارد: {totalAmount:N2}";

                    // Optionally reset filters
                    SetDatesTo30Days(); // Reset date filters to the last 30 days
                }

                MessageBox.Show("تم تحديث البيانات بنجاح.", "تحديث البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"فشل تحديث البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}