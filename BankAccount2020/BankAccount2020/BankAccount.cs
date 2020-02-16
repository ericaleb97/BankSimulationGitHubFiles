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
        public decimal Balance { get; set; }
        public decimal amount { get; set; }
        public string userID { get; set; }

        public int PIN { get; set; }

        private DateTime accountDate1;

        public BankAccount()
        {

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

        public void Action(Transaction transaction)
        {
            Balance += transaction.Amount;
            BankAccountAdaptor.ExecuteTransaction(transaction);
        }

        //public void Withdraw(Transaction transaction)
        //{
        //    Balance += transaction.Amount;
        //    BankAccountAdaptor.ExecuteTransaction(transaction);
        //}
    }
}
