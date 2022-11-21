using System;
using System.Collections.Generic;
namespace LegitBankApp.Model
{
    public class Customer : User 
    {
        public string _accountNumber {get; set;}
        public string _pin           {get; set;}
        public string _accountType   {get; set;}
        public int _customerRegNum   {get; set;}
        public double _accountBalance {get; set;}

        public Customer(string firstName,string lastName,string age,string email,string password,string phoneNumber,string address,string gender,string pin,string accountType,double accountBalance) : base (firstName,lastName,age,email,password,phoneNumber,address,gender)
        {
            this._accountNumber = GenerateCustomerAcountNumber();
            this._pin = pin;
            this._accountType = accountType; 
            this._firstName = firstName;
            this._lastName = lastName;
            this._age = age;
            this._email = email;
            this._password = password;
            this._address = address;
            this._gender = gender;
            this._accountType = accountType;
            this._accountBalance = accountBalance;
        }

    

        public string GenerateCustomerAcountNumber()
            {
                Random random = new Random();
                Random rand = new Random();
                string preTest =_customerRegNum.ToString();
                string customerAccountNumber = $"{random.Next(300,700).ToString()}{random.Next(100, 900).ToString()}{rand.Next(100,400).ToString()}0";
                return customerAccountNumber;

            }

       
    

    }
}