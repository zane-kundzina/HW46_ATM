using System;
using System.Collections.Generic;
using System.Text;

namespace HW46_ATM
{
    public class User
    {
        public string Username { get; set; }

        public string PIN { get; set; }        

        private List<Account> _accounts = new List<Account>();

        public void PrintProfile()
        {
            Console.WriteLine($"Username: {Username} | PIN: {PIN}");
        }

        public void AddAccount()
        {
            Account account = new Account();
            Console.Write("Enter name for new account:");
            string accountName = Console.ReadLine();

            account.Name = accountName;

            _accounts.Add(account);
            Console.WriteLine($"Account with name \"{accountName}\"created!");
            Console.WriteLine();
        }

        private Account FindAccount()
        {
            Account accountToFind = new Account();
            Console.Write("Enter account's name: ");

            string name = Console.ReadLine();

            try
            {
                accountToFind = _accounts.Find(account => (account.Name == name));
                return accountToFind;
            }
            catch (Exception)
            {
                Console.WriteLine("There is no such account.");
                Console.WriteLine();
                return null;
            }
            
        }

        public void RemoveAccount()
        {
            Account accountToRemove = FindAccount();

            if (accountToRemove != null)
            {
                _accounts.Remove(accountToRemove);
                Console.WriteLine($"Account \"{accountToRemove.Name}\" removed from your list.");
            }
            else
            {
                Console.WriteLine("There is no account with such name.");
            }
            Console.WriteLine();
        }

        public void Deposit()
        {
            Account accountToDeposit = FindAccount();
            ATM_Manager manager = new ATM_Manager();
            int balance = 0;
            int sumToDeposit;

            if (accountToDeposit != null)
            {
                Console.WriteLine($"Account [{accountToDeposit.Name}]:");
                Console.Write("Enter sum to deposit: ");
                sumToDeposit = manager.GetUserInput();
                balance += sumToDeposit;
                accountToDeposit.Balance = balance;
                Console.WriteLine($"Sum of {sumToDeposit} EUR added to account \"{accountToDeposit.Name}\"");
                accountToDeposit.PrintInfo();
                Console.WriteLine();
            }
        }

        public void Withdraw()
        {
            Account accountToWithdraw = FindAccount();
            ATM_Manager manager = new ATM_Manager();

            int sumToWithDraw;

            if (accountToWithdraw != null)
            {
                Console.WriteLine($"Account to withdraw from: [{accountToWithdraw.Name}]:");
                Console.Write("Enter sum to withdraw: ");
                sumToWithDraw = manager.GetUserInput();
                if (accountToWithdraw.Balance > sumToWithDraw)
                {
                    Console.WriteLine($"Withdraw successful. Take your sum: {sumToWithDraw} EUR");
                    accountToWithdraw.Balance -= sumToWithDraw;
                    accountToWithdraw.PrintInfo();
                }
                else
                {
                    Console.WriteLine("Insufficient funds!");
                }
            }
            Console.WriteLine();
        }

        public void ShowBalance()
        {
            Account accountToShow = FindAccount();
            if (accountToShow != null)
            {
                accountToShow.PrintInfo();
            }
            else
            {
                Console.WriteLine("There is no account with such name.");
            }
            Console.WriteLine();
        }

        public void PrintAllAccounts()
        {
            if (_accounts.Count > 0)
            {
                foreach (var account in _accounts)
                {
                    account.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("You have no account yet. Create one. ;)");
            }

            Console.WriteLine();
        }
        
    }
}
