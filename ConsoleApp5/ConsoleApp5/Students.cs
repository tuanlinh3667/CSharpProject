using System;

namespace ConsoleApp5
{
    public class Students
    {
        private string _rollNumber;
        private string _name;
        private string _phone;
        private string _email;

        public Students()
        {
        }

        public Students(string rollNumber, string name, string phone, string email)
        {
            _rollNumber = rollNumber;
            _name = name;
            _phone = phone;
            _email = email;
        }

        public string RollNumber
        {
            get => _rollNumber;
            set => _rollNumber = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
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

//        public override string ToString()
//        {
//            return .ToString();
//        }
    }
}