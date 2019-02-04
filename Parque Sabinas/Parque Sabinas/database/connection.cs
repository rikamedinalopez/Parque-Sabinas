using MySql.Data.MySqlClient;
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

        public MySqlConnection Conectando()
        {
            MySqlConnection cone = new MySqlConnection("Server=localhost;Port=3306;UserID=root;Password=31032014;Database=park_sabinas");
            cone.Open();
            return cone;
        }

    }
}
