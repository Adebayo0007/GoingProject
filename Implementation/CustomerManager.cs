using System;
using System.Collections.Generic;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;
using System.IO;
namespace LegitBankApp.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        public string _fileDirect = @"C:\Users\user\Desktop\LegitBankApp\File";
        public  string _linkFile1 = "C:\\Users\\user\\Desktop\\LegitBankApp\\File\\CustomerFile.txt";

        public void CreateCustomer(string firstName, string lastName, string age, string email, string password, string phoneNumber, string address, string gender, string pin, string accountType)
        {
           Customer.listOfCustomer.Add(new Customer(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType));
            Customer customer = new Customer(firstName,lastName,age,email,password,phoneNumber,address,gender,pin,accountType);
            System.Console.WriteLine($"<<<<<Your Account Number is : {customer._accountNumber}>>>>>");
            //_data = $"{firstName}^^^{lastName}^^^{age}^^^{email}^^^{password}^^^{phoneNumber}^^^{address}^^^{gender}^^^{ad._staffID}";
               using (StreamWriter streamWriter = new StreamWriter(_linkFile1, append: true))
            {
                streamWriter.WriteLine(customer.WriteToCustomerFile());
            }
        }

        public void DeleteCustomer(string accountNumber)
        {
             var customer = GetCustomer(accountNumber);
            if (customer != null)
            {
                Console.WriteLine($"{customer._firstName} {customer._lastName} Successfully deleted. Thank you ! ");
                Customer.listOfCustomer.Remove(customer);
                ReWriteToCustomerFile();
            }
            else
            {
                Console.Beep();
                Console.WriteLine("User not found.");
            }
        }

        public Customer GetCustomer(string accountNumber)
        {
            foreach (var item in Customer.listOfCustomer)
            {
                if (item._accountNumber == accountNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public Customer Login(string email, string password)
        {
           foreach (var item in Customer.listOfCustomer)
            {
                if (item._email == email.ToUpper() && item._password == password)
                {
                    return item;
                }
            }
            return null;
        }

        public  void ReadFromFileOfCustomer()
        {
            if (!Directory.Exists(_fileDirect)) Directory.CreateDirectory(_fileDirect);

            if (!File.Exists(_linkFile1))
            {
                var fileStream = new FileStream(_linkFile1, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(_linkFile1))
            {
                while (streamReader.Peek() != -1)
                {
                    var customerManager = streamReader.ReadLine();
                    Customer.listOfCustomer.Add(Customer.ConvertToCustomer(customerManager));
                }
            }
        }

        public void WriteToTheListOfCustomer()
        {
            File.WriteAllText(_linkFile1, string.Empty);
            using (var streamWriter = new StreamWriter(_linkFile1, append: true))
            {
                foreach (var item in Customer.listOfCustomer)
                {
                    streamWriter.WriteLine(item.WriteToCustomerFile());
                }
                
            }
        }

        public void UpdateCustomer(string firstName, string lastName, string age, string email, string password, string phoneNumber, string address, string pin, string accountType,string accountNumber)
        {
            var customer = GetCustomer(accountNumber);
            if (customer != null)
            {
                customer._firstName      = firstName;
                customer._lastName       = lastName;
                customer._age            = age;
                customer._email          = email;
                customer._password       = password;
                customer._phoneNumber    = phoneNumber;
                customer._address        = address;
                customer._pin            = pin;
                customer._accountType    = accountType;
              
            }
            else
            {
                Console.Beep();
                Console.WriteLine("User not found.");
            }
        }

        public void ReWriteToCustomerFile()
        {
            File.WriteAllText(_linkFile1, string.Empty);
            using (var streamWriter = new StreamWriter(_linkFile1, append: true))
            {
                foreach (var item in Customer.listOfCustomer)
                {
                    streamWriter.WriteLine(item.WriteToCustomerFile());
                }
            }
        }

        public void ViewCustomers(string accountNumber)
        {
             foreach (var item in Customer.listOfCustomer)
            {
                Console.WriteLine($"{item._firstName}\t{item._lastName}\t{item._email}\t{item._password}\t{item._accountNumber}\t{item._accountType}\t{item._pin}\t{item._address}\t{item._age}");
            }
        }

        public void ViewAllCustomers(string accountNumber)
        {
            foreach (var item in Customer.listOfCustomer)
            {
                Console.WriteLine($"{item._firstName}\t{item._lastName}\t{item._email}\t{item._password}\t{item._accountNumber}\t{item._accountType}\t{item._pin}\t{item._address}\t{item._age}");
            };
        }
    }
}