using System;
using System.Collections.Generic;
namespace LegitBankApp.Model
{
    public class Admin : User
    {
        public string _staffID {get; set;}
       // public int _adminRegNum {get;set;}
        // public static List<Admin> listOfAdmins = new List<Admin>();


        public Admin(string firstName,string lastName,string age,string email,string password,string phoneNumber,string address,string gender): base (firstName,lastName,age,email,password,phoneNumber,address,gender)       
         {
            this._staffID      = GenerateStaffID();
            //this._adminRegNum  = listOfAdmins.Count == 0 ? 1 : listOfAdmins.Count + 1; 
            this._firstName    = firstName;
            this._lastName     = lastName;
            this._age          = age;
            this._email        = email;
            this._password     = password;
            this._phoneNumber  = phoneNumber;
            this._address      = address;
            this._gender       = gender;
            
         }


        public string GenerateStaffID()
            {
                var rand = new Random();
                string id = "ZENITH/ADMIN-"+rand.Next(100, 500).ToString()+"/" +_firstName[0]+_firstName[1]+_firstName[2]+rand.Next(0,9).ToString() ;
                return id;

            }

        public string WriteToFIle()
            {
                return $"{_firstName}^^^{_lastName}^^^{_email.ToUpper()}^^^{_password}^^^{_phoneNumber}^^^{_address}^^^{_gender}^^^{_staffID}";
            }

        public static Admin ConvertToAdmin(string adminDataFromText)
        {
            var adminConvert = adminDataFromText.Split("^^^");
            return new Admin(adminConvert[0], adminConvert[1], adminConvert[2], adminConvert[3], adminConvert[4], adminConvert[5], adminConvert[6], adminConvert[7]);
        }


    }
}