using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque_Sabinas.database
{
    class Connection
    {
        

        protected static String Query = "server=localhost; Port=3306; database=parque_sabinas; Uid=root; Pwd=1234;";
        MySqlConnection Conexion = new MySqlConnection(Query);
        MySqlCommand Comando = new MySqlCommand();

        public Connection()
        {
            Conexion.ConnectionString = Query;
        }

        public void Conectar()
        {
            if (Conexion.State.Equals(ConnectionState.Closed))
            {
                Conexion.Open();
            }
        }

        public void Desconectar()
        {
            if (Conexion.State.Equals(ConnectionState.Open))
            {
                Conexion.Close();
            }
        }

        public void CrearComando(string sentenciaSQL)
        {
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = sentenciaSQL;
        }

        public int EjecutarComandoInt()
        {
            return Comando.ExecuteNonQuery();
        }

        public MySqlDataReader EjecutarComando()
        {
            MySqlDataReader LeerDatos = Comando.ExecuteReader();
            return LeerDatos;
        }
    }
}
