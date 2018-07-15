﻿using System.Data;
using MySql.Data.MySqlClient;

namespace SpringHeroBankASSI.model
{
    public class DbConnection
    {
        private DbConnection()
        {
        }
        
        // tạo ra các biến thông tin của database
        private const string DatabaseName = "banksimulation";
        private const string ServerName = "localhost";
        private const string ServerPort = "3306";
        private const string Uid = "root";
        private const string Password = "";
        private const string SslMode = "none";
        private const string PersistSecurityInfo = "True";
        
        // khai báo biến kết nối với database
        private MySqlConnection _connection = null;

        public MySqlConnection Connection
        {
            get { return _connection; }
        }
        
        
        private static DbConnection _instance = null;
        
        // chú ý phần này có tác dụng là để kết nối luôn là duy nhất    
        public static DbConnection Instance()
        {
            return _instance != null ? _instance : (_instance = new DbConnection());
        }
        
        // Mở kết nối
        public void OpenConnection()
        {
            if (_connection == null)
            {
                var connString =
                    string.Format(
                        "Server={0}; database={1}; UID={2}; password={3}; persistsecurityinfo={4};port={5};SslMode={6}",
                        ServerName, DatabaseName, Uid, Password, PersistSecurityInfo, ServerPort, SslMode);
                _connection = new MySqlConnection(connString);
                _connection.Open();
            }
            else if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        
        // Đóng kết nối
        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }

    internal class MySqlConnection
    {
    }
}