using System;
namespace LegitBankApp.Model
{
    public class ManagingDirector 
    {
        public string _firstName {get; set;}
        public string _lastName {get; set;}
        public string _age     {get; set;}
        public string _phoneNumber  {get; set;}
        public string _managerId   {get; set;}

        public ManagingDirector(string firstName,string lastName,string age,string phoneNumber)
        {
            this._firstName   = firstName;
            this._lastName    = lastName;
            this._age         = age;
            this._phoneNumber = phoneNumber;
            this._managerId   = GenerateManagerID();
        }

         public string GenerateManagerID()
            {
                var rand = new Random();
                string id = "ZENITH/MANAGER-"+rand.Next(100, 500).ToString()+"/" +_firstName[0]+_firstName[1]+_firstName[0]+"0" ;
                return id;

            }
    }
    
}