using System;
using System.Collections.Generic;
using LegitBankApp.Model;
namespace LegitBankApp
{
    public class Transaction 
    {
        public static double _accountBalance   {set; get;}
        public static double _withdrawalAmount {get; set;}
        public static double _depositAmount    {get; set;}
        public static double _airtimeAmount    {get; set;}
        public static string _accountnumber    {get; set;}
        public static string _dateTime         {get; set;}
        public static double _transferAmount {get; set;}
        public  string _refNum                 {get; set;}
         public  static string _pin             {get; set;}
        
        public Transaction(double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,double transferAmount,string accountnumber1,string dateTime,string refNum,string pin) 
         {
           
            
            Transaction._accountBalance = accountBalance;
            Transaction._withdrawalAmount = withdrawalAmount;
            Transaction._depositAmount = depositAmount;
            Transaction._airtimeAmount = airtimeAmount;
            Transaction._dateTime      = dateTime;
            Transaction._accountnumber = accountnumber1;
            Transaction._transferAmount = transferAmount;
            Transaction._pin = pin;
            refNum = this._refNum;
            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
            var i = new Random().Next(25);
             var j = new Random().Next(25);
              var k = new Random().Next(25,99);
            this._refNum        = $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
          

            
         }

    }
}