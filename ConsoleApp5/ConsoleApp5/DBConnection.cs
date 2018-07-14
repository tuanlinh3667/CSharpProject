using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ConsoleApp5
{
    public class DBConnection
    {
        //Tạo các biến để tham chiếu sử dụng
        private string server;
        private string databaseName;
        private string uid;
        private string password;
        
        private DBConnection()
        {
            IsConnect();
        }
        
        private string databaseName = String.Empty;

        public string DatabaseName
        {
            get => databaseName;
            set => databaseName = value;
        }
        
//        property
        public string Password { get; set; }

        private MySqlConnection connection = null;

        public MySqlConnection Connection => connection;

        private static DBConnection _instance = null;

        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
                return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                    string conntring = string.Format("Server=localhost; database={0}; UID=root; password=; persistsecurityinfo=True; port=3306; SslMode=none", databaseName);
                    connection = new MySqlConnection(conntring);
                    connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }

        public static void Insert()
        {
            string query = "INSERT INTO students (_rollNumber, _name, _phone, _) VALUES('John Smith', '33')";
            //open connection
            if (this.IsConnect() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
        
                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.Close();
            }
        }

        static void Main(string[] args)
        {
            Insert();
        }

//        public void Update()
//        {
//            
//        }
//
//        public void Delete()
//        {
//            
//        }
//
//        public List<string>[] Select()
//        {
//            
//        }
//
//        public int Count()
//        {
//            
//        }
//
//        public void Backup()
//        {
//            
//        }
//
//        public void Restore()
//        {
//            
//        }
    }
}