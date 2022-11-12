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
            System.Console.WriteLine("\n\tEnter 1 as Customer\n\tEnter 2 as Admin");
            int x;
            int.TryParse(Console.ReadLine(),out x);
            switch(x)
            {
                case 1:
                var customerMenu = new CustomerMenu();
                customerMenu.AllCustomerMenu();
                break;

                case 2:
                var adminMenu = new AdminMenu();
                adminMenu.AllAdminMenu();
                break;
            }
        }

    }
}
    