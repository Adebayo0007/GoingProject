using System;
using System.Collections.Generic;
namespace LegitBankApp.Model
{
    public class Admin : User
    {
        public string _staffID {get; set;}
    
        public Admin(string firstName,string lastName,string age,string email,string password,string phoneNumber,string address,string gender): base (firstName,lastName,age,email,password,phoneNumber,address,gender)       
         {
            this._staffID      = GenerateStaffID();
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
                string id = "ZENITH/ADMIN-"+rand.Next(0, 9).ToString()+rand.Next(50, 99).ToString()+"/" +_firstName[0]+_firstName[1]+_firstName[2]+rand.Next(0,9).ToString() ;
                return id;

            }

       


    }
}