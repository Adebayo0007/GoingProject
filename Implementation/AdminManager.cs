using System;
using System.Collections.Generic;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;
using System.IO;
using MySql.Data.MySqlClient;

namespace LegitBankApp.Implementations
{
    public class AdminManager : IAdminManager
    {

        public string _fileDirect = @"C:\Users\user\Desktop\LegitBankApp\File";
        public string _linkFile = "C:\\Users\\user\\Desktop\\LegitBankApp\\File\\AdminFile.txt";
        public string _data { get; set; }

        public void QueryWriting()
        {
            //create connection
            //querry

            try
            {
                string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                using (var connection = mySqlConnection)
                {
                    string qur = $"insert into admin (staffId,firstName,lastName,age,email,password,phoneNumber,address,gender)  values ('ZENITH/ADMIN-303/Lek0','Lekan','Ridwan','15','LEKAN@GMAIL.COM','3456','07077432567','20,Godwin street,Abeokuta','male')";
                    connection.Open();
                    using (var command = new MySqlCommand(qur, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


            // System.Console.WriteLine("this is aftre dataabse");
            // try
            // {
            //     string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";
            //     using (var connection = new MySqlConnection(conn))
            //     {
            //         string qur = $"create table Admin (id int auto_increment,staffId varchar(20) not null unique,firstName varchar(20) not null,lastName varchar(20) not null,age varchar (20) not null,email  varchar(50) not null unique,password varchar(50) not null ,phoneNumber  varchar (20) not null unique,address varchar(50) not null,gender varchar(10) not null, primary key (id,staffId))";
            //         connection.Open();
            //         using (var command = new MySqlCommand(qur, connection))
            //         {
            //             command.ExecuteNonQuery();
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     System.Console.WriteLine(ex.Message);
            // }



            
            // System.Console.WriteLine("this is aftre dataabse");
            // var connection = new MySqlConnection("Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999");
            // string qur = $"create table bAdmin (id int auto_increment,staffId varchar(20) not null unique,firstName varchar(20) not null,lastName varchar(20) not null,age varchar (20) not null,email  varchar(50) not null unique,password varchar(50) not null ,phoneNumber  varchar (20) not null unique,address varchar(50) not null,gender varchar(10) not null, primary key (id,staffId))";
            // var command = new MySqlCommand(qur, connection);
            // command.ExecuteNonQuery();
            // connection.Close();

        }

        public void CreateAdmin(string firstName, string lastName, string age, string email, string password, string phoneNumber, string address, string gender)
        {

             try
            {
            Admin.listOfAdmins.Add(new Admin(firstName, lastName, age, email, password, phoneNumber, address, gender));
            Admin ad = new Admin(firstName, lastName, age, email, password, phoneNumber, address, gender);

            System.Console.WriteLine($"Your ID number is: {ad._staffID}");
             using (StreamWriter streamWriter = new StreamWriter(_linkFile, append: true))
            {
                streamWriter.WriteLine(ad.WriteToFIle());
            }
            
            // try
            // {
                string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";
                using (var connection = new MySqlConnection(conn))
                {
                    //var admin = new Admin(firstName,lastName,age,email,password,phoneNumber,address,gender);

                    string qur = $"insert into admin (staffId,firstName, lastName, age, email, password, phoneNumber, address, gender) values ('{ad._staffID}','{ad._firstName}','{ad._lastName}','{ad._age}','{ad._email.Trim().ToUpper()}','{ad._password}','{ad._phoneNumber}','{ad._address}','{ad._gender}')";
                    connection.Open();
                    using (var command = new MySqlCommand(qur, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

           
           

        }

        public void UpdateAdmin(string firstName, string lastname, string phoneNumber, string age, string email, string password, string address, int adminRegNum)
        {
            var admin = GetAdmin(adminRegNum);
            if (admin != null)
            {
                admin._firstName = firstName;
                admin._lastName = lastname;
                admin._phoneNumber = phoneNumber;
                admin._age = age;
                admin._email = email;
                admin._password = password;
                admin._address = address;

            }
            else
            {
                Console.Beep();
                Console.WriteLine("User not found.");
            }

        }

        public void DeleteAdmin(int adminRegNum)
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

        public Admin GetAdmin(int adminRegNum)
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

        public Admin Login(string email, string passWord)
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
