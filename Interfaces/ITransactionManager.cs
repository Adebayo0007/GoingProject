using System;
using System.Collections.Generic;
using LegitBankApp.Model;
namespace LegitBankApp.Interfaces
{
    public interface ITransactionManager
    {

        void CreateWithdrawal (string firstName,string lastName,string age,string email, string password,string phoneNumber,string address,string gender, string pin, string accountType,double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber2,string dateTime,string refNum);
        void CreateDeposit (string firstName,string lastName,string age,string email, string password,string phoneNumber,string address,string gender, string pin, string accountType,double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber2,string dateTime,string refNum);
        void CreateAirtime (string firstName,string lastName,string age,string email, string password,string phoneNumber,string address,string gender, string pin, string accountType,double accountBalance,double withdrawalAmount,double depositAmount,double airtimeAmount,string accountnumber2,string dateTime,string refNum);
        void DeleteWithdrawal ();
        void DeleteDeposite ();
        void DeleteAirtime ();
        Transaction GetTransaction (string refNum);
        void ReadFromTheListOfTransaction();
        void ReadFromFileOfTransaction();
        void ReWriteToTransactionFile();
             
    }
}