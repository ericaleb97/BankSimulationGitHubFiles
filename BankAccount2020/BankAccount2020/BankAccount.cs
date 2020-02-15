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

        public void Deposit(Transaction transaction)
        {
            this.Balance += transaction.Amount;
            BankAccountAdaptor.ExecuteTransaction(transaction);
        }

        public void Withdraw(Transaction transaction)
        {
            this.Balance -= transaction.Amount;
            BankAccountAdaptor.ExecuteTransaction(transaction);
        }

        //public void UpdateAmount(Transaction transaction)
        //{
        //    this.Balance += transaction.Amount;
        //    BankAccountAdaptor.ExecuteTransaction(transaction, this);
        //}

        //public decimal Withdraw()
        //{
        //    Balance -= amount;
        //    return Balance;
        //}

        //public decimal Deposit()
        //{
        //    Balance += amount;
        //    return Balance;
        //}
    }
}
