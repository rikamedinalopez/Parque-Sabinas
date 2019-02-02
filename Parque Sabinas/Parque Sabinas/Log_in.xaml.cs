using MySql.Data.MySqlClient;
using Parque_Sabinas.cs;
using Parque_Sabinas.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Parque_Sabinas
{
    /// <summary>
    /// Lógica de interacción para Log_in.xaml
    /// </summary>
    public partial class Log_in : Window
    {
        public Log_in()
        {
            InitializeComponent();
        }
        Connection connection = new Connection();

        private void Btn_log_in_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = connection.Conectando();
            string query = $"select count(*) from users where name_user='{ txtUser.Text }' and pwd_user='{ txtPassword.Password.ToString() }'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int unit_price = Convert.ToInt16(cmd.ExecuteScalar());

            if (unit_price == 1)
            {
                this.Hide();
                new MainWindow().Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
            conn.Close();
            
            //Connection connection = new Connection();
            //connection.Conectar();
            //connection.CrearComando($"select count(*) from users where name_user='{ txtUser.Text }' and pwd_user='{ txtPassword.Password.ToString() }'");
            //DataTable table = new DataTable();
            //table.Load(connection.EjecutarComando());
            //if(table.Rows[0][0].ToString() == "1")
            //{
            //    this.Hide();
            //    new MainWindow().Show();
            //} else
            //{

            //}
        }
    }
}
