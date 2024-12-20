using Accountant.Models;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(textEditCustomerName.Text) || spinEditAmount.Value <= 0)
                {
                    MessageBox.Show("Please enter valid details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Transaction added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form without saving
        }
    }
}
