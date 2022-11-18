using System;
using LegitBankApp.Implementations;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;
using MySql.Data.MySqlClient;

namespace LegitBankApp.Menu
{
    public class AdminMenu
    {
        IAdminManager _iAdminManager              = new AdminManager();
        ITransactionManager _iTransactionManager  = new TransactionManager();
        ICustomerManager _iCustomerManager         = new CustomerManager();
        IManagingDirector _managingDirector        = new ManagingDirectorManager();
        private int _choice;

        string conn = "Server=localhost;port=3306;Database=bankapp;Uid=root;Pwd=Adebayo58641999";








//ADO.NET

public void ManagerMenu()
{
    System.Console.WriteLine("\n\tEnter 1 to Register\n\tEnter 2 to Login");
    int choice;
    int.TryParse(Console.ReadLine(), out choice);
    switch(choice)
    {
        case 1:
        CreateManagingDirector();
        break;

         case 2:
        LogInManagingDirector();
        break;
    }

}

public void CreateManagingDirector()
{
    string security = "ZenithManager0007";
                    System.Console.WriteLine("Enter the company's pass");
                    string passs = Console.ReadLine();
                    if(passs == security)
                    {
                                        Console.WriteLine(@"

                    ################################################################################
                    ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                    ####________________________________________________________________________####
                    ####             Welcome to Zenith Bank >>> Admin Registration .            ####
                    ####------------------------------------------------------------------------####
                    ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                    ################################################################################");
                    System.Console.WriteLine("Enter admin first name");
                            string first = Console.ReadLine();
                            System.Console.WriteLine("Enter admin last name");
                            string last = Console.ReadLine();
                            System.Console.WriteLine("Enter admin age");
                            string age = Console.ReadLine();
                            
                            string phone;
                            do
                            {
                            System.Console.WriteLine("Enter admin Phone number");
                            phone = Console.ReadLine();
                            }while(phone.Length != 11);
                            _managingDirector.CreateManager(first,last,age,phone);
                }
                else
                {
                    System.Console.WriteLine("Go back to the bank to ask for the pass");
                }
                

}

public void UpdateManger()
{
     System.Console.WriteLine("Enter admin first name");
                            string first = Console.ReadLine();
                            System.Console.WriteLine("Enter admin last name");
                            string last = Console.ReadLine();
                            string phone;
                            do
                            {
                            System.Console.WriteLine("Enter admin Phone number");
                            phone = Console.ReadLine();
                            }while(phone.Length != 11);
                            System.Console.WriteLine("Enter your Id");
                            string id = Console.ReadLine();
    _managingDirector.UpdateManager(first,last,phone,id);
}







public void LogInManagingDirector()
{
    System.Console.WriteLine("Enter your Id");
    string id = Console.ReadLine();
    var manager =_managingDirector.LoginManager(id);
                            if(manager != null)
                            {
                                            System.Console.WriteLine("Login Successfully");
                                            System.Console.WriteLine("\n\tEnter 1 to manage admin\n\tEnter 2 to Update Manager Information");
                                            int i;
                                            int.TryParse(Console.ReadLine(),out i);
                                            
                                            if (i == 1)
                                            {
                                                
                                                                    Console.WriteLine(@"

                                                        ################################################################################
                                                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                                                        ####________________________________________________________________________####
                                                        ####                         Welcome To ZenithBank   !                      ####
                                                        ####------------------------------------------------------------------------####
                                                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                                                        ################################################################################");
                                                    
                                                    System.Console.WriteLine("\n\tEnter 0 to close Application\n\tEnter 1 to Manage Admin");
                                                    int choice;
                                                    int.TryParse(Console.ReadLine(), out choice);
                                                    if(choice == 0)
                                                    {
                                                        System.Console.WriteLine("Closing Application...");
                                                    }
                                                    if(choice == 1)
                                                            {
                                                                System.Console.WriteLine("\n\tEnter 1 to Create Admin\n\tEnter 2 to Delete Admin\n\tEnter 3 to Login Admin\n\tEnter 4 to Get Admin Information using Id\n\tEnter 5 to Update Admin Information with Id");
                                                                int check;
                                                                int.TryParse(Console.ReadLine(), out check);
                                                                switch(check)
                                                                {
                                                                    case 1:
                                                                    CreateAdmin();
                                                                    
                                                                    break;

                                                                    case 2:
                                                                    DeleteAdmin();
                                                                    break;

                                                                    case 3:
                                                                    LogIn();
                                                                    break;

                                                                    case 4:
                                                                    GetAdmin();
                                                                    break;

                                                                    case 5:
                                                                    UpdateAdmin();
                                                                    break;
                                                                }
                                                    }
                                            }

                                            if (i == 2)
                                                {
                                                    UpdateManger();
                                                }

                                        
                                                            
                                        
                                        }
                            else
                            {
                                System.Console.WriteLine("Invalid input");
                            }
                    
}















                public void ManageAdmins()
                {

                    Console.WriteLine(@"

                        ################################################################################
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ####________________________________________________________________________####
                        ####                         Welcome To ZenithBank   !                      ####
                        ####------------------------------------------------------------------------####
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ################################################################################");
                    
                    System.Console.WriteLine("\n\tEnter 0 to close Application\n\tEnter 1 to Manage Admin");
                    int choice;
                    int.TryParse(Console.ReadLine(), out choice);
                    if(choice == 0)
                    {
                        System.Console.WriteLine("Closing Application...");
                    }
                    if(choice == 1)
                    {
                        System.Console.WriteLine("\n\tEnter 1 to Create Admin\n\tEnter 2 to Login Admin\n\tEnter 3 to Get Admin Information using Id\n\tEnter 4 to Update Admin Information with Id");
                        int check;
                        int.TryParse(Console.ReadLine(), out check);
                        switch(check)
                        {
                            case 1:
                            CreateAdmin();
                            
                            break;

                            case 2:
                             LogIn();
                            break;

                            case 3:
                            GetAdmin();
                            break;

                            case 4:
                            UpdateAdmin();
                            break;
                        }
                    }
                    
                }



                 public void ManageCustomer()
                {

                    Console.WriteLine(@"

                        ################################################################################
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ####________________________________________________________________________####
                        ####                         Welcome To ZenithBank   !                      ####
                        ####------------------------------------------------------------------------####
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ################################################################################");
                    
                    System.Console.WriteLine("\n\tEnter 0 to close Application\n\tEnter 1 to Manage Customer");
                    int choice;
                    int.TryParse(Console.ReadLine(), out choice);
                    if(choice == 0)
                    {
                        System.Console.WriteLine("Closing Application...");
                    }
                    if(choice == 1)
                    {
                        System.Console.WriteLine("\n\tEnter 1 to Create Customer\n\tEnter 2 to Delete Customer\n\tEnter 3 to Login Customer\n\tEnter 4 to Get Customer Information using account number\n\tEnter 5 to Update Admin Information with your existing account Number");
                        int check;
                        int.TryParse(Console.ReadLine(), out check);
                        switch(check)
                        {
                            case 1:
                            CreateCustomer();
                            
                            break;

                            case 2:
                            DeleteCustomer();
                            break;

                            case 3:
                             LogInCustomer();
                            break;

                            case 4:
                            GetCustomer();
                            break;

                            case 5:
                            UpdateCustomer();
                            break;
                        }
                    }
                    
                }

                public void CreateCustomer()
                {
                    var customerMenu = new CustomerMenu();
                    customerMenu.RegisterCustomerMenu();
                }

                public void DeleteCustomer()
                {
                    System.Console.WriteLine("Enter your account Number");
                    string acc = Console.ReadLine();
                   _iCustomerManager.DeleteCustomer(acc);
                }

                public void LogInCustomer()
                {
                    var customerMenu = new CustomerMenu();
                    customerMenu.LogCustomerMenu();
                }
                public void GetCustomer()
                {
                    System.Console.WriteLine("Enter your account Number");
                    string acc = Console.ReadLine();
                 var  customer3 = _iCustomerManager.GetCustomer(acc);
                   if(customer3 != null)
                            {
                                System.Console.WriteLine("<<<<Filter Successful>>>>>");
                                System.Console.WriteLine($"\n{customer3._firstName}\t{customer3._lastName}\t{customer3._age}\t{customer3._email}\t{customer3._password}\t{customer3._phoneNumber}\t{customer3._accountNumber}\t{customer3._gender}\t{customer3._pin}\t{customer3._accountType}");
                            }
                            else
                            {
                                System.Console.WriteLine("Invalid input");
                            }
                    
                }

                public void UpdateCustomer()
                {
                   
                     Console.WriteLine("\n\tHome && Update && Cutomer");
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
            var customer = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
            string pin;
            string accType;
             do
            {
            Console.Write("\tEnter four secrete digit Pin: ");
            pin = Console.ReadLine();
            }while(pin.Length != 4 );
            Console.Write("\tEnter your account type\n\tEnter 1 for Student account\n\tEnter 2 for Savings account\n\tEnter 3 for Current account\n\tEnter 4 for Business account\n\tEnter 5 for Joint account: ");
            int ch ;
            int.TryParse(Console.ReadLine(), out ch);
            if(ch ==1)
            {
                accType = "Student account";
                _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,customer._accountNumber,gender,pin,accType);
            }

             if(ch ==2)
            {
                accType = "Savings account";
                _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,customer._accountNumber,gender,pin,accType);
            }

             if(ch ==3)
            {
                accType = "Current account";
                _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,customer._accountNumber,gender,pin,accType);
            }

             if(ch ==4)
            {
                accType = "Business account";
                _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,customer._accountNumber,gender,pin,accType);
            }

             if(ch ==5)
            {
                accType = "Joint account";
                _iCustomerManager.UpdateCustomer(firstName,lastName,age,email,passWord,number,customer._accountNumber,gender,pin,accType);
            }
            System.Console.WriteLine("\n\t<<<<<<Update Successful>>>>>");

                }


