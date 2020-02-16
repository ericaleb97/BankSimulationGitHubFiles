using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount2020
{
    public class Transaction
    {
        private decimal _amount { get; set; }
        private DateTime _transactionDateTime { get; set; }

        private string _userID { get; set; }

        public Transaction(string UserID, DateTime TransactionDateTime, decimal Amount)
        {
            _userID = UserID;
            _transactionDateTime = TransactionDateTime;
            _amount = Amount;
        }

        public string UserID
        {
            get
            {
                return _userID;
            }
        }

        public decimal Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        public DateTime TransactionDateTime
        {
            get
            {
                return _transactionDateTime;
            }
        }
    }
}
