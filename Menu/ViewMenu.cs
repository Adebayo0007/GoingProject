using System;
using LegitBankApp.Implementations;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;

namespace LegitBankApp.Menu
{
    public class ViewMenu 
    {
        public void OverAll()
        {

            System.Console.WriteLine("\n\tEnter 1 as Customer\n\tEnter 2 as Admin\n\tEnter 3 as Manger");
            int x;
            int.TryParse(Console.ReadLine(),out x);
            switch(x)
            {
                case 1:
                var customerMenu = new CustomerMenu();
                customerMenu.AllCustomerMenu();
                break;

                case 2:
                System.Console.WriteLine("\n\tEnter 1 to Register Admin\n\tEnter 2 to Login Admin\n\tEnter 3 to manage Transaction");
                int ad;
                int.TryParse(Console.ReadLine(), out ad);
                if(ad == 1)
                {
                    var ball = new AdminMenu();
                    ball.CreateAdmin();
                }
                if(ad ==2)
                {
                     var ball = new AdminMenu();
                    ball.LogIn();

                
                }
                if(ad == 3)
                {
                    var toll = new AdminMenu();
                    System.Console.WriteLine("Enter the company's pass");
                    string pass = Console.ReadLine();
                    string legit = "Zenith0007";
                    if(pass == legit)
                    {
                        toll.ManageTransaction();
                    }
                    
                }
                
                 break;

                 case 3:
                 var admin = new AdminMenu();
                 admin.ManagerMenu();
                 break;
                }
            
        }

    }
}
    