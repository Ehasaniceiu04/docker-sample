using MCash.Business.Domain;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCash.Business.Service
{
    public class TransactionService
    {
       
        public TransactionService()
        {
            
        }
        public BankAccount GetAll(string connectionString)
        {
            BankAccount bankAccount = new BankAccount();
            var transactions = new List<TransactionDetails>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand("SELECT * FROM BankAccount AS B LEFT JOIN TransactionDetails AS T ON B.AccountNumber = T.AccountNumber", connection))
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        bankAccount.AccountNumber = reader["AccountNumber"].ToString();
                        bankAccount.AccountHolder = reader["AccountHolder"].ToString();
                        bankAccount.Currency = reader["AccountCurrency"].ToString();
                        bankAccount.OpeningBalance = decimal.Parse(reader["OpeningBalance"].ToString());
                        bankAccount.ClosingBalance = decimal.Parse(reader["ClosingBalance"].ToString());
                        if (reader["Id"] != DBNull.Value)
                        {
                            transactions.Add(new TransactionDetails()
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                TransactionDate = reader["TransactionDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["TransactionDate"].ToString()),
                                Reference = reader["Reference"].ToString(),
                                Description = reader["Description"].ToString(),
                                Debit = reader["Debit"] == DBNull.Value ? 0 : decimal.Parse(reader["Debit"].ToString()),
                                Credit = reader["Credit"] == DBNull.Value ? 0 : decimal.Parse(reader["Credit"].ToString()),
                                Balance = reader["Balance"] == DBNull.Value ? 0 : decimal.Parse(reader["Balance"].ToString()),
                            });
                        }

                    }
                    bankAccount.TransactionDetails = transactions.Count>0?transactions:null;
                }
            }
            return bankAccount; 
        }

        public bool Debit(TransactionViewModel transactionViewModel, string connectionString)
        {
            bool isDebit = false;
            try
            {
                var closingBalance = GetClosingAmount(connectionString);
                closingBalance = closingBalance - transactionViewModel.TransactionAmount;
                var insertQuery = new StringBuilder();
                insertQuery.AppendLine($"UPDATE BankAccount SET ClosingBalance={closingBalance}");
                insertQuery.AppendLine("INSERT INTO [dbo].[TransactionDetails] ([AccountNumber],[TransactionDate],[Reference],[Description],[Debit],[Credit],[Balance])");
                insertQuery.AppendLine($"VALUES('{transactionViewModel.AccountNo}','{DateTime.Now}','{transactionViewModel.Reference}','{transactionViewModel.Description}'");
                insertQuery.AppendLine($",{transactionViewModel.TransactionAmount},0,{closingBalance})");
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var sqlCommand = new SqlCommand(insertQuery.ToString(), connection))
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        isDebit = true;
                    }
                }
            }
            catch(Exception exp)
            {
                isDebit = false;
            }
            return isDebit;

        }
        private decimal GetClosingAmount(string connectionString)
        {
            decimal closingBalance = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand("SELECT ClosingBalance FROM BankAccount", connection))
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        closingBalance = decimal.Parse(reader["ClosingBalance"].ToString());
                    }
                }
            }
            return closingBalance;
        }
        public bool Credit(TransactionViewModel transactionViewModel,string connectionString)
        {
            bool isCredit = false;
            try
            {
                var closingBalance = GetClosingAmount(connectionString);
                closingBalance = closingBalance + transactionViewModel.TransactionAmount;
                var insertQuery = new StringBuilder();
                insertQuery.AppendLine($"UPDATE BankAccount SET ClosingBalance={closingBalance}");
                insertQuery.AppendLine("INSERT INTO [dbo].[TransactionDetails] ([AccountNumber],[TransactionDate],[Reference],[Description],[Debit],[Credit],[Balance])");
                insertQuery.AppendLine($"VALUES('{transactionViewModel.AccountNo}','{DateTime.Now}','{transactionViewModel.Reference}','{transactionViewModel.Description}'");
                insertQuery.AppendLine($",0,{transactionViewModel.TransactionAmount},{closingBalance})");
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var sqlCommand = new SqlCommand(insertQuery.ToString(), connection))
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        isCredit = true;
                    }
                }
            }
            catch (Exception exp)
            {
                isCredit = false;
            }
            return isCredit;
        }
    }
}
