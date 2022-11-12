using System;
using LegitBankApp.Implementations;
using LegitBankApp.Interfaces;
using LegitBankApp.Model;


namespace LegitBankApp.Menu
{
    public class FileHandlingMenu
    {
        public void ReloadAllFiles()
        {
            IAdminManager _adminManager = new AdminManager();
            _adminManager.ReadFromFileOfAdmin();
            ICustomerManager _customerManager = new CustomerManager();
            _customerManager.ReadFromFileOfCustomer();
            ITransactionManager _transactionManager = new TransactionManager();
            _transactionManager.ReadFromFileOfTransaction();
        }
            
    }
}