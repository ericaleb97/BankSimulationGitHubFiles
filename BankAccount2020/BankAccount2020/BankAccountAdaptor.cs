using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BankAccount2020
{
    public class BankAccountAdaptor
    {
        private static string sqlConn = "Data Source=DESKTOP-H72S0DN\\SQLINSTALL_1;Initial Catalog=BankAccount;Integrated Security=True";

        /// <summary>
        /// Inserts a single Taxpayer object into the database
        /// </summary>
        /// <param name="Taxpayer"></param>
        /// <returns></returns>
        public static int InsertSingleRecordDeposit(BankAccount account)
        {
            int count = 0;
            try
            {
                using (var connection = new SqlConnection(sqlConn))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = $"insert into User(startingBalance) " +
                    $"values('{account.Balance}')";
                    command.CommandText = $"insert into Transaction(amount, transactionDate) " +
                    $"values('{account.amount}', '{account.accountDate}')";
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

        public static int InsertSingleRecordWithdraw(BankAccount account)
        {
            int count = 0;
            try
            {
                using (var connection = new SqlConnection(sqlConn))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = $"insert into User(startingBalance) " +
                    $"values('{account.Balance}')";
                    command.CommandText = $"insert into Transaction(amount, transactionDate) " +
                    $"values('{account.amount}', '{account.accountDate}')";
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
                    command.CommandText = $"select top 1 * from User where PIN = {account.PIN}";
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
                account.Balance = Double.Parse(reader.GetDouble(reader.GetOrdinal("Balance")).ToString());
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
