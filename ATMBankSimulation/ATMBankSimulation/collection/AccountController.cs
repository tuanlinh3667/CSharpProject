using System;

namespace ATMBankSimulation.collection
{
    public class AccountController
    {
        public void Register()
        {
            // Lấy thông tin đăng ký phía người dùng.
            Console.WriteLine("Please enter account information");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Confirm Password: ");
            var cpassword = Console.ReadLine();
            Console.WriteLine("Identity Card: ");
            var identityCard = Console.ReadLine();
            Console.WriteLine("Full Name: ");
            var fullName = Console.ReadLine();
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Phone: ");
            var phone = Console.ReadLine();
           
        }

        public Boolean DoLogin()
        {
            // Lấy thông tin đăng nhập phía người dùng.
            Console.WriteLine("Please enter account information");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            return true;
        }

        public void Withdraw()
        {
            Console.WriteLine("Withdraw.");
        }

        public void Deposit()
        {
            Console.WriteLine("Deposit.");
        }

        public void Transfer()
        {
            Console.WriteLine("Transfer.");
        }

        public void CheckBalance()
        {
            Console.WriteLine("Check Balance");
        }
    }
}