namespace ATMBankSimulation.entity
{
    public class Accounts
    {
        // tạo các biến đồng thời tạo biến trên database
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _salt;
        private string _accountNumber; // số tài khoản.
        private string _identityCard; // chứng minh nhân dân.
        private decimal _balance; // số dư.
        private string _phone;
        private string _email;
        private string _fullName;
        private string _createdAt;
        private string _updatedAt;
        
        // tạo contructor
        public Accounts(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public Accounts(string username, string password, string confirmPassword, string salt, string accountNumber, string identityCard, decimal balance, string phone, string email, string fullName)
        {
            _username = username;
            _password = password;
            _confirmPassword = confirmPassword;
            _salt = salt;
            _accountNumber = accountNumber;
            _identityCard = identityCard;
            _balance = balance;
            _phone = phone;
            _email = email;
            _fullName = fullName;
        }

        public Accounts(string username, string password, string confirmPassword, string salt, string accountNumber, string identityCard, decimal balance, string phone, string email, string fullName, string createdAt, string updatedAt)
        {
            _username = username;
            _password = password;
            _confirmPassword = confirmPassword;
            _salt = salt;
            _accountNumber = accountNumber;
            _identityCard = identityCard;
            _balance = balance;
            _phone = phone;
            _email = email;
            _fullName = fullName;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }

        public Accounts()
        {
        }
        
        // tạo get set
        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = value;
        }

        public string Salt
        {
            get => _salt;
            set => _salt = value;
        }

        public string AccountNumber
        {
            get => _accountNumber;
            set => _accountNumber = value;
        }

        public string IdentityCard
        {
            get => _identityCard;
            set => _identityCard = value;
        }

        public decimal Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        public string CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public string UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value;
        }
    }
}