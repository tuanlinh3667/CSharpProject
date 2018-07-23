using System;
using SpringHeroBankASSI.entity;
using SpringHeroBankASSI.model;
using SpringHeroBankASSI.utility;

namespace SpringHeroBankASSI.collection
{
    public class AccountController
    {
        private AccountModel model = new AccountModel();

        public void Register()
        {
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
            var account = new Account(username, password, cpassword, identityCard, phone, email, fullName);
            var errors = account.CheckValid();
            if (errors.Count == 0)
            {
                model.Save(account);
                Console.WriteLine("Register success!");
                Console.ReadLine();
            }
            else
            {
                Console.Error.WriteLine("Please fix following errors and try again.");
                foreach (var messagErrorsValue in errors.Values)
                {
                    Console.Error.WriteLine("+ {0}", messagErrorsValue);
                }

                Console.ReadLine();
            }
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
            var account = new Account(username, password);
            // Tiến hành validate thông tin đăng nhập. Kiểm tra username, password khác null và length lớn hơn 0.
            var errors = account.ValidLoginInformation();
            if (errors.Count > 0)
            {
                Console.WriteLine("Invalid login information. Please fix errors below.");
                foreach (var messagErrorsValue in errors.Values)
                {
                    Console.Error.WriteLine(messagErrorsValue);
                }

                Console.ReadLine();
                return false;
            }

            account = model.GetAccountByUserName(username);
            if (account == null)
            {
                // Sai thông tin username, trả về thông báo lỗi không cụ thể.
                Console.WriteLine("Invalid login information. Please try again.");
                return false;
            }

            // Băm password người dùng nhập vào kèm muối và so sánh với password đã mã hoá ở trong database.
            if (account.Password != Hash.GenerateSaltedSHA1(password, account.Salt))
            {
                // Sai thông tin password, trả về thông báo lỗi không cụ thể.
                Console.WriteLine("Invalid login information. Please try again.");
                return false;
            }

            // Login thành công. Lưu thông tin đăng nhập ra biến static trong lớp Program.
            Program.CurrentLoggedIn = account;
            return true;
        }

        public void Withdraw()
        {
            Console.WriteLine("Withdraw.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please enter amount to withdraw: ");
            var amount = Utility.GetUnsignDecimalNumber();
            Console.WriteLine("You are going to withdraw {0} from your account.", amount);
            Console.WriteLine("Press 'Y' to confirm this transaction, press any other button to cancel....");
            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                Console.WriteLine("Your transaction have been cancelled");
                return;
            }
            var historyTransaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Type = Transaction.TransactionType.WITHDRAW,
                Amount = amount,
                Content = "Withdraw " + amount + " from account",
                SenderAccountNumber = Program.CurrentLoggedIn.AccountNumber,
                ReceiverAccountNumber = Program.CurrentLoggedIn.AccountNumber,
                Status = Transaction.ActiveStatus.DONE
            };
            if (model.UpdateBalance(Program.CurrentLoggedIn, historyTransaction))
            {
                Console.WriteLine("Transaction success!");
            }
            else
            {
                Console.WriteLine("Transaction fails, please try again!");
            }
            Program.CurrentLoggedIn = model.GetAccountByUserName(Program.CurrentLoggedIn.Username);
            Console.WriteLine("Your current balance: " + Program.CurrentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
        }

        public void Deposit()
        {
            Console.WriteLine("Deposit.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please enter amount to deposit: ");
            var amount = Utility.GetUnsignDecimalNumber();
            Console.WriteLine("You are going to deposit {0} into your account.", amount);
            Console.WriteLine("Press 'Y' to confirm this transaction, press any other button to cancel....");
            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                Console.WriteLine("Your transaction have been cancelled");
                return;
            }
            var historyTransaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Type = Transaction.TransactionType.DEPOSIT,
                Amount = amount,
                Content = "Deposit " + amount + " into account",
                SenderAccountNumber = Program.CurrentLoggedIn.AccountNumber,
                ReceiverAccountNumber = Program.CurrentLoggedIn.AccountNumber,
                Status = Transaction.ActiveStatus.DONE
            };
            if (model.UpdateBalance(Program.CurrentLoggedIn, historyTransaction))
            {
                Console.WriteLine("Transaction success!");
            }
            else
            {
                Console.WriteLine("Transaction fails, please try again!");
            }
            Program.CurrentLoggedIn = model.GetAccountByUserName(Program.CurrentLoggedIn.Username);
            Console.WriteLine("Your current balance: " + Program.CurrentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
        }

        public void Transfer()
        {
            Console.WriteLine("Transfer.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please enter account number you want to transfer: ");
            var receiverAccountNumber = Console.ReadLine();
            var receiverAccount = model.GetAccountByAccountNumber(receiverAccountNumber);
            if (receiverAccount == null)
            {
                Console.WriteLine("This is not a valid account number! Please try again");
                return;
            }
            Console.WriteLine("Please enter amount to transfer: ");
            var amount = Utility.GetUnsignDecimalNumber();
            Console.WriteLine("Please enter message content: ");
            var content = Console.ReadLine();
            Console.WriteLine("Your are going to transfer money to an account with these information:");
            Console.WriteLine("Receiver account number: {0}", receiverAccountNumber);
            Console.WriteLine("Receiver full name: {0}", receiverAccount.FullName);
            Console.WriteLine("Amount: {0}", amount);
            Console.WriteLine("Press 'Y' to confirm this transaction, press any other button to cancel....");
            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                Console.WriteLine("Your transaction have been cancelled");
                return;
            }

            // create transaction log
            var historyTransaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Type = Transaction.TransactionType.TRANSFER,
                Amount = amount,
                Content = content,
                SenderAccountNumber = Program.CurrentLoggedIn.AccountNumber,
                ReceiverAccountNumber = receiverAccountNumber,
                Status = Transaction.ActiveStatus.DONE
            };
            if (model.UpdateTransferBalance(Program.CurrentLoggedIn, historyTransaction, receiverAccountNumber))
            {
                Console.WriteLine("Transaction success!");
            }
            else
            {
                Console.WriteLine("Transaction fails, please try again!");
            }
            Program.CurrentLoggedIn = model.GetAccountByUserName(Program.CurrentLoggedIn.Username);
            Console.WriteLine("Your current balance: " + Program.CurrentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
        }

        public void CheckBalance()
        {
            Program.CurrentLoggedIn = model.GetAccountByUserName(Program.CurrentLoggedIn.Username);
            Console.WriteLine("Account Information");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Full name: " + Program.CurrentLoggedIn.FullName);
            Console.WriteLine("Account number: " + Program.CurrentLoggedIn.AccountNumber);
            Console.WriteLine("Balance: " + Program.CurrentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
        }
    }
}