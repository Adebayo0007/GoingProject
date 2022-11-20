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
        

        

        public void CreateAirtime(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum,string pin)
        {
             var customer = new CustomerManager();
            var test = customer.GetCustomer(accountnumber2);
            if(test._accountType == "Student account")
            {
                if(test._accountBalance  <= 200000)
                {
            
            if(airtimeAmount <= test._accountBalance )
            {

             try
            {
                
                Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum,pin);
                 string  u = $"{transact._refNum}";
                 System.Console.Write("Your ref number is:");
                 System.Console.WriteLine(u);

                using (var connection = new MySqlConnection(conn))
                {
                                test._accountBalance-=airtimeAmount;
                                Transaction._accountBalance = test._accountBalance;
                                var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                cus._accountBalance = test._accountBalance;
                   string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}','{pin}')";
                   string qur2 = $"update customer set accountBalance = {test._accountBalance} where accountNumber = {accountnumber2}";

                   
                    connection.Open();
                   using (var command = new MySqlCommand(qur, connection))
                    {
                       var execute = command.ExecuteNonQuery();
                       if(execute > 0)
                        {
                               
                                System.Console.WriteLine($"Transaction successful ! ");
                                System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {airtimeAmount}\n\tYour balance is: {test._accountBalance}\n\tDate: {dateTime}");

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

                 else
        {
            System.Console.WriteLine("Go to the bank to upgrade your account");
        }
        }
       




            if(test._accountType == "Current account" || test._accountType == "Savings account" || test._accountType == "Business account" || test._accountType == "Joint account")
            {
            
            if(airtimeAmount < test._accountBalance  && test._accountBalance >= 500)
            {

             try
            {
                
                Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum,pin);
                 string  u = $"{transact._refNum}";
                 System.Console.Write("Your ref number is:");
                 System.Console.WriteLine(u);

                using (var connection = new MySqlConnection(conn))
                {
                                test._accountBalance-=airtimeAmount;
                                Transaction._accountBalance = test._accountBalance;
                                var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                cus._accountBalance = test._accountBalance;
                   string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}','{pin}')";
                   string qur2 = $"update customer set accountBalance = {test._accountBalance} where accountNumber = {accountnumber2}";

                   
                    connection.Open();
                   using (var command = new MySqlCommand(qur, connection))
                    {
                       var execute = command.ExecuteNonQuery();
                       if(execute > 0)
                        {
                               
                                System.Console.WriteLine($"Transaction successful ! ");
                                System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {airtimeAmount}\n\tYour balance is: {test._accountBalance}\n\tDate: {dateTime}");

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

        }

       

        public void CreateDeposit(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum,string pin)
        {
             var customer = new CustomerManager();
            var test = customer.GetCustomer(accountnumber2);
            

             try
            {
                
                Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum,pin);
                 string  u = $"{transact._refNum}";
                 System.Console.Write("Your ref number is:");
                 System.Console.WriteLine(u);

                using (var connection = new MySqlConnection(conn))
                {
                                test._accountBalance+=depositAmount;
                                Transaction._depositAmount = depositAmount;
                                var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                cus._accountBalance = test._accountBalance;
                                accountBalance = test._accountBalance;
                   string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}','{pin}')";
                   string qur2 = $"update customer set accountBalance = {test._accountBalance} where accountNumber = {accountnumber2}";

                   
                    connection.Open();
                   using (var command = new MySqlCommand(qur, connection))
                    {
                       var execute = command.ExecuteNonQuery();
                       if(execute > 0)
                        {
                               
                                System.Console.WriteLine($"Transaction successful ! ");
                               System.Console.WriteLine($"\n\tTnx: Credit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {depositAmount}\n\tInto: {accountnumber2}\n\tYour balance is: {test._accountBalance}\n\tDate: {dateTime}");

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

       

        public void CreateWithdrawal(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum,string pin)
        {
            var customer = new CustomerManager();
            var test = customer.GetCustomer(accountnumber2);
            if(test._accountType == "Student account")
            {
                if(test._accountBalance <= 200000)
                {


            if(withdrawalAmount <= test._accountBalance)
            {
                try
                    {
                        
                        Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum,pin);
                        string  u = $"{transact._refNum}";
                        System.Console.Write("Your ref number is:");
                        System.Console.WriteLine(u);

                        using (var connection = new MySqlConnection(conn))
                        {
                                        test._accountBalance-=withdrawalAmount;
                                        Transaction._withdrawalAmount = withdrawalAmount;
                                        var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                        cus._accountBalance = test._accountBalance;
                                        accountBalance = test._accountBalance;
                        string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}','{pin}')";
                        string qur2 = $"update customer set accountBalance = {test._accountBalance} where accountNumber = {accountnumber2}";

                        
                            connection.Open();
                        using (var command = new MySqlCommand(qur, connection))
                            {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                                {
                                    
                                        System.Console.WriteLine($"Transaction successful ! ");
                                    System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {withdrawalAmount}\n\tFrom: {accountnumber2}\n\tYour balance is: {test._accountBalance}\n\tDate: {dateTime}");

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
             else
                {
                    System.Console.WriteLine("Go to the bank to upgrade your account");
                }

        }

       




             if(test._accountType == "Current account" || test._accountType == "Savings account" || test._accountType == "Business account" || test._accountType == "Joint account")
             {
                if(withdrawalAmount < test._accountBalance && test._accountBalance >= 500)
            {
                try
                    {
                        
                        Transaction transact = new Transaction(accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum,pin);
                        string  u = $"{transact._refNum}";
                        System.Console.Write("Your ref number is:");
                        System.Console.WriteLine(u);

                        using (var connection = new MySqlConnection(conn))
                        {
                                        test._accountBalance-=withdrawalAmount;
                                        Transaction._withdrawalAmount = withdrawalAmount;
                                        var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                                        cus._accountBalance = test._accountBalance;
                                        accountBalance = test._accountBalance;
                        string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test._accountBalance}','{Transaction._withdrawalAmount}','{Transaction._depositAmount}','{Transaction._airtimeAmount}','{accountnumber2}','{Transaction._dateTime}','{u}','{pin}')";
                        string qur2 = $"update customer set accountBalance = {test._accountBalance} where accountNumber = {accountnumber2}";

                        
                            connection.Open();
                        using (var command = new MySqlCommand(qur, connection))
                            {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                                {
                                    
                                        System.Console.WriteLine($"Transaction successful ! ");
                                    System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {withdrawalAmount}\n\tFrom: {accountnumber2}\n\tYour balance is: {test._accountBalance}\n\tDate: {dateTime}");

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
                       transaction = new Transaction( (double)reader["accountBalance"], (double)reader["withdrawalAmount"],(double)reader["depositAmount"], (double)reader["airtimeAmount"],$"{reader["accountNumber"].ToString()}",$"{reader["refNum"].ToString()}",DateTime.Now.ToString("MMM,dd yyyy "),$"{reader["pin"].ToString()}");

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