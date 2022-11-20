using System;
using System.Collections.Generic;
using LegitBankApp.Model;
namespace LegitBankApp.Interfaces
{
    public interface ITransactionManager
    {

        void CreateWithdrawal (double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber2,string dateTime,string refNum,string pin);
        void CreateDeposit (double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber2,string dateTime,string refNum,string pin);
        void CreateAirtime (double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber2,string dateTime,string refNum,string pin);
        void DeleteTransaction (string refNum);
        Transaction GetTransaction (string refNum);
        
             
    }
}