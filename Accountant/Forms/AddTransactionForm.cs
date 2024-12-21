using Accountant.Models;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Accountant
{
    public partial class AddTransactionForm : Form
    {
        public AddTransactionForm()
        {
            InitializeComponent();

            dateEditTransaction.DateTime = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(textEditCustomerName.Text) || spinEditAmount.Value <= 0)
                {
                    MessageBox.Show("الرجاء إدخال تفاصيل صالحة.", "خطأ التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new transaction
                using (var db = new AccountantDBEntities())
                {
                    var transaction = new Transaction
                    {
                        DateAndTime = dateEditTransaction.DateTime,
                        CustomerName = textEditCustomerName.Text,
                        AmountReceived = (decimal)spinEditAmount.Value
                    };

                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }

                MessageBox.Show("تمت إضافة المعاملة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form without saving
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
