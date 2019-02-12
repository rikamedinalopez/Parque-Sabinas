using MySql.Data.MySqlClient;
using Parque_Sabinas.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque_Sabinas.database
{
    public class Connection
    {

        private static string _ip;
        private static string _port;
        private static string _user;
        private static string _pwd;

        public string Ip { get => _ip; set => _ip = value; }
        public string Port { get => _port; set => _port = value; }
        public string User { get => _user; set => _user = value; }
        public string Pwd { get => _pwd; set => _pwd = value; }

        public MySqlConnection Conectando()
        {
            MySqlConnection cone = new MySqlConnection($"Server={Settings.Default.IPDatabase};Port={Settings.Default.PortDatabase};UserID={Settings.Default.UserDatabase};Password={Settings.Default.PwdDatabase};Database=parque_sabinas");
            cone.Open();
            return cone;
        }

        public bool VerifyConnection()
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = $"Server={ _ip };Port={ _port };UserID={ _user };Password={ _pwd };Database=parque_sabinas";

            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
