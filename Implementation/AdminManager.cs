using System;
using System.Collections.Generic;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;
using System.IO;
namespace LegitBankApp.Implementations
{
    public class AdminManager : IAdminManager
    {
        public string _fileDirect = @"C:\Users\user\Desktop\LegitBankApp\File";
        public  string _linkFile = "C:\\Users\\user\\Desktop\\LegitBankApp\\File\\AdminFile.txt";
        public string _data {get; set;}

       public void CreateAdmin (string firstName,string lastName,string age,string email,string password,string phoneNumber,string address,string gender)
       {
        Admin.listOfAdmins.Add(new Admin(firstName,lastName,age,email,password,phoneNumber,address,gender));
            Admin ad = new Admin(firstName,lastName,age,email,password,phoneNumber,address,gender);
            System.Console.WriteLine($"Your ID number is: {ad._staffID}");
            //_data = $"{firstName}^^^{lastName}^^^{age}^^^{email}^^^{password}^^^{phoneNumber}^^^{address}^^^{gender}^^^{ad._staffID}";
               using (StreamWriter streamWriter = new StreamWriter(_linkFile, append: true))
            {
                streamWriter.WriteLine(ad.WriteToFIle());
            }

       }

       public void UpdateAdmin (string firstName, string lastname, string phoneNumber,string age,string email,string password,string address,int adminRegNum)
       {
         var admin = GetAdmin(adminRegNum);
            if (admin != null)
            {
                admin._firstName      = firstName;
                admin._lastName       = lastname;
                admin._phoneNumber    = phoneNumber;
                admin._age            =age;
                admin._email          =email;
                admin._password       = password;
                admin._address        = address;
                
            }
            else
            {
                Console.Beep();
                Console.WriteLine("User not found.");
            }

       }

       public void DeleteAdmin (int adminRegNum)
       {
        var admin = GetAdmin(adminRegNum);
            if (admin != null)
            {
                Console.WriteLine($"{admin._firstName} {admin._lastName} Successfully deleted. ");
                
                Admin.listOfAdmins.Remove(admin);
               
                ReWriteToFile();
            }
            else
            {
                 Console.Beep();
                Console.WriteLine("User not found.");
            }

       }

       public Admin GetAdmin (int adminRegNum)
       {
        foreach (var item in Admin.listOfAdmins)
            {
                if (item._adminRegNum == adminRegNum)
                {
                    return item;
                }
            }
            return null;

       }

       public Admin Login (string email, string passWord)
       {
        foreach (var item in Admin.listOfAdmins)
            {
                if (item._email == email.ToUpper() && item._password == passWord)
                {
                    return item;
                }
            }
            return null;

       }

       public void WriteToTheFileOfAdmin()
       {
        File.WriteAllText(_linkFile, string.Empty);
            using (var streamWriter = new StreamWriter(_linkFile, append: true))
            {
                foreach (var item in Admin.listOfAdmins)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
                
            }

       }

       public void ReadFromFileOfAdmin()
       {

         if (!Directory.Exists(_fileDirect)) Directory.CreateDirectory(_fileDirect);

            if (!File.Exists(_linkFile))

                {
                    var fileStream = new FileStream(_linkFile, FileMode.CreateNew);
                    fileStream.Close();
                }

            using (var streamReader = new StreamReader(_linkFile))

                {
                    while (streamReader.Peek() != -1)
                    {
                        var adminManager = streamReader.ReadLine();
                    Admin.listOfAdmins.Add(Admin.ConvertToAdmin(adminManager));
                    }
                }

       }

       public void ReWriteToFile()
        {
            File.WriteAllText(_linkFile, string.Empty);
            using (var streamWriter = new StreamWriter(_linkFile, append: true))
            {
                foreach (var item in Admin.listOfAdmins)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }



    }
}
