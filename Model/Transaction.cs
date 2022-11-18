using System;
using System.Collections.Generic;
using LegitBankApp.Model;
namespace LegitBankApp
{
    public class Transaction 
    {
        public static double _accountBalance   =5000;
        public static double _withdrawalAmount {get; set;}
        public static double _depositAmount    {get; set;}
        public static double _airtimeAmount    {get; set;}
        public static string _accountnumber    {get; set;}
        public static string _dateTime         {get; set;}
        public  string _refNum                 {get; set;}
        public static List<Transaction> listOfTransaction = new List<Transaction>();

        public Transaction(double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber1,string dateTime,string refNum) 
         {
           
            
            Transaction._accountBalance = accountBalance;
            Transaction._withdrawalAmount = withdrawalAmount;
            Transaction._depositAmount = depositAmount;
            Transaction._airtimeAmount = airtimeAmount;
            Transaction._dateTime      = dateTime;
            Transaction._accountnumber = accountnumber1;
            string x = (listOfTransaction.Count == 0? 1 : listOfTransaction.Count +1).ToString();
            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
            var i = new Random().Next(25);
             var j = new Random().Next(25);
            this._refNum        = $"Ref00{i}{j}{alpha[i]}{alpha[j]}" ;
            refNum = this._refNum;

            
         }

    }
}