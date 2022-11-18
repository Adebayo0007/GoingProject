using System;
using System.Collections.Generic;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;
using System.IO;
using MySql.Data.MySqlClient;

namespace LegitBankApp.Implementations
{
    public class TransactionManager : ITransactionManager
    {

        string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";
        

        

        public void CreateAirtime(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum)
        {
            if(airtimeAmount < Transaction._accountBalance )
            {

             try
            {
                
                Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
                 string  u = $"{transact._refNum}";
                 System.Console.Write("Your ref number is:");
                 System.Console.WriteLine(u);
                
                 System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {airtimeAmount}\n\tYour balance is: {accountBalance}\n\tDate: {dateTime}");
               


                using (var connection = new MySqlConnection(conn))
                {
                   string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum) values ('{Transaction._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}')";
                    connection.Open();
                   using (var command = new MySqlCommand(qur, connection))
                    {
                       var execute = command.ExecuteNonQuery();
                       if(execute > 0)
                        {
                                accountBalance = Transaction._accountBalance;
                                accountBalance-=airtimeAmount;
                                airtimeAmount = Transaction._airtimeAmount;
                              //Transaction transaction = new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
                                Transaction._accountBalance = accountBalance;
                                System.Console.WriteLine($"Transaction successful ! ");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            }
            else
            {
                Console.Beep();
                System.Console.WriteLine("Low Balance");
            }

            
            
           
             
        }

       

        public void CreateDeposit(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum)
        {
            try
            {
                
                
               Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
                string  u = $"{transact._refNum}";
                 System.Console.Write("Your ref number is:");
                System.Console.WriteLine(u);
                 System.Console.WriteLine($"\n\tTnx: Credit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {depositAmount}\n\tYour balance is: {accountBalance}\n\tDate: {dateTime}");

               
               


                using (var connection = new MySqlConnection(conn))
                {
                    string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum) values ('{Transaction._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}')";
                    connection.Open();
                    using (var command = new MySqlCommand(qur, connection))
                    {
                      var execute = command.ExecuteNonQuery();
                        if(execute > 0)
                        {
                               accountBalance = Transaction._accountBalance;
                                accountBalance+=depositAmount;
                                Transaction._depositAmount = depositAmount;
                               Transaction transaction = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
                                Transaction._accountBalance = accountBalance;
                                

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            } 
            
               
        }

       

        public void CreateWithdrawal(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum)
        {
            if(withdrawalAmount <= Transaction._accountBalance)
            {
             try
            {
                
                Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
                   string  u = $"{transact._refNum}";
                    System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {withdrawalAmount}\n\tFrom: {accountnumber2}\n\tYour balance is: {accountBalance}\n\tDate: {dateTime}");
                    System.Console.Write("Your ref number is:");
                 System.Console.WriteLine(u);
               


                using (var connection = new MySqlConnection(conn))
                {
                    var cus = new Customer(" "," "," "," "," "," "," "," "," "," ");
                    string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum) values ('{Transaction._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{dateTime}','{u}')";
                    connection.Open();
                    using (var command = new MySqlCommand(qur, connection))
                    {
                       var execute = command.ExecuteNonQuery();
                       if(execute > 0)
                        {
                              
                            accountBalance = Transaction._accountBalance;
                            Transaction._accountBalance-=withdrawalAmount;
                            Transaction._withdrawalAmount = withdrawalAmount;
                            //Transaction.listOfTransaction.Add(new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum));
                            Transaction transaction = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
                            
                           // System.Console.WriteLine($"Transaction successful ! \n Your Transaction Reference Number is :{transaction._refNum}");
                            
                               

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            } 
            }
            else
            {
                System.Console.Beep();
                System.Console.WriteLine("Low Balance");
            }
              
           
              
        }

        

        public void DeleteAirtime(string refNum)
        {
            var transaction = GetTransaction(refNum);
            if (transaction != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"delete From Transaction WHERE refNum = '{refNum}'", connection))
                        {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                            {

                                System.Console.WriteLine($"\n\t Transaction of #{Transaction._airtimeAmount} Airtime Successfully deleted. ");
                            }
                           
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void DeleteDeposite(string refNum)
        {
            var transaction = GetTransaction(refNum);
            if (transaction != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"delete From Transaction WHERE refNum = '{refNum}'", connection))
                        {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                            {

                                System.Console.WriteLine($"\n\t Transaction of #{Transaction._airtimeAmount} Deposit Successfully deleted. ");
                            }
                           
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void DeleteWithdrawal(string refNum)
        {
            var transaction = GetTransaction(refNum);
            if (transaction != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"delete From Transaction WHERE refNum = '{refNum}'", connection))
                        {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                            {

                                System.Console.WriteLine($"\n\t Transaction of #{Transaction._airtimeAmount} Withdrawal Successfully deleted. ");
                            }
                           
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
       
    

        public Transaction GetTransaction(string refNum)
        {
            Transaction transaction = null;

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();
                string query = $"select * from Transaction where refNum ='{refNum}'  ";
                using (var command = new MySqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //var i = (double)reader["airtimeAmount"];
                       // transaction = new Transaction($"{reader["firstName"].ToString()}", $"{reader["lastName"].ToString()}", $"{reader["age"].ToString()}", $"{reader["email"].ToString()}", $"{reader["password"].ToString()}", $"{reader["phoneNumber"].ToString()}", $"{reader["address"].ToString()}", $"{reader["gender"].ToString()}",$"{reader["pin"].ToString()}", $"{reader["accountType"].ToString()}",(double)reader["accountBalance"], (double)reader["withdrawalAmount"],(double)reader["depositAmount"], (double)reader["airtimeAmount"],$"{reader["accountNumber"].ToString()}",$"{reader["refNum"].ToString()}",DateTime.Now.ToString("MMM,dd yyyy "));

                    }
                }
            }
            if (transaction != null)
            {
                return transaction;
            }

            return null;

        }

       

        
       

        
    }
}