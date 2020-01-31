using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccount2020
{
    public partial class Form2 : Form
    {
        BankAccount _account;

        public Form2(BankAccount account)
        {
            InitializeComponent();
            _account = account;
        }

        private void deposit_Click(object sender, EventArgs e)
        {
            var account = new BankAccount();
            account.Balance = Convert.ToDouble(userBalance.Text);
            account.amount = Convert.ToDouble(userAmount.Text);
            userBalance.Text = account.Deposit().ToString();
            BankAccountAdaptor.InsertSingleRecordDeposit(account);
        }

        private void withdraw_Click(object sender, EventArgs e)
        {
            var account = new BankAccount();
            account.Balance = Convert.ToDouble(userBalance.Text);
            account.amount = Convert.ToDouble(userAmount.Text);
            userBalance.Text = account.Withdraw().ToString();
            BankAccountAdaptor.InsertSingleRecordWithdraw(account);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (_account.PIN == 0)
            {
                MessageBox.Show("Please enter the user data before updating");
            }

            else
            {
                var account = new BankAccount();
                BankAccountAdaptor.SelectSingleRecord(account);
            }
        }
    }
}