                public void CreateAdmin()
                {
                    string security = "Zenith0007";
                    System.Console.WriteLine("Enter the company's pass");
                    string passs = Console.ReadLine();
                    if(passs == security)
                    {
                                        Console.WriteLine(@"

                    ################################################################################
                    ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                    ####________________________________________________________________________####
                    ####             Welcome to Zenith Bank >>> Admin Registration .            ####
                    ####------------------------------------------------------------------------####
                    ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                    ################################################################################");
                    System.Console.WriteLine("Enter admin first name");
                            string first = Console.ReadLine();
                            System.Console.WriteLine("Enter admin last name");
                            string last = Console.ReadLine();
                            System.Console.WriteLine("Enter admin age");
                            string age = Console.ReadLine();
                            System.Console.WriteLine("Enter admin mail ");
                            string mail = Console.ReadLine().ToUpper();
                            System.Console.WriteLine("Enter admin password");
                            string pass = Console.ReadLine();
                            string phone;
                            do
                            {
                            System.Console.WriteLine("Enter admin Phone number");
                            phone = Console.ReadLine();
                            }while(phone.Length != 11);
                            System.Console.WriteLine("Enter admin address");
                            string address = Console.ReadLine();
                            System.Console.WriteLine("Enter admin gender");
                            string gender = Console.ReadLine();
                            _iAdminManager.CreateAdmin(first,last,age,mail,pass,phone,address,gender);

                }
                else
                {
                    System.Console.WriteLine("Go back to the bank to ask for the pass");
                }
                }

                public  void DeleteAdmin()
                {

                                    Console.WriteLine(@"

                ################################################################################
                ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                ####________________________________________________________________________####
                ####             Welcome to Zenith Bank >>> Delete customer .               ####
                ####------------------------------------------------------------------------####
                ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                ################################################################################");
                            Console.WriteLine("Enter admin Id ");
                            string id = Console.ReadLine().ToUpper();
                            _iAdminManager.DeleteAdmin(id);

                }

                public void LogIn()
                {

                                Console.WriteLine(@"

            ################################################################################
            ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
            ####________________________________________________________________________####
            ####             Welcome to Zenith Bank >>> Login Admin .                   ####
            ####------------------------------------------------------------------------####
            ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
            ################################################################################");
                    System.Console.WriteLine("Enter admin mail ");
                            string mail2 = Console.ReadLine().ToUpper();
                            System.Console.WriteLine("Enter admin password");
                            string pass2 = Console.ReadLine();
                            var admin = _iAdminManager.Login(mail2,pass2);
                            if(admin != null)
                            {
                                System.Console.WriteLine("Login Successfully");
                                System.Console.WriteLine("\n\tEnter 1 to manage admin\n\tEnter 2 to manage Customer");
                                int i;
                                int.TryParse(Console.ReadLine(),out i);
                                
                                if (i == 1)
                                {
                                    
                                    var adminMenu = new AdminMenu();
                                    adminMenu.ManageAdmins();
                                }
                                if (i == 2)
                                {
                                    var adminMenu = new AdminMenu();
                                    adminMenu.ManageCustomer();
                                }

                               
                                                
                               
                            }
                            else
                            {
                                System.Console.WriteLine("Invalid input");
                            }
                    
                }

                public void GetAdmin()
                {

                    Console.WriteLine(@"

                        ################################################################################
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ####________________________________________________________________________####
                        ####Welcome to Zenith Bank >>> Viewing Customer's detail using Admin Portal ####
                        ####------------------------------------------------------------------------####
                        ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                        ################################################################################");
                    System.Console.WriteLine("Enter staff Id ");
                            string id = Console.ReadLine().ToUpper();
                             var admin3 =_iAdminManager.GetAdmin(id);
                             if(admin3 != null)
                            {
                                System.Console.WriteLine("<<<<Filter Successful>>>>>");
                                System.Console.WriteLine($"\n{admin3._email}\t{admin3._firstName}\t{admin3._lastName}\t{admin3._age}\t{admin3._password}\t{admin3._phoneNumber}\t{admin3._address}\t{admin3._gender}");
                            }
                            else
                            {
                                System.Console.WriteLine("Invalid input");
                            }

                }

                public void UpdateAdmin()
                {

                            Console.WriteLine(@"

                    ################################################################################
                    ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                    ####________________________________________________________________________####
                    ####Welcome to Zenith Bank >>> Updating Customer's detail using Admin Portal####
                    ####------------------------------------------------------------------------####
                    ####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
                    ################################################################################");
                            System.Console.WriteLine("Enter admin first name");
                            string first5 = Console.ReadLine();
                            System.Console.WriteLine("Enter admin last name");
                            string last5 = Console.ReadLine();
                            string phone5;
                            do
                            {
                            System.Console.WriteLine("Enter admin Phone number");
                            phone5 = Console.ReadLine();
                            }while(phone5.Length != 11);
                            System.Console.WriteLine("Enter admin age");
                            string age5 = Console.ReadLine();
                            System.Console.WriteLine("Enter admin mail ");
                            string mail5 = Console.ReadLine().ToUpper();
                            System.Console.WriteLine("Enter admin password");
                            string pass5 = Console.ReadLine();
                            System.Console.WriteLine("Enter admin address");
                            string address5 = Console.ReadLine();
                            System.Console.WriteLine("Enter admin Id");
                            string id = Console.ReadLine();

                             _iAdminManager.UpdateAdmin(first5,last5,phone5,age5,mail5,pass5,address5,id);

                }











                




                public void CreateWithdrawalMenu()

                {
                   
                    
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
                    double y = Transaction._accountBalance-=withdraw;
                    double balance = y;
                     long depo = 0;
                     long airtime = 0;
                     string time = DateTime.Now.ToString("dddd,dd MMMM yyyy HH:mm:ss");
                     string refNum = " ";
                     
                     

                        _iTransactionManager.CreateWithdrawal(balance,withdraw,depo,airtime,acc,time,refNum);
                        // System.Console.WriteLine($"\n\tTnx: Debit\n\tAc: {acc[0]}{acc[1]}*****{acc[7]}{acc[8]}*\n\tAmt: NGN {withdraw}\n\tFrom: {acc}\n\tYour balance is: {balance}\n\tDate: {time}");



                }


                public void CreateDepositMenu()

                {
                   
                    
                    string pin1;
                    Console.Write("\tEnter your deposit amount:");
                    double depo;
                     double.TryParse(Console.ReadLine(), out depo);
                    
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
                    
                    double x = Transaction._accountBalance+= depo;
                    double balance = x;
                     long withdraw = 0;
                     long airtime = 0;
                     string time = DateTime.Now.ToString("dddd,dd MMMM yyyy HH:mm:ss");
                     string refNum = " ";
                     

                        _iTransactionManager.CreateDeposit(balance,withdraw,depo,airtime,acc,time,refNum);
                       


                }


                 public void CreateAirtimeMenu()

                {
                   
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
                    double i = Transaction._accountBalance-=airtime;
                    double balance = i;
                     long withdraw = 0;
                     long depo = 0;
                     string time = DateTime.Now.ToString("dddd,dd MMMM yyyy HH:mm:ss");
                     string refNum = " ";

                        _iTransactionManager.CreateAirtime(balance,withdraw,depo,airtime,acc,time,refNum);
                       


                }

               
                   
                    public void GetTransactionMenu()
                    {
                        System.Console.WriteLine("Enter your ref number to Get transaction");
                        string refNum = Console.ReadLine();
                        System.Console.WriteLine("Enter your account number");
                        string acc = Console.ReadLine();
                        var tra = _iTransactionManager.GetTransaction(refNum);
                        var cus = new Customer(" "," "," "," "," "," "," "," "," "," ",0);
                        if(tra != null)
                        {
                            System.Console.WriteLine($"\nAccount Number= {acc}\tAccoun Balance= {Transaction._accountBalance}\tWithdrawal Amount= {Transaction._withdrawalAmount}\tDeposit Amoun= {Transaction._depositAmount}\tAirtime Amount= {Transaction._airtimeAmount}\tRef num = {Transaction._dateTime}");
                        }
                    }

                    public void DeleteTransaction()
                    {
                        System.Console.WriteLine("Enter the ref number to delete transaction");
                        string rep = Console.ReadLine();
                        _iTransactionManager.DeleteTransaction(rep);
                    }

                    public void ManageTransaction()
                    {
                        System.Console.WriteLine("\n\tEnter 1 to Get Transaction\n\tEnter 2 to Delete Transaction");
                        int choice;
                        int.TryParse(Console.ReadLine(),out choice);
                        switch(choice)
                        {
                            case 1:
                            GetTransactionMenu();
                            break;

                            case 2:
                            DeleteTransaction();
                            break;
                            
                        }
                    }


                   
    }

}