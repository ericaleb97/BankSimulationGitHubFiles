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
            account.accountDate = DateTime.Parse(transactionDate.Text);

            BankAccountAdaptor.UpdateRecordBalance(account);
            BankAccountAdaptor.InsertSingleRecord(account);
        }

        private void withdraw_Click(object sender, EventArgs e)
        {
            var account = new BankAccount();

            account.Balance = Convert.ToDouble(userBalance.Text);
            account.amount = Convert.ToDouble(userAmount.Text);
            userBalance.Text = account.Withdraw().ToString();
            account.accountDate = DateTime.Parse(transactionDate.Text);

            BankAccountAdaptor.UpdateRecordBalance(account);
            BankAccountAdaptor.InsertSingleRecord(account);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CurrentDateTime.Start();


            var account = BankAccountAdaptor.SelectSingleRecord(_account.userID);
            userBalance.Text = account.Balance.ToString();

            //var account = BankAccountAdaptor.SelectSingleRecord(_account);
            //userBalance.Text = account.Balance.ToString();
        }

        private void CurrentDateTime_Tick(object sender, EventArgs e)
        {
            transactionDate.Text = DateTime.Now.ToString();
        }
    }
}
