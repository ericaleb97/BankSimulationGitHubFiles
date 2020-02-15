using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BankAccount2020
{
    public class BankAccountAdaptor
    {
        private static string sqlConn = "Data Source=DESKTOP-H72S0DN\\SQLINSTALL_1;Initial Catalog=BankAccount;Integrated Security=True";

        public static void ExecuteTransaction(Transaction transaction)
        {
            try
            {
                using (var connection = new SqlConnection(sqlConn))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = $"insert into [dbo].[Transaction]([userID],[amount],[transactionDate])" +
                        $"values('{transaction.UserID}',{transaction.Amount},'{transaction.TransactionDateTime}')";
                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows < 1)
                    {
                        MessageBox.Show("The record was not updated");
                    }
                }
            }

            catch (Exception)
            {
                //error logic for failed method
                MessageBox.Show("The request did not go through");

            }
        }

        public static decimal GetCurrentBalance(BankAccount account)
        {
            decimal currentBalance = 0;
            try
            {
                using (var connection = new SqlConnection(sqlConn))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = $"select BankAccount.dbo.getCurrentBalanceTwo('{account.userID}')";
                    connection.Open();
                    currentBalance = (decimal)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                //error logic for failed method
                MessageBox.Show("The request did not go through");
            }
            return currentBalance;
        }

        private static BankAccount GetFromReader(SqlDataReader reader)
        {
            var account = new BankAccount();

            try
            {
                account.PIN = Int32.Parse(reader.GetOrdinal("PIN").ToString());
                account.accountDate = DateTime.Parse(reader.GetDateTime(reader.GetOrdinal("transactionDate")).ToString());
                account.amount = Decimal.Parse(reader.GetDecimal(reader.GetOrdinal("amount")).ToString());
                account.userID = reader.GetString(reader.GetOrdinal("userID"));
                account.Balance = Decimal.Parse(reader.GetDecimal(reader.GetOrdinal("startingBalance")).ToString());
            }
            catch (Exception ex)
            {
                //error logic for failed method
                //throw;
            }

            return account;
        }

    }
}
