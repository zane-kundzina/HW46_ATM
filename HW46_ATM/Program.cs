using System;

namespace HW46_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create console program which implements functionality of ATM.
            // Solution has to be created using OOP.
            // It should be possible to authorize against ATM (Enter pin code),
            // it should be possible to choose one of the customers accounts, and then peak a balance or take out some amount of money.
            // If it is impossible to take out such amount of money there should be an error message.

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("ATM SIMULATOR");
            Console.WriteLine("-----------------------------------");

            ATM_Manager manager = new ATM_Manager();
            User user = new User();
            
            int userInput;
            bool signedIn = false;
            
            while (true)
            {
                // MENU for guests / unregistered / unsigned users
                manager.PrintGuestMenu();
                userInput = manager.GetUserInput();

                MenuForGuestEnum menuForGuest = (MenuForGuestEnum)userInput;                
                
                switch (menuForGuest)
                {
                    case MenuForGuestEnum.RegisterUser:
                        
                        manager.RegisterUser();
                        break;

                    case MenuForGuestEnum.SignIn:  
                       
                        signedIn = manager.SignIn();

                        // MENU for users if signed in successfully
                        if (signedIn)
                        {
                            while (true)
                            {
                                manager.PrintUserMenu();
                                userInput = manager.GetUserInput();

                                MenuForUserEnum menuForUser = (MenuForUserEnum)userInput;

                                switch (menuForUser)
                                {
                                    case MenuForUserEnum.AddAccount:
                                        user.AddAccount();
                                        break;

                                    case MenuForUserEnum.RemoveAccount:
                                        user.RemoveAccount();
                                        break;

                                    case MenuForUserEnum.Balance:
                                        user.ShowBalance();
                                        break;

                                    case MenuForUserEnum.Deposit:
                                        user.Deposit();
                                        break;

                                    case MenuForUserEnum.Withdraw:
                                        user.Withdraw();
                                        break;

                                    case MenuForUserEnum.ShowAllAccounts:
                                        user.PrintAllAccounts();
                                        break;

                                    case MenuForUserEnum.SignOut:
                                        Console.WriteLine("Signing Out.... Bye");
                                        signedIn = false;
                                        return;
                                    default:
                                        Console.Write("No such command available. Try again...");
                                        continue;
                                }
                            }
                        }                        

                        break;
                    case MenuForGuestEnum.Exit:
                        Console.WriteLine("Good Bye.");
                        
                        return;
                    default:
                        Console.Write("No such command available. Try again...");
                        continue;
                }
                Console.WriteLine();

            }
        }
    }
}
