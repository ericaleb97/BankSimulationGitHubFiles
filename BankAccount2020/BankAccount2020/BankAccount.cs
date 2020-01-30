using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount2020
{
    public class BankAccount
    {
        public double Balance { get; set; }
        public double amount { get; set; }

        public string PIN { get; set; }

        private DateTime accountDate1;

        public BankAccount()
        {

        }

        public BankAccount(double Balance)
        {
            this.Balance = Balance;
        }

        public DateTime accountDate
        {
            get
            {
                return accountDate1;
            }

            set
            {
                accountDate1 = DateTime.Now;
            }
        }

        public double Withdraw()
        {
            Balance -= amount;

            return amount;
        }

        public double Deposit(double amount)
        {
            //accountDate = new DateTime();
            //accountDate = DateTime.Now;

            Balance += amount;
            return amount;
        }
    }
}
