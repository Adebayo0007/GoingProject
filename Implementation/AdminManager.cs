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

        
        public string _data { get; set; }
        string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";

        public void QueryWriting(int id)
        {
            //create connection
            //open connection and
            //querry


/*
            try
            {
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
            */



            


            //read from sql
            
            // try

            // {
            //     string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";
            //     using (var connection = new MySqlConnection(conn))
            //     {
            //         connection.Open();
            //         var command = new MySqlCommand($"Select * from staffs where ID = '{id}'", connection);
            //         var reader  = command.ExecuteReader();
            //         while(reader.Read())
            //         {
            //            Console.WriteLine($"{reader["Name"]}");
                   
            //             new Transactino{
            //                // Transaction._accountBalance=  (double)reader["accountBalance"],
            //                 Email = (string)reader["Email"]

            //             };
                        
            //         }
            //     }
            // }
            // catch(Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
            




            
            //  try
            //  {
            //      string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";
            //      using (var connection = new MySqlConnection(conn))
            //      {
            //          connection.Open();
            //          string qur = $"create table Transaction (id int auto_increment,staffId varchar(20) not null unique,firstName varchar(20) not null,lastName varchar(20) not null,age varchar (20) not null,email  varchar(50) not null unique,password varchar(50) not null ,phoneNumber  varchar (20) not null unique,address varchar(50) not null,gender varchar(10) not null, primary key (id,staffId))";
            //          using (var command = new MySqlCommand(qur, connection))
            //          {
            //              command.ExecuteNonQuery();
            //          }
            //      }
            //  }
            //  catch (Exception ex)
            //  {
            //      System.Console.WriteLine(ex.Message);
            //  }
             




            /*
            System.Console.WriteLine("this is aftre dataabse");
            var connection = new MySqlConnection("Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999");
            string qur = $"create table bAdmin (id int auto_increment,staffId varchar(20) not null unique,firstName varchar(20) not null,lastName varchar(20) not null,age varchar (20) not null,email  varchar(50) not null unique,password varchar(50) not null ,phoneNumber  varchar (20) not null unique,address varchar(50) not null,gender varchar(10) not null, primary key (id,staffId))";
            var command = new MySqlCommand(qur, connection);
            command.ExecuteNonQuery();
            connection.Close();
            */

        }

        public void CreateAdmin(string firstName, string lastName, string age, string email, string password, string phoneNumber, string address, string gender)
        {

            try
            {
                
                Admin ad = new Admin(firstName, lastName, age, email, password, phoneNumber, address, gender);

                System.Console.WriteLine($"\n\t<<<<<Your ID number is: {ad._staffID}>>>>>");
               


                using (var connection = new MySqlConnection(conn))
                {
                    string qur = $"insert into admin (staffId,firstName, lastName, age, email, password, phoneNumber, address, gender) values ('{ad._staffID}','{ad._firstName}','{ad._lastName}','{ad._age}','{ad._email.Trim().ToUpper()}','{ad._password}','{ad._phoneNumber}','{ad._address}','{ad._gender}')";
                    connection.Open();
                    using (var command = new MySqlCommand(qur, connection))
                    {
                        var execute = command.ExecuteNonQuery();
                        if(execute > 0)
                        {
                             System.Console.WriteLine($"\n\tCongratulation {firstName} {lastName},registration completed");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


        }

        public void UpdateAdmin(string firstName, string lastname, string phoneNumber, string age, string email, string password, string address, string Id)
        {
            var admin = GetAdmin(Id);
            if(admin != null)
            {
            try
                {
                    using (var connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        var queryUpdateA = $"update admin set firstName = '{firstName}', lastName = '{lastname}',phoneNumber = '{phoneNumber}',age = '{age}',email = '{email}',password = '{password}',address = '{address}' where staffId = '{Id}'";
                        using (var command = new MySqlCommand(queryUpdateA, connection))
                        {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                            {
                                System.Console.WriteLine($"\n\tCongratulation {firstName} {lastname},You have successfully updated your information");

                            }
                            else
                            {
                                System.Console.WriteLine("Invalid input");
                            }
                           
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                System.Console.WriteLine("wrong input");
            }


        }


        public void DeleteAdmin(string id)
        {
           var admin = GetAdmin(id);
            if (admin != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"delete From admin WHERE staffId = '{id}'", connection))
                        {
                            var execute = command.ExecuteNonQuery();
                            if(execute > 0)
                            {

                                System.Console.WriteLine($"\n\t{admin._firstName} {admin._lastName} Successfully deleted. ");
                            }
                           
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }

        }

        


        public Admin GetAdmin(string id)
        {

            Admin admin = null;

            using (var connection = new MySqlConnection(conn))
            {
                connection.Open();
                string query = $"select * from Admin where staffId ='{id}'  ";
              
                using (var command = new MySqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        admin = new Admin($"{reader["firstName"].ToString()}", $"{reader["lastName"].ToString()}", $"{reader["age"].ToString()}", $"{reader["email"].ToString()}", $"{reader["password"].ToString()}", $"{reader["phoneNumber"].ToString()}", $"{reader["address"].ToString()}", $"{reader["gender"].ToString()}");

                    }
                }
            }
            if (admin != null)
            {
                return admin;
            }

            return null;

        }


        public Admin Login(string email, string passWord)
        {
            
            Admin admin = null;
            try
            {
                using (var connection = new MySqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From admin WHERE email = '{email}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            admin = new Admin( reader["firstName"].ToString(), reader["lastName"].ToString(),reader["age"].ToString(), reader["email"].ToString(), reader["password"].ToString(), reader["phoneNumber"].ToString(), reader["address"].ToString(),reader["staffId"].ToString());
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return admin is not null && admin._email.ToUpper() == email.ToUpper() && admin._password == passWord ? admin : null;

            }

        }
    }
