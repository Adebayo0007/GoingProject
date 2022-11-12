using System;
using System.Collections.Generic;
using LegitBankApp.Model;
namespace LegitBankApp
{
    public class Transaction : Customer 
    {
        public static double _accountBalance   =5000;
        public static double _withdrawalAmount {get; set;}
        public static double _depositAmount    {get; set;}
        public static double _airtimeAmount    {get; set;}
        public static string _accountnumber    {get; set;}
        public static string _dateTime       {get; set;}
        public  string _refNum                    {get; set;}
        public static List<Transaction> listOfTransaction = new List<Transaction>();

        public Transaction(string firstName,string lastName,string age,string email,string password,string phoneNumber,string address,string gender,string pin,string accountType,double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber1,string dateTime,string refNum) : base (firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType)
         {
            this._firstName = firstName;
            this._lastName  = lastName;
            this._age       = age;
            this._email     = email;
            this._password  = password;
            this._phoneNumber= phoneNumber;
            this._address    = address;
            this._gender     = gender;
            this._pin        = pin;
            this._accountType= accountType;
            
            Transaction._accountBalance = accountBalance;
            Transaction._withdrawalAmount = withdrawalAmount;
            Transaction._depositAmount = depositAmount;
            Transaction._airtimeAmount = airtimeAmount;
            Transaction._dateTime      = dateTime;
            Transaction._accountnumber = accountnumber1;
            this._refNum        = (listOfTransaction.Count == 0? 1 : listOfTransaction.Count +1).ToString() ;
            refNum = this._refNum;

            
         }

          public string WriteToTransactionFIle()
        {
            return $"{_firstName}^^^{_lastName}^^^{_age}^^^{_email.ToUpper()}^^^{_password.ToUpper()}^^^{_phoneNumber}^^^{_address}^^^{_gender}^^^{_pin}^^^{_accountType}^^^{_accountBalance}^^^{_withdrawalAmount}^^^{_depositAmount}^^^{_airtimeAmount}^^^{_accountNumber}^^^{_dateTime}^^^{_refNum}";
        }
        

        public static Transaction ConvertToTransaction(string transactionDatalFromText)
        {
            var transactionConvert = transactionDatalFromText.Split("^^^");
            return new Transaction(transactionConvert[0], transactionConvert[1], transactionConvert[2], transactionConvert[3], transactionConvert[4], transactionConvert[5], transactionConvert[6], transactionConvert[7], transactionConvert[8],transactionConvert[9],double.Parse(transactionConvert[10]),double.Parse(transactionConvert[11]),double.Parse(transactionConvert[12]),double.Parse(transactionConvert[13]),transactionConvert[14],transactionConvert[15],transactionConvert[16]);
        }

    }
}