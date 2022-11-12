using System;
using System.Collections.Generic;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;
using System.IO;
namespace LegitBankApp.Implementations
{
    public class TransactionManager : ITransactionManager
    {
        public string _transactionFilePath = @"C:\Users\user\Desktop\LegitBankApp\File\TransactionFile.txt";

        

        public void CreateAirtime(string firstName, string lastName, string age, string email, string password, string phoneNumber, string address, string gender, string pin, string accountType, double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum)
        {
            
            
            accountBalance = Transaction._accountBalance;
            accountBalance-=airtimeAmount;
            airtimeAmount = Transaction._airtimeAmount;
            Transaction.listOfTransaction.Add(new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum));
            Transaction transaction = new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
            Transaction._accountBalance = accountBalance;
            System.Console.WriteLine($"Transaction successful ! \n Your Transaction Reference Number is :{transaction._refNum}");
               using (StreamWriter streamWriter = new StreamWriter(_transactionFilePath, append: true))
            {
                streamWriter.WriteLine(transaction.WriteToTransactionFIle());
            }
        }

       

        public void CreateDeposit(string firstName, string lastName, string age, string email, string password, string phoneNumber, string address, string gender, string pin, string accountType, double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum)
        {
            
           
            accountBalance = Transaction._accountBalance;
            accountBalance+=depositAmount;
            Transaction._depositAmount = depositAmount;
            Transaction.listOfTransaction.Add(new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum));
            Transaction transaction = new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
            Transaction._accountBalance = accountBalance;
            System.Console.WriteLine($"Transaction successful ! \n Your Transaction Reference Number is :{transaction._refNum}");
               using (StreamWriter streamWriter = new StreamWriter(_transactionFilePath, append: true))
            {
                streamWriter.WriteLine(transaction.WriteToTransactionFIle());
            }
        }

       

        public void CreateWithdrawal(string firstName, string lastName, string age, string email, string password, string phoneNumber, string address, string gender, string pin, string accountType, double accountBalance, double withdrawalAmount, double depositAmount, double airtimeAmount, string accountnumber2, string dateTime,string refNum)
        {
            
           
            accountBalance = Transaction._accountBalance;
            Transaction._accountBalance-=withdrawalAmount;
            Transaction._withdrawalAmount = withdrawalAmount;
            Transaction.listOfTransaction.Add(new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum));
            Transaction transaction = new Transaction(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType,accountBalance,withdrawalAmount,depositAmount,airtimeAmount,accountnumber2,dateTime,refNum);
            //Transaction._accountBalance = accountBalance;
            System.Console.WriteLine($"Transaction successful ! \n Your Transaction Reference Number is :{transaction._refNum}");
               using (StreamWriter streamWriter = new StreamWriter(_transactionFilePath, append: true))
            {
                streamWriter.WriteLine(transaction.WriteToTransactionFIle());
            }
        }

        

        public void DeleteAirtime()
        {
            System.Console.WriteLine("Enter your ref number to delete transaction");
            string refNum = Console.ReadLine();
            var transaction = GetTransaction(refNum);
            if (transaction != null)
            {
                Console.WriteLine($"Mr/Mrs {transaction._firstName} {transaction._lastName} your airtime of #{Transaction._airtimeAmount} have been reversed. ");
                Transaction._accountBalance+=Transaction._airtimeAmount;
                Transaction.listOfCustomer.Remove(transaction);
                ReWriteToTransactionFile();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("User not found.");
            }
        }

        public void DeleteDeposite()
        {
            System.Console.WriteLine("Enter your ref number to delete transaction");
            string refNum = Console.ReadLine();
            var transaction = GetTransaction(refNum);
            if (transaction != null)
            {
                Console.WriteLine($"Mr/Mrs {transaction._firstName} {transaction._lastName} your deposite of  #{Transaction._depositAmount} have been reversed. ");
                Transaction._accountBalance+=Transaction._depositAmount;
                Transaction.listOfCustomer.Remove(transaction);
                ReWriteToTransactionFile();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("User not found.");
            }
        }

        public void DeleteWithdrawal()
        {
            System.Console.WriteLine("Enter your ref number to delete transaction");
            string refNum = Console.ReadLine();
             var transaction = GetTransaction(refNum);
            if (transaction != null)
            {
                Console.WriteLine($"Mr/Mrs {transaction._firstName} {transaction._lastName} your your withdrawal of  #{Transaction._depositAmount} have been reversed.  {Transaction._dateTime}. ");
                Transaction._accountBalance+=Transaction._withdrawalAmount;
                Transaction.listOfCustomer.Remove(transaction);
                ReWriteToTransactionFile();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("User not found.");
            }
        }
       
    

        public Transaction GetTransaction(string refNum)
        {
            foreach (var item in Transaction.listOfTransaction)
            {
                if (item._refNum == refNum)
                {
                    return item;
                }
            }
            return null;
        }

        public void ReadFromFileOfTransaction()
        {
            if (!Directory.Exists(_transactionFilePath)) Directory.CreateDirectory(_transactionFilePath);

            if (!File.Exists(_transactionFilePath))
            {
                var fileStream = new FileStream(_transactionFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(_transactionFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var transactionManager = streamReader.ReadLine();
                    Transaction.listOfTransaction.Add(Transaction.ConvertToTransaction(transactionManager));
                }
            }
        }

        public void ReadFromTheListOfTransaction()
        {
            File.WriteAllText(_transactionFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(_transactionFilePath, append: true))
            {
                foreach (var item in Transaction.listOfTransaction)
                {
                    streamWriter.WriteLine(item.WriteToTransactionFIle());
                }
                
            }
        }

        public void ReWriteToTransactionFile()
        {
           
            File.WriteAllText(_transactionFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(_transactionFilePath, append: true))
            {
                foreach (var item in Transaction.listOfTransaction)
                {
                    streamWriter.WriteLine(item.WriteToCustomerFile());
                }
            }
        
        }

        
    }
}