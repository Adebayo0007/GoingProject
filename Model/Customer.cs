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
        public static List<Customer> listOfCustomer = new List<Customer>();

        public Customer(string firstName,string lastName,string age,string email,string password,string phoneNumber,string address,string gender,string pin,string accountType) : base (firstName,lastName,age,email,password,phoneNumber,address,gender)
        {
            this._accountNumber = GenerateCustomerAcountNumber();
            this._pin = pin;
            this._accountType = accountType;
            this._customerRegNum = listOfCustomer.Count == 0 ? 1 : listOfCustomer.Count + 1;   
            this._firstName = firstName;
            this._lastName = lastName;
            this._age = age;
            this._email = email;
            this._password = password;
            this._accountNumber = phoneNumber;
            this._address = address;
            this._gender = gender;
            this._accountType = accountType;
        }

    

        public string GenerateCustomerAcountNumber()
            {
                Random random = new Random();
                string preTest =_customerRegNum.ToString();
                string customerAccountNumber = $"{random.Next(300,700)}{random.Next(100, 900).ToString()}00{_pin[3]}0";
                return customerAccountNumber;

            }

            public  string WriteToCustomerFile()
            {
                return $"{_firstName}^^^{_lastName}^^^{_age}^^^{_email.ToUpper()}^^^{_password}^^^{_phoneNumber}^^^{_address}^^^{_gender}^^^{_pin}^^^{_accountType}";
            }

        public static Customer ConvertToCustomer(string customerDataFromText)
        {
            var customerConvert = customerDataFromText.Split("^^^");
            return new Customer(customerConvert[0], customerConvert[1], customerConvert[2], customerConvert[3], customerConvert[4], customerConvert[5], customerConvert[6], customerConvert[7], customerConvert[8], customerConvert[9]);
        }
    

    }
}