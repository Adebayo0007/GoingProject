using System;
using LegitBankApp.Implementations;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;

namespace LegitBankApp.Menu
{
    public class AdminMenu
    {
        IAdminManager _iAdminManager              = new AdminManager();
        ITransactionManager _iTransactionManager  = new TransactionManager();
        ICustomerManager _iCustomerManager         = new CustomerManager();
        private int _choice;


        public void AllAdminMenu()
        {
            System.Console.WriteLine("\n\tEnter 1 to Register Admin\n\tEnter 2 to Login Admin");
            int check;
            int.TryParse(Console.ReadLine(),out check);
            switch(check)
            {
                case 1:
                RegisterAdminMenu();
                break;

                 case 2:
                 LoginAdminMenu();
                break;
            }

        }
        public void RegisterAdminMenu()
        {
            Console.WriteLine(@"

 ################################################################################
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ####________________________________________________________________________####
 ####             Welcome to Zenith Bank >>> Admin Registration .            ####
 ####------------------------------------------------------------------------####
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ################################################################################");
            
            Console.WriteLine("\n\tHome && Register && Admin");
            Console.Write("\tEnter your First name: ");
            var firstName = Console.ReadLine();
            Console.Write("\tEnter your Last name: ");
            var lastName = Console.ReadLine();
            Console.Write($"\tHello {firstName} {lastName} ! \n\t Enter your age: ");
            var age = Console.ReadLine();
            Console.Write("\tEnter your email address: ");
            var email = Console.ReadLine().Trim().ToUpper();
            Console.Write("\tEnter your Password: ");
            var passWord = Console.ReadLine();
            Console.Write("\tEnter your Phone Number: ");
            var number = Console.ReadLine();
            Console.Write("\tEnter your Address: ");
            var address = Console.ReadLine();
            Console.Write("\tEnter your gender: ");
            var gender = Console.ReadLine();
            Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Registration Completed->>>>> ");

            _iAdminManager.CreateAdmin(firstName, lastName, email, age, email, passWord,address,gender);
            System.Console.WriteLine("\n\tEnter 1 to Login\n\tEnter 0 to opt out");
            int x;
            int.TryParse(Console.ReadLine(),out x);
            switch(x)
            {
                case 1:
                LoginAdminMenu();
                break;

                case 0:
                System.Console.WriteLine("Closing Application");
                break;
            }

          
        }
        

        public void LoginAdminMenu()
        {
             Console.WriteLine(@"

 ################################################################################
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ####________________________________________________________________________####
 ####             Welcome to Zenith Bank >>> Login Admin .                   ####
 ####------------------------------------------------------------------------####
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ################################################################################");
            Console.WriteLine("\tWelcome !.\n\tEnter your E-mail and Password to login ");
            Console.Write("\tEnter your E-mail: ");
            var mail = Console.ReadLine();
            Console.Write("\tEnter your password: ");
            var pass = Console.ReadLine();
            var admin = _iAdminManager.Login(mail, pass);
            if (admin != null)
            {
                Console.WriteLine($"Welcome {admin._firstName}, you've successfully Logged in!");
                System.Console.WriteLine("\n\tEnter 0 to opt out\n\tEnter 1 to Manage customer\n\tEnter 2 to Manage Transaction");
                int input;
                int.TryParse(Console.ReadLine(),out input);
                switch(input)
                {
                    case 0:
                    System.Console.WriteLine("Closong Application...");
                    break;

                    case 1:
                    SubAdminMenu();
                    break;

                    case 2:
                    SubAdminMenuTransaction();
                    break;
                }
                
            }
            else
            {
                System.Console.Beep();
                Console.WriteLine("Wrong Input.");

                Console.WriteLine("\n\tEnter 1 to go back to login menu\n\tEnter 0 to 0pt out ");
                            int test; 
                            int.TryParse(Console.ReadLine(),out test);
                            if(test ==1 )
                                    {
                                      LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
               
            }
        }










        public void DeleteCustomertMenu()
        {
            Console.WriteLine(@"

 ################################################################################
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ####________________________________________________________________________####
 ####             Welcome to Zenith Bank >>> Delete customer .               ####
 ####------------------------------------------------------------------------####
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ################################################################################");
            Console.Write("Enter Customer's Account Number.");
            var accountNum = Console.ReadLine();
            _iCustomerManager.DeleteCustomer(accountNum);

            Console.WriteLine("Enter 1 to go back to login menu");
                            int test; 
                            int.TryParse(Console.ReadLine(),out test);
                            if(test ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
        }

        public void CreateCustomerMenu()
        {
            string pin;
            Console.WriteLine(@"

 ################################################################################
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ####________________________________________________________________________####
 #### Welcome to Zenith Bank >>> Creation of Customer using Admin Portal .   ####
 ####------------------------------------------------------------------------####
 ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
 ################################################################################");
            
            Console.WriteLine("\n\tHome && Register && Admin");
            Console.Write("\tEnter Customer's First name: ");
            var firstName = Console.ReadLine();
            Console.Write("\tEnter Customer's Last name: ");
            var lastName = Console.ReadLine();
             Console.Write($"\tHello {firstName} {lastName} ! \n\t Enter your age: ");
            var age = Console.ReadLine();
            Console.Write("\tEnter Customer's email address: ");
            var email = Console.ReadLine().Trim().ToUpper();
            Console.Write("\tEnter Customer's Password: ");
            var passWord = Console.ReadLine();
            Console.Write("\tEnter Customer's Phone Number: ");
            var number = Console.ReadLine();
            Console.Write("\tEnter Customer's Address: ");
            var address = Console.ReadLine();
            Console.Write("\tEnter Customer's gender: ");
            var gender = Console.ReadLine();
            do
            {
            Console.Write("\tEnter four secrete digit Pin: ");
            pin = Console.ReadLine();
            }while(pin.Length != 4 );
            Console.Write("\tEnter Customer's Account Type\nPress 1 for Student.\nPress 2 for Savings.\nPress 3 for Current.\nPress 4 for Business Account.\nPress 5 for Joint. ");
            int input;
            int.TryParse(Console.ReadLine(), out input);
            string accountType;
            switch(input)
            {
                case 1:
                accountType = "Student Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer Creation Completed->>>>> ");
                _iCustomerManager.CreateCustomer(firstName,lastName,age,email,passWord,number,address,gender,pin,accountType);

                Console.WriteLine("Enter 1 to go back to login menu");
                            int test; 
                            int.TryParse(Console.ReadLine(),out test);
                            if(test ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 2:
                accountType = "Savings Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer Creation Completed->>>>> ");
                _iCustomerManager.CreateCustomer(firstName,lastName,age,email,passWord,number,address,gender,pin,accountType);

                Console.WriteLine("Enter 1 to go back to login menu");
                            int test1; 
                            int.TryParse(Console.ReadLine(),out test1);
                            if(test1 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 3:
                accountType = "Current Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer Creation Completed->>>>> ");
                _iCustomerManager.CreateCustomer(firstName,lastName,age,email,passWord,number,address,gender,pin,accountType);

                Console.WriteLine("Enter 1 to go back to login menu");
                            int test2; 
                            int.TryParse(Console.ReadLine(),out test2);
                            if(test2 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 4:
                accountType = "Business Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer Creation Completed->>>>> ");
                _iCustomerManager.CreateCustomer(firstName,lastName,age,email,passWord,number,address,gender,pin,accountType);

                Console.WriteLine("Enter 1 to go back to login menu");
                            int test3; 
                            int.TryParse(Console.ReadLine(),out test3);
                            if(test3 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 5:
                accountType = "Joint Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer Creation Completed->>>>> ");
                _iCustomerManager.CreateCustomer(firstName,lastName,age,email,passWord,number,address,gender,pin,accountType);
                Console.WriteLine("Enter 1 to go back to login menu");
                            int test4; 
                            int.TryParse(Console.ReadLine(),out test4);
                            if(test4 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;
            } 
        }

         public void UpdateCustomerMenu()
        {

                        Console.WriteLine(@"

            ################################################################################
            ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
            ####________________________________________________________________________####
            ####Welcome to Zenith Bank >>> Updating Customer's detail using Admin Portal####
            ####------------------------------------------------------------------------####
            ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
            ################################################################################");
            string pin1;
            string accountNumber;
            Console.WriteLine("\n\tHome && Register && Admin");
            Console.Write("\tEnter Customer's First name: ");
            var firstName = Console.ReadLine();
            Console.Write("\tEnter Customer's Last name: ");
            var lastName = Console.ReadLine();
             Console.Write($"\tHello {firstName} {lastName} ! \n\t Enter your age: ");
            var age = Console.ReadLine();
            Console.Write("\tEnter Customer's email address: ");
            var email = Console.ReadLine().Trim().ToUpper();
            Console.Write("\tEnter Customer's Password: ");
            var passWord = Console.ReadLine();
            Console.Write("\tEnter Customer's Phone Number: ");
            var number = Console.ReadLine();
            Console.Write("\tEnter Customer's Address: ");
            var address = Console.ReadLine();
            Console.Write("\tEnter Customer's gender: ");
            var gender = Console.ReadLine();
             do
                {
                    Console.Write("\tEnter four secrete digit Pin: ");
                    pin1 = Console.ReadLine();
                }while(pin1.Length != 4 );
            Console.Write("\tEnter Customer's Account Type\nPress 1 for Student.\nPress 2 for Savings.\nPress 3 for Current.\nPress 4 for Business Account.\nPress 5 for Joint. ");
            int input;
            int.TryParse(Console.ReadLine(), out input);
            string accountType;
            switch(input)
            {
                case 1:
                accountType = "Student Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                 do
                    {
                        Console.Write("\tEnter Customers's AccountNumber: ");
                        accountNumber = Console.ReadLine();
                    }while(accountNumber.Length != 10 );

                   _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,address,pin1,accountType,accountNumber);
                    Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer's Update Completed->>>>> ");
                    Console.WriteLine("Enter 1 to go back to login menu");
                            int test; 
                            int.TryParse(Console.ReadLine(),out test);
                            if(test ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 2:
                accountType = "Savings Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                do
                    {
                        Console.Write("\tEnter Customers's AccountNumber: ");
                        accountNumber = Console.ReadLine();
                    }while(accountNumber.Length != 10 );

                   _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,address,pin1,accountType,accountNumber);
                    Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer's Update Completed->>>>> ");

                    Console.WriteLine("Enter 1 to go back to login menu");
                            int test1; 
                            int.TryParse(Console.ReadLine(),out test1);
                            if(test1 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 3:
                accountType = "Current Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                do
                    {
                        Console.Write("\tEnter Customers's AccountNumber: ");
                        accountNumber = Console.ReadLine();
                    }while(accountNumber.Length != 10 );

                   _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,address,pin1,accountType,accountNumber);
                    Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer's Update Completed->>>>> ");
                    Console.WriteLine("Enter 1 to go back to login menu");
                            int test2; 
                            int.TryParse(Console.ReadLine(),out test2);
                            if(test2 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 4:
                accountType = "Business Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                do
                    {
                        Console.Write("\tEnter Customers's AccountNumber: ");
                        accountNumber = Console.ReadLine();
                    }while(accountNumber.Length != 10 );

                   _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,address,pin1,accountType,accountNumber);
                    Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer's Update Completed->>>>> ");

                    Console.WriteLine("Enter 1 to go back to login menu");
                            int test3; 
                            int.TryParse(Console.ReadLine(),out test3);
                            if(test3 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                break;

                case 5:
                accountType = "Joint Account";  
                System.Console.WriteLine($"\n\tHello {firstName} {lastName} !\n\tYou have chosen {accountType} as your account Type");
                do
                    {
                        Console.Write("\tEnter Customers's AccountNumber: ");
                        accountNumber = Console.ReadLine();
                    }while(accountNumber.Length != 10 );

                   _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,address,pin1,accountType,accountNumber);
                    Console.Write($"\n\t<<<<<-Congratulations !->>>>>\n\t<<<<<-Customer's Update Completed->>>>> ");

                    Console.WriteLine("Enter 1 to go back to login menu");
                            int test4; 
                            int.TryParse(Console.ReadLine(),out test4);
                            if(test4 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                    
                break;
            }
        }


                public void ViewAllCustomerMenu()
                {
                            string account;
                                    Console.WriteLine(@"

                        ################################################################################
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ####________________________________________________________________________####
                        ####Welcome to Zenith Bank >>> Viewing Customers details using Admin Portal ####
                        ####------------------------------------------------------------------------####
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ################################################################################");

                        do
                            {
                                Console.Write("\tEnter Customers's AccountNumber: ");
                                account = Console.ReadLine();
                            }while(account.Length != 10 );

                        _iCustomerManager.ViewCustomers(account);

                        Console.WriteLine("Enter 1 to go back to login menu");
                        int test; 
                        int.TryParse(Console.ReadLine(),out test);
                            if(test ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                    else
                                        {
                                            System.Console.WriteLine("Closing...");
                                        }

                }

                public void ViewCustomerMenu()
                { 
                            Console.WriteLine(@"

                        ################################################################################
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ####________________________________________________________________________####
                        ####Welcome to Zenith Bank >>> Viewing Customer's detail using Admin Portal ####
                        ####------------------------------------------------------------------------####
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ################################################################################");
                            
                            Console.Write("\tEnter Customer's Account Number: ");
                            var account = Console.ReadLine();
                        
                            var customer = _iCustomerManager.GetCustomer(account);
                            if (customer!= null)
                            {
                                        Console.WriteLine($"\tThe customer's name is {customer._firstName} {customer._lastName}\n\tThe customer's email is {customer._email}\n\tThe customer's Phone Number  is {customer._phoneNumber}\n\tThe customer's account type is {customer._accountType} ");
                                        
                                        //System.Console.WriteLine(customer);
                                        Console.WriteLine("Enter 1 to go back to login menu");
                                    int test; 
                                    int.TryParse(Console.ReadLine(),out test);
                                    if(test ==1 )
                                            {
                                                LoginAdminMenu();
                                            }
                                    else
                                        {
                                            System.Console.WriteLine("Closing...");
                                        }
                                
                            }
                            else
                            {
                                System.Console.Beep();
                                Console.WriteLine("Wrong Input.");
                                Console.WriteLine("Enter 1 to go back to login menu");
                            int test; 
                            int.TryParse(Console.ReadLine(),out test);
                            if(test ==1 )
                                {
                                    LoginAdminMenu();
                                }
                            else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            }

                        }


                public void SubAdminMenu()
                {

                            Console.WriteLine(@"

                        ################################################################################
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ####________________________________________________________________________####
                        ####                         Welcome To ZenithBank   !                      ####
                        ####------------------------------------------------------------------------####
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ################################################################################");
                        Console.WriteLine("\n\tHome >> Login >> Admin >>");
                        Console.WriteLine("\n\tEnter 0 to opt out\n\tEnter 1 to Register a customer\n\tEnter 2 to Update Customer's Information\n\tEnter 3 to Delete Customer's record\n\tEnter 4 to View Customer's record\n\tEnter 5 to view All Customer's record");
                        int choice;
                        int.TryParse(Console.ReadLine(),out choice);
                        switch(choice)
                        {
                            case 0:
                                System.Console.WriteLine("Application Closing...");
                            break;

                            case 1:
                                CreateCustomerMenu();
                                Console.WriteLine("Enter 1 to go back to login menu");
                                int test; 
                                int.TryParse(Console.ReadLine(),out test);
                                if(test ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 2:
                                UpdateCustomerMenu();
                                Console.WriteLine("Enter 1 to go back to login menu");
                                int test1; 
                                int.TryParse(Console.ReadLine(),out test1);
                                if(test1 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 3:
                                DeleteCustomertMenu();
                                Console.WriteLine("Enter 1 to go back to login menu");
                                int test2; 
                                int.TryParse(Console.ReadLine(),out test2);
                                if(test2 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 4:
                                ViewCustomerMenu();
                                Console.WriteLine("Enter 1 to go back to login menu");
                                int test3; 
                                int.TryParse(Console.ReadLine(),out test3);
                                if(test3 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 5:
                                    ViewAllCustomerMenu();
                                    Console.WriteLine("Enter 1 to go back to login menu");
                                    int test4; 
                                    int.TryParse(Console.ReadLine(),out test4);
                                    if(test4 ==1 )
                                    {
                                        LoginAdminMenu();
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Closing...");
                                    }
                            break;   
                            
                        }

                }











                




                public void CreateWithdrawalMenu()

                {
                   
                    string firstName = " ";
                    string lastName = " ";
                    string age = " ";
                    string email = " ";
                    string passWord = " ";
                    string number = " ";
                    string address = " ";
                    string gender = " ";
                    string pin1;
                    Console.Write("\tEnter your withdrawal amount:");
                    double withdraw;
                     double.TryParse(Console.ReadLine(), out withdraw);
                     
                     string acc;
                     do
                     {
                     System.Console.WriteLine("\tEnter your account number");
                     acc = Console.ReadLine();
                     }while(acc.Length != 10);
                     do
                        {
                            Console.Write("\tEnter four secrete digit Pin: ");
                            pin1 = Console.ReadLine();
                        }while(pin1.Length != 4 );
                    string accountType = " ";
                    long balance = 0;
                     long depo = 0;
                     long airtime = 0;
                     string time = DateTime.Now.ToString("dddd,dd MMMM yyyy HH:mm:ss");
                     string refNum = " ";

                        _iTransactionManager.CreateWithdrawal(firstName,lastName,age,email,passWord,number,address,gender,pin1,accountType,balance,withdraw,depo,airtime,acc,time,refNum);
                        System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {acc[0]}{acc[1]}*****{acc[7]}{acc[8]}*\n\tAmt: NGN {withdraw}\n\tFrom: {acc}\n\tDate: {time}");



                }


                public void CreateDepositMenu()

                {
                   
                    string firstName = " ";
                    string lastName = " ";
                    string age = " ";
                    string email = " ";
                    string passWord = " ";
                    string number = " ";
                    string address = " ";
                    string gender = " ";
                    string pin1;
                    Console.Write("\tEnter your deposit amount:");
                    double depo;
                     double.TryParse(Console.ReadLine(), out depo);
                     System.Console.Write("To:");
                     string reciever = Console.ReadLine();
                     string acc;
                     do
                     {
                     System.Console.WriteLine("\tEnter your account number");
                     acc = Console.ReadLine();
                     }while(acc.Length != 10);
                     do
                        {
                            Console.Write("\tEnter four secrete digit Pin: ");
                            pin1 = Console.ReadLine();
                        }while(pin1.Length != 4 );
                    string accountType = " ";
                    long balance = 0;
                     long withdraw = 0;
                     long airtime = 0;
                     string time = DateTime.Now.ToString("dddd,dd MMMM yyyy HH:mm:ss");
                     string refNum = " ";

                        _iTransactionManager.CreateDeposit(firstName,lastName,age,email,passWord,number,address,gender,pin1,accountType,balance,withdraw,depo,airtime,acc,time,refNum);
                        System.Console.WriteLine($"\n\tTnx: Credit\n\tAc: {acc[0]}{acc[1]}*****{acc[7]}{acc[8]}*\n\tAmt: NGN {depo}\n\tTo: {reciever}\n\tDate: {time}");


                }


                 public void CreateAirtimeMenu()

                {
                   
                    string firstName = " ";
                    string lastName = " ";
                    string age = " ";
                    string email = " ";
                    string passWord = " ";
                    string number = " ";
                    string address = " ";
                    string gender = " ";
                    string pin1;
                    Console.Write("\tEnter your airtime amount:");
                    double airtime;
                     double.TryParse(Console.ReadLine(), out airtime);
                     System.Console.Write("Enter your Network:");
                     string reciever = Console.ReadLine();
                     string acc;
                     do
                     {
                     System.Console.WriteLine("\tEnter your account number");
                     acc = Console.ReadLine();
                     }while(acc.Length != 10);
                     do
                        {
                            Console.Write("\tEnter four secrete digit Pin: ");
                            pin1 = Console.ReadLine();
                        }while(pin1.Length != 4 );
                    string accountType = " ";
                    long balance = 0;
                     long withdraw = 0;
                     long depo = 0;
                     string time = DateTime.Now.ToString("dddd,dd MMMM yyyy HH:mm:ss");
                     string refNum = " ";

                        _iTransactionManager.CreateAirtime(firstName,lastName,age,email,passWord,number,address,gender,pin1,accountType,balance,withdraw,depo,airtime,acc,time,refNum);
                        System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {acc[0]}{acc[1]}*****{acc[7]}{acc[8]}*\n\tAmt: NGN {airtime}\n\tTo: {reciever}\n\tDate: {time}");


                }

               
                   
                    public void GetTransactionMenu()
                    {
                        System.Console.WriteLine("Enter your ref number to delete transaction");
                        string refNum = Console.ReadLine();
                        _iTransactionManager.GetTransaction(refNum);
                    }


                    public void SubAdminMenuTransaction()
                    {
                          Console.WriteLine(@"

                        ################################################################################
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ####________________________________________________________________________####
                        ####                         Welcome To ZenithBank   !                      ####
                        ####------------------------------------------------------------------------####
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ################################################################################");
                        Console.WriteLine("\n\tHome >> Login >> Admin >>");
                        Console.WriteLine("\n\tEnter 0 to opt out\n\tEnter 1 to Create withdrawal\n\tEnter 2 to Create Deposit\n\tEnter 3 to Create airtime\n\tEnter 4 to Delete withdrawal\n\tEnter 5 to Delete deposit\n\tEnter 6 to Delete airtime\n\tEnter 7 to get Transaction");
                        int choice;
                        int.TryParse(Console.ReadLine(),out choice);
                        switch(choice)
                        {
                            case 0:
                            System.Console.WriteLine("Closing Application...");
                            break;
                            case 1:
                             CreateWithdrawalMenu();
                             Console.WriteLine("Enter 1 to go back to login menu");
                                int test; 
                                int.TryParse(Console.ReadLine(),out test);
                                if(test ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 2:
                            CreateDepositMenu();
                            Console.WriteLine("Enter 1 to go back to login menu");
                                int test1; 
                                int.TryParse(Console.ReadLine(),out test1);
                                if(test1 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 3:
                            CreateAirtimeMenu();
                            Console.WriteLine("Enter 1 to go back to login menu");
                                int test2; 
                                int.TryParse(Console.ReadLine(),out test2);
                                if(test2 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;
                           

                            case 4:
                            _iTransactionManager.DeleteWithdrawal();
                            Console.WriteLine("Enter 1 to go back to login menu");
                                int test3; 
                                int.TryParse(Console.ReadLine(),out test3);
                                if(test3 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 5:
                            _iTransactionManager.DeleteDeposite();
                            Console.WriteLine("Enter 1 to go back to login menu");
                                int test4; 
                                int.TryParse(Console.ReadLine(),out test4);
                                if(test4 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 6:
                            _iTransactionManager.DeleteAirtime();
                            Console.WriteLine("Enter 1 to go back to login menu");
                                int test5; 
                                int.TryParse(Console.ReadLine(),out test5);
                                if(test5 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;

                            case 7:
                            GetTransactionMenu();
                            Console.WriteLine("Enter 1 to go back to login menu");
                                int test6; 
                                int.TryParse(Console.ReadLine(),out test6);
                                if(test6 ==1 )
                                {
                                    LoginAdminMenu();
                                }
                                else
                                {
                                    System.Console.WriteLine("Closing...");
                                }
                            break;
                        }

                    }
    }

}