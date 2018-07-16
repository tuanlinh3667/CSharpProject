using System;
using ATMBankSimulation.collection;
using ATMBankSimulation.utility;

namespace ATMBankSimulation.view
{
    public class MainView
    {
        private static AccountController accController = new AccountController();

        public static void GenerateGeneralMenu()
        {
            while (true)
            {
                Console.WriteLine("---------WELCOME TO SPRING HERO BANK---------");
                Console.WriteLine("1. Register for free.");
                Console.WriteLine("2. Login.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3): ");
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:
                        accController.Register();
                        break;
                    case 2:
                        if (accController.DoLogin())
                        {
                            Console.WriteLine("Login success.");
                        }

                        break;
                    case 3:
                        Console.WriteLine("See you later.");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }   
            }
        }
    }
}