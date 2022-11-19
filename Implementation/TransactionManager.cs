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

                using (var connection = new MySqlConnection(conn))
                {
                               accountBalance = Transaction._accountBalance;
                                accountBalance-=airtimeAmount;
                              //Transaction transaction = new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
                                Transaction._accountBalance = accountBalance;
                                var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                cus._accountBalance = Transaction._accountBalance;
                   string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum) values ('{accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}')";
                   string qur2 = $"update customer set accountBalance = {accountBalance}";

                   
                    connection.Open();
                   using (var command = new MySqlCommand(qur, connection))
                    {
                       var execute = command.ExecuteNonQuery();
                       if(execute > 0)
                        {
                               
                                System.Console.WriteLine($"Transaction successful ! ");
                                System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {airtimeAmount}\n\tYour balance is: {accountBalance}\n\tDate: {dateTime}");

                        }
                    }

                     using (var command = new MySqlCommand(qur2, connection))
                    {
                       var execute = command.ExecuteNonQuery();
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

                using (var connection = new MySqlConnection(conn))
                {
                              accountBalance = Transaction._accountBalance;
                                accountBalance+=depositAmount;
                                Transaction._depositAmount = depositAmount;
                                var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                cus._accountBalance = Transaction._accountBalance;
                   string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum) values ('{accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}')";
                   string qur2 = $"update customer set accountBalance = {accountBalance}";

                   
                    connection.Open();
                   using (var command = new MySqlCommand(qur, connection))
                    {
                       var execute = command.ExecuteNonQuery();
                       if(execute > 0)
                        {
                               
                                System.Console.WriteLine($"Transaction successful ! ");
                               System.Console.WriteLine($"\n\tTnx: Credit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {depositAmount}\n\tYour balance is: {accountBalance}\n\tDate: {dateTime}");

                        }
                    }

                     using (var command = new MySqlCommand(qur2, connection))
                    {
                       var execute = command.ExecuteNonQuery();
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
                        System.Console.Write("Your ref number is:");
                        System.Console.WriteLine(u);

                        using (var connection = new MySqlConnection(conn))
                        {
                            
                                    accountBalance = Transaction._accountBalance;
                                        accountBalance-=withdrawalAmount;
                                        Transaction._withdrawalAmount = withdrawalAmount;
                                        var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                        cus._accountBalance = Transaction._accountBalance;
                        string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum) values ('{accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}')";
                        string qur2 = $"update customer set accountBalance = {accountBalance}";

                        
                            connection.Open();
                        using (var command = new MySqlCommand(qur, connection))
                            {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                                {
                                    
                                        System.Console.WriteLine($"Transaction successful ! ");
                                    System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {withdrawalAmount}\n\tFrom: {accountnumber2}\n\tYour balance is: {accountBalance}\n\tDate: {dateTime}");

                                }
                            }

                            using (var command = new MySqlCommand(qur2, connection))
                            {
                            var execute = command.ExecuteNonQuery();
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

        

    

        public void DeleteTransaction(string refNum)
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

                                System.Console.WriteLine($"\n\t Transaction Successfully deleted. ");
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
                       transaction = new Transaction( (double)reader["accountBalance"], (double)reader["withdrawalAmount"],(double)reader["depositAmount"], (double)reader["airtimeAmount"],$"{reader["accountNumber"].ToString()}",$"{reader["refNum"].ToString()}",DateTime.Now.ToString("MMM,dd yyyy "));

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