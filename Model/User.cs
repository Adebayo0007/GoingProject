namespace LegitBankApp.Model
{
    public class User
    {
        public string _firstName {get;set;}
        public string _lastName{get;set;}
        public string _age        {get;set;}
        public string _email      {get;set;}
        public string _password   {get;set;}
        public string _phoneNumber{get;set;}
        public string _address    {get;set;}
        public string _gender     {get;set;}

        public User(string firstName,string lastName,string age,string email,string password,string phoneNumber,string address,string gender)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._age        = age;
            this._email      = email;
            this._password   = password;
            this._phoneNumber =phoneNumber;
            this._address     = address;
            this._gender      = gender;
        }


    }

}
