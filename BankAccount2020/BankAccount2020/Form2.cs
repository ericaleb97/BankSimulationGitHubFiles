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
            Transaction transaction = new Transaction(_account.userID, DateTime.Now, Convert.ToDecimal(userAmount.Text));
            _account.Deposit(transaction);
            userAmount.Text = "";
            userBalance.Text = _account.Balance.ToString();
        }

        private void withdraw_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(_account.userID, DateTime.Now, Convert.ToDecimal(userAmount.Text));
            _account.Withdraw(transaction);
            userAmount.Text = "";
            userBalance.Text = _account.Balance.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CurrentDateTime.Start();

            userBalance.Text = "";
            userBalance.Text = _account.Balance.ToString();
        }

        private void CurrentDateTime_Tick(object sender, EventArgs e)
        {
            transactionDate.Text = DateTime.Now.ToString();
        }
    }
}
