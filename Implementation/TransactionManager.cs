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




        public void CreateAirtime(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount,double transferAmount,string accountnumber2, string dateTime, string refNum, string pin)
        {
            var customer = new CustomerManager();
            var test = customer.GetCustomer(accountnumber2);
            if (test.accountType == "Student account")
            {
                if (test.accountBalance <= 200000)
                {

                    if (airtimeAmount <= test.accountBalance)
                    {

                        try
                        {

                            Transaction transact = new Transaction(accountBalance, withdrawalAmount, depositAmount, airtimeAmount,transferAmount, accountnumber2, dateTime, refNum, pin);
                            string u = $"{transact.refNum}";
                            System.Console.Write("Your ref number is:");
                            System.Console.WriteLine(u);

                            using (var connection = new MySqlConnection(conn))
                            {
                                test.accountBalance -= airtimeAmount;
                                Transaction.accountBalance = test.accountBalance;
                                var cus = new Customer(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", 0);
                                cus.accountBalance = test.accountBalance;
                                string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test.accountBalance}','{Transaction.withdrawalAmount}','{Transaction.depositAmount}','{Transaction.airtimeAmount}','{accountnumber2}','{Transaction.dateTime}','{u}','{pin}')";
                                string qur2 = $"update customer set accountBalance = {test.accountBalance} where accountNumber = {accountnumber2}";


                                connection.Open();
                                using (var command = new MySqlCommand(qur, connection))
                                {
                                    var execute = command.ExecuteNonQuery();
                                    if (execute > 0)
                                    {

                                        System.Console.WriteLine($"Transaction successful ! ");
                                        System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {airtimeAmount}\n\tYour balance is: {test.accountBalance}\n\tDate: {dateTime}");

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





            if (test.accountType == "Current account" || test.accountType == "Savings account" || test.accountType == "Business account" || test.accountType == "Joint account")
            {

                if (airtimeAmount < test.accountBalance && test.accountBalance >= 500)
                {

                    try
                    {

                        Transaction transact = new Transaction(accountBalance, withdrawalAmount, depositAmount, airtimeAmount,transferAmount,accountnumber2, dateTime, refNum, pin);
                        string u = $"{transact.refNum}";
                        System.Console.Write("Your ref number is:");
                        System.Console.WriteLine(u);

                        using (var connection = new MySqlConnection(conn))
                        {
                            test.accountBalance -= airtimeAmount;
                            Transaction.accountBalance = test.accountBalance;
                            var cus = new Customer(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", 0);
                            cus.accountBalance = test.accountBalance;
                            string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test.accountBalance}','{Transaction.withdrawalAmount}','{Transaction.depositAmount}','{Transaction.airtimeAmount}','{accountnumber2}','{Transaction.dateTime}','{u}','{pin}')";
                            string qur2 = $"update customer set accountBalance = {test.accountBalance} where accountNumber = {accountnumber2}";


                            connection.Open();
                            using (var command = new MySqlCommand(qur, connection))
                            {
                                var execute = command.ExecuteNonQuery();
                                if (execute > 0)
                                {

                                    System.Console.WriteLine($"Transaction successful ! ");
                                    System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {airtimeAmount}\n\tYour balance is: {test.accountBalance}\n\tDate: {dateTime}");

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



        public void CreateDeposit(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount,double transferAmount,string accountnumber2, string dateTime, string refNum, string pin)
        {
            var customer = new CustomerManager();
            var test = customer.GetCustomer(accountnumber2);


            try
            {

                Transaction transact = new Transaction(accountBalance, withdrawalAmount, depositAmount, airtimeAmount,transferAmount,accountnumber2, dateTime, refNum, pin);
                string u = $"{transact.refNum}";
                System.Console.Write("Your ref number is:");
                System.Console.WriteLine(u);

                using (var connection = new MySqlConnection(conn))
                {
                    test.accountBalance += depositAmount;
                    Transaction.depositAmount = depositAmount;
                    var cus = new Customer(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", 0);
                    cus.accountBalance = test.accountBalance;
                    accountBalance = test.accountBalance;
                    string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test.accountBalance}','{Transaction.withdrawalAmount}','{Transaction.depositAmount}','{Transaction.airtimeAmount}','{accountnumber2}','{Transaction.dateTime}','{u}','{pin}')";
                    string qur2 = $"update customer set accountBalance = {test.accountBalance} where accountNumber = {accountnumber2}";


                    connection.Open();
                    using (var command = new MySqlCommand(qur, connection))
                    {
                        var execute = command.ExecuteNonQuery();
                        if (execute > 0)
                        {

                            System.Console.WriteLine($"Transaction successful ! ");
                            System.Console.WriteLine($"\n\tTnx: Credit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {depositAmount}\n\tInto: {accountnumber2}\n\tYour balance is: {test.accountBalance}\n\tDate: {dateTime}");

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



        public void CreateWithdrawal(double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount,double transferAmount,string accountnumber2, string dateTime, string refNum, string pin)
        {
            var customer = new CustomerManager();
            var test = customer.GetCustomer(accountnumber2);
            if (test.accountType == "Student account")
            {
                if (test.accountBalance <= 200000)
                {


                    if (withdrawalAmount <= test.accountBalance)
                    {
                        try
                        {

                            Transaction transact = new Transaction(accountBalance, withdrawalAmount, depositAmount, airtimeAmount,transferAmount,accountnumber2, dateTime, refNum, pin);
                            string u = $"{transact.refNum}";
                            System.Console.Write("Your ref number is:");
                            System.Console.WriteLine(u);

                            using (var connection = new MySqlConnection(conn))
                            {
                                test.accountBalance -= withdrawalAmount;
                                Transaction.withdrawalAmount = withdrawalAmount;
                                var cus = new Customer(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", 0);
                                cus.accountBalance = test.accountBalance;
                                accountBalance = test.accountBalance;
                                string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test.accountBalance}','{Transaction.withdrawalAmount}','{Transaction.depositAmount}','{Transaction.airtimeAmount}','{accountnumber2}','{Transaction.dateTime}','{u}','{pin}')";
                                string qur2 = $"update customer set accountBalance = {test.accountBalance} where accountNumber = {accountnumber2}";


                                connection.Open();
                                using (var command = new MySqlCommand(qur, connection))
                                {
                                    var execute = command.ExecuteNonQuery();
                                    if (execute > 0)
                                    {

                                        System.Console.WriteLine($"Transaction successful ! ");
                                        System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {withdrawalAmount}\n\tFrom: {accountnumber2}\n\tYour balance is: {test.accountBalance}\n\tDate: {dateTime}");

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






            if (test.accountType == "Current account" || test.accountType == "Savings account" || test.accountType == "Business account" || test.accountType == "Joint account")
            {
                if (withdrawalAmount < test.accountBalance && test.accountBalance >= 500)
                {
                    try
                    {

                        Transaction transact = new Transaction(accountBalance, withdrawalAmount, depositAmount, airtimeAmount,transferAmount,accountnumber2, dateTime, refNum, pin);
                        string u = $"{transact.refNum}";
                        System.Console.Write("Your ref number is:");
                        System.Console.WriteLine(u);

                        using (var connection = new MySqlConnection(conn))
                        {
                            test.accountBalance -= withdrawalAmount;
                            Transaction.withdrawalAmount = withdrawalAmount;
                            var cus = new Customer(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", 0);
                            cus.accountBalance = test.accountBalance;
                            accountBalance = test.accountBalance;
                            string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin) values ('{test.accountBalance}','{Transaction.withdrawalAmount}','{Transaction.depositAmount}','{Transaction.airtimeAmount}','{accountnumber2}','{Transaction.dateTime}','{u}','{pin}')";
                            string qur2 = $"update customer set accountBalance = {test.accountBalance} where accountNumber = {accountnumber2}";


                            connection.Open();
                            using (var command = new MySqlCommand(qur, connection))
                            {
                                var execute = command.ExecuteNonQuery();
                                if (execute > 0)
                                {

                                    System.Console.WriteLine($"Transaction successful ! ");
                                    System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {accountnumber2[0]}{accountnumber2[1]}*****{accountnumber2[7]}{accountnumber2[8]}*\n\tAmt: NGN {withdrawalAmount}\n\tFrom: {accountnumber2}\n\tYour balance is: {test.accountBalance}\n\tDate: {dateTime}");

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



        public void Transfer (double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,double transferAmount,string senderAccountnumber,string recieverAccountnumber,string dateTime,string refNum,string pin)
        {

             var customer = new CustomerManager();
            var test = customer.GetCustomer(senderAccountnumber);
            var test1 = customer.GetCustomer(recieverAccountnumber);
            if (test.accountType == "Student account")
            {
                if (test.accountBalance <= 200000)
                {

                    if (airtimeAmount <= test.accountBalance)
                    {

                        try
                        {

                            Transaction transact = new Transaction(accountBalance, withdrawalAmount, depositAmount, airtimeAmount,transferAmount, senderAccountnumber, dateTime, refNum, pin);
                            string u = $"{transact.refNum}";
                            System.Console.Write("Your ref number is:");
                            System.Console.WriteLine(u);

                            using (var connection = new MySqlConnection(conn))
                            {
                                test.accountBalance -= transferAmount;
                                Transaction.accountBalance = test.accountBalance;
                                var cus = new Customer(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", 0);
                                cus.accountBalance = test.accountBalance;
                                string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin,transferAmount) values ('{test.accountBalance}','{Transaction.withdrawalAmount}','{Transaction.depositAmount}','{Transaction.airtimeAmount}','{senderAccountnumber}','{Transaction.dateTime}','{u}','{pin}','{transferAmount}')";
                                string qur2 = $"update customer set accountBalance = {test.accountBalance} where accountNumber = {senderAccountnumber}";
                                string qur3 = $"update customer set accountBalance = {test1.accountBalance+=transferAmount} where accountNumber = {recieverAccountnumber}";


                                connection.Open();
                                using (var command = new MySqlCommand(qur, connection))
                                {
                                    var execute = command.ExecuteNonQuery();
                                    if (execute > 0)
                                    {

                                        System.Console.WriteLine($"Transaction successful ! ");
                                        System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {senderAccountnumber[0]}{senderAccountnumber[1]}*****{senderAccountnumber[7]}{senderAccountnumber[8]}*\n\tAmt: NGN {transferAmount}\n\tYour balance is: {test.accountBalance}\n\tDate: {dateTime}");

                                    }
                                }

                                using (var command = new MySqlCommand(qur2, connection))
                                {
                                    var execute = command.ExecuteNonQuery();
                                }
                                using (var command = new MySqlCommand(qur3, connection))
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





            if (test.accountType == "Current account" || test.accountType == "Savings account" || test.accountType == "Business account" || test.accountType == "Joint account")
            {

                if (airtimeAmount < test.accountBalance && test.accountBalance >= 500)
                {

                    try
                    {

                        Transaction transact = new Transaction(accountBalance, withdrawalAmount, depositAmount, airtimeAmount,transferAmount,senderAccountnumber, dateTime, refNum, pin);
                        string u = $"{transact.refNum}";
                        System.Console.Write("Your ref number is:");
                        System.Console.WriteLine(u);

                        using (var connection = new MySqlConnection(conn))
                        {
                            test.accountBalance -= transferAmount;
                            Transaction.accountBalance = test.accountBalance;
                            var cus = new Customer(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", 0);
                            cus.accountBalance = test.accountBalance;
                            string qur = $"insert into Transaction (accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountNumber,time,refNum,pin,transferAmount) values ('{test.accountBalance}','{Transaction.withdrawalAmount}','{Transaction.depositAmount}','{Transaction.airtimeAmount}','{senderAccountnumber}','{Transaction.dateTime}','{u}','{pin}','{transferAmount}')";
                                string qur2 = $"update customer set accountBalance = {test.accountBalance} where accountNumber = {senderAccountnumber}";
                                string qur3 = $"update customer set accountBalance = {test1.accountBalance+=transferAmount} where accountNumber = {recieverAccountnumber}";


                            connection.Open();
                            using (var command = new MySqlCommand(qur, connection))
                            {
                                var execute = command.ExecuteNonQuery();
                                if (execute > 0)
                                {

                                    System.Console.WriteLine($"Transaction successful ! ");
                                    System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {senderAccountnumber[0]}{senderAccountnumber[1]}*****{senderAccountnumber[7]}{senderAccountnumber[8]}*\n\tAmt: NGN {transferAmount}\n\tYour balance is: {test.accountBalance}\n\tDate: {dateTime}");

                                }
                            }

                            using (var command = new MySqlCommand(qur2, connection))
                            {
                                var execute = command.ExecuteNonQuery();
                            }
                            using (var command = new MySqlCommand(qur3, connection))
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
                            if (execute > 0)
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
                        transaction = new Transaction((double)reader["accountBalance"], (double)reader["withdrawalAmount"], (double)reader["depositAmount"], (double)reader["airtimeAmount"],(double)reader["transferAmount"], $"{reader["accountNumber"].ToString()}", $"{reader["refNum"].ToString()}", DateTime.Now.ToString("MMM,dd yyyy "), $"{reader["pin"].ToString()}");

                    }
                }
            }
            if (transaction != null)
            {
                return transaction;
            }

            return null;

        }


        public Transaction GetTransactionFronSql()
        {
            Transaction transaction = null;

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();
                string query = $"select * from Transaction  ";
                using (var command = new MySqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        System.Console.WriteLine($"{reader["accountBalance"]}\t\t{reader["withdrawalAmount"]}\t\t{reader["depositAmount"]}\t\t{reader["airtimeAmount"]}\t\t{reader["accountNumber"].ToString()}\t\t{reader["refNum"].ToString()}\t\t{reader["time"].ToString()}\t{reader["pin"].ToString()}\t{reader["transferAmount"]}");

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