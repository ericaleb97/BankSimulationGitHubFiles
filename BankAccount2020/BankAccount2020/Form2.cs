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
        public Form2(string _pin)
        {
            InitializeComponent();
            var account = new BankAccount();
            account.PIN = _pin;
        }

        private void deposit_Click(object sender, EventArgs e)
        {

        }

        private void withdraw_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //string pin = _account.userPIN;

            //Find out how to make the PIN value from form1 in the form2 constructor//
            //accessable to the form2_Load method//

            var account = BankAccountAdaptor.SelectSingleRecord(_pin);
            userBalance.Text = account.Balance.ToString();
        }
    }
}
