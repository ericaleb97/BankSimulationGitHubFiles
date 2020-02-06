using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BankAccount2020
{
    public class BankAccountAdaptor
    {
        private static string sqlConn = "Data Source=DESKTOP-H72S0DN\\SQLINSTALL_1;Initial Catalog=BankAccount;Integrated Security=True";

        /// <summary>
        /// Updates the new balance amount into the User table
        /// </summary>
        /// <param name="BankAccount"></param>
        /// <returns></returns>
        public static bool UpdateRecordBalance(BankAccount account)
        {
            try
            {
                using (var connection = new SqlConnection(sqlConn))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = $"Update [User] set startingBalance = {account.Balance}";
                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("The record was updated");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("The record was not updated");
                        return false;
                    }
                }
            }

            catch (Exception)
            {
                //error logic for failed method
                MessageBox.Show("The request did not go through");
                return false;
            }
        }

        /// <summary>
        /// Inserts the transaction amount into the Transaction table
        /// </summary>
        /// <param name="BankAccount"></param>
        /// <returns></returns>
        public static int InsertSingleRecord(BankAccount account)
        {
            int count = 0;
            try
            {
                using (var connection = new SqlConnection(sqlConn))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = $"insert into [Transaction](amount, transactionDate)" +
                    $"values({account.amount}, {account.accountDate})";
                    connection.Open();
                    count = command.ExecuteNonQuery();
                    MessageBox.Show("The record was entered into the database");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The data was not entered into the database");
            }

            return count;
        }

        public static BankAccount SelectSingleRecord(BankAccount account)
        {
            try
            {
                using (var connection = new SqlConnection(sqlConn))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = $"select top 1 * from [User] where PIN = {account.PIN}";
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        try
                        {
                            account = GetFromReader(reader);
                            MessageBox.Show("The record was found");
                            //MessageBox.Show("The record was not found");
                        }
                        catch (Exception)
                        {
                            //error logic on failed db read
                            MessageBox.Show("The record was not found");
                        }
                    }
                }
            }
            catch (Exception)
            {
                //error logic for failed method
                MessageBox.Show("The request did not go through");
            }

            return account;
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
