using PinValidationData;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW46_ATM
{
    class ATM_Manager
    {
        private List<User> _users { get; set; } = new List<User>();

        private List<string> _usernames { get; set; } = new List<string>();

        private List<string> _pins { get; set; } = new List<string>();


        public void PrintGuestMenu()
        {
            Console.WriteLine("Chose one of following operations:");
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Sign In");
            Console.WriteLine("3 - Exit");
        }

        public void PrintUserMenu()
        {
            Console.WriteLine("Chose one of following operations:");
            Console.WriteLine("1 - Add Account");
            Console.WriteLine("2 - Remove Account");
            Console.WriteLine("3 - Show Balance for Account");
            Console.WriteLine("4 - Deposit");
            Console.WriteLine("5 - Withdraw");
            Console.WriteLine("6 - Show all My Accounts");
            Console.WriteLine("7 - Sign Out");
            Console.WriteLine();
        }

        public int GetUserInput()
        {
            int userInput;

            while (true)
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.Write("Input was not a number! Try again: ");
                    continue;
                }
            }

            return userInput;
        }

        public void RegisterUser()
        {
            User user = new User();

            while (true)
            {
                Console.Write("Enter username (At least 4 digits/characters): ");
                var username1 = Console.ReadLine();

                if (_usernames.Contains(username1))
                {
                    Console.WriteLine("Username already taken. Chose another one: ");
                    continue;
                }

                Console.Write("Re-Enter username: ");
                var username2 = Console.ReadLine();

                var resultUsername = Username_Validator.ValidateUsername(username1, username2);

                if (!resultUsername.Username_IsValid)
                {
                    foreach (var item in resultUsername.Messages)
                    {
                        Console.WriteLine(item);
                    }
                    return;
                }


                Console.WriteLine("Username OK.");
                _usernames.Add(username1);
                user.Username = username1;
                Console.WriteLine();
                break;
            }

            Console.Write("Enter PIN (6 digits/characters): ");
            var pin1 = Console.ReadLine();

            Console.Write("Re-Enter PIN: ");
            var pin2 = Console.ReadLine();

            var resultPIN = PIN_Validator.ValidatePIN(pin1, pin2);

            if (!resultPIN.PIN_IsValid)
            {
                foreach (var item in resultPIN.Messages)
                {
                    Console.WriteLine(item);
                }
                return;
            }

            Console.WriteLine("PIN OK.");
            user.PIN = pin1;
            _pins.Add(pin1);
            _users.Add(user);
            Console.WriteLine("Now you are a registered user. Remember your credentials!");
            user.PrintProfile();
            Console.WriteLine();
        }

        public bool SignIn()
        {
            bool signedIn = false;            

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (!_usernames.Contains(username))
            {
                Console.WriteLine("Such user is not registered! Please try again! ");
                return signedIn = false;
            }

            Console.Write("Please enter PIN: ");
            string pin = Console.ReadLine();

            if (!_pins.Contains(pin))
            {
                Console.WriteLine("PIN incorrect! Please try again!");
            }

            foreach (var user in _users)
            {
                if (user.Username == username && user.PIN == pin)
                {
                    signedIn = true;
                    Console.WriteLine("Credentials OK. You are signed in.");
                    Console.WriteLine();
                    break;
                }
            }
            
            return signedIn;
        }
    }
}
