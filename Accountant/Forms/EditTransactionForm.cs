using Accountant.Models;
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
    public partial class EditTransactionForm : Form
    {
        public EditTransactionForm()
        {
            InitializeComponent();
        }

        private Transaction _transaction;

        public EditTransactionForm(Transaction transaction)
        {
            InitializeComponent();
            _transaction = transaction;

            // Populate fields with existing data
            dateEditTransaction.DateTime = _transaction.DateAndTime;
            textEditCustomerName.Text = _transaction.CustomerName;
            spinEditAmount.Value = (decimal)_transaction.AmountReceived;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textEditCustomerName.Text) || spinEditAmount.Value <= 0)
                {
                    MessageBox.Show("الرجاء إدخال تفاصيل صالحة.", "أخطاء التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new AccountantDBEntities())
                {
                    var transaction = db.Transactions.Find(_transaction.TransactionID);

                    if (transaction != null)
                    {
                        transaction.DateAndTime = dateEditTransaction.DateTime;
                        transaction.CustomerName = textEditCustomerName.Text;
                        transaction.AmountReceived = (decimal)spinEditAmount.Value;

                        db.SaveChanges();
                    }
                }

                MessageBox.Show("تم تحديث المعاملة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
