﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SpringHeroBankASSI.entity
{
    public class Account
    {
        public enum ActiveStatus
        {
            INACTIVE = 0,
            ACTIVE = 1,
            LOCKED = 2
        }

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
        private ActiveStatus _status;

        public void GenerateAccountNumber()
        {
            this._accountNumber = Guid.NewGuid().ToString();
        }

        public Account(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public Account(string username, string password, string confirmPassword, string identityCard, string phone,
            string email, string fullName)
        {
            GenerateAccountNumber();
            _username = username;
            _password = password;
            _confirmPassword = confirmPassword;
            _identityCard = identityCard;
            _phone = phone;
            _email = email;
            _fullName = fullName;
        }

        public Account(string username, string password, string salt, string accountNumber, string identityCard,
            decimal balance, string phone, string email, string fullName, string createdAt, string updatedAt,
            ActiveStatus status)
        {
            _username = username;
            _password = password;
            _salt = salt;
            _accountNumber = accountNumber;
            _identityCard = identityCard;
            _balance = balance;
            _phone = phone;
            _email = email;
            _fullName = fullName;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _status = status;
        }

        public Account()
        {
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = value;
        }

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

        public ActiveStatus Status
        {
            get => _status;
            set => _status = value;
        }

        public Dictionary<string, string> CheckValid()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(this._username))
            {
                errors.Add("username", "Username can not be null or empty.");
            }
            else if (this._username.Length < 6 || this._username.Length > 30)
            {
                errors.Add("username", "Username must be between 6 and 30 characters.");
            }

            if (string.IsNullOrEmpty(this._password))
            {
                errors.Add("password", "Password can not be null or empty.");
            }
            else if (this._password != this._confirmPassword)
            {
                errors.Add("password", "Confirm password does not match.");
            }

            if (string.IsNullOrEmpty(this._fullName))
            {
                errors.Add("fullName", "Full name can not be null or empty");
            }
            else if (this._fullName.Length < 6 || this._fullName.Length > 50)
            {
                errors.Add("fullName", "Full name must be between 6 and 50 characters.");
            }

            if (string.IsNullOrEmpty(this._email))
            {
                errors.Add("email", "Email can not be null or empty");
            }
            else if (!Regex.IsMatch(this._email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")
            )
            {
                errors.Add("email", "This is not a valid email address");
            }

            if (string.IsNullOrEmpty(this._phone))
            {
                errors.Add("phone", "Phone number can not be null or empty");
            }

            return errors;
        }

        public Dictionary<string, string> ValidLoginInformation()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(this._username))
            {
                errors.Add("username", "Username can not be null or empty.");
            }

            if (string.IsNullOrEmpty(this._password))
            {
                errors.Add("password", "Password can not be null or empty.");
            }

            return errors;
        }
    }
}