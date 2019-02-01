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

        private void Btn_log_in_Click(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection();
            connection.Conectar();
            connection.CrearComando($"select count(*) from users where name_user='{ txtUser.Text }' and pwd_user='{ txtPassword.Password.ToString() }'");
            DataTable table = new DataTable();
            table.Load(connection.EjecutarComando());
            if(table.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new MainWindow().Show();
            } else
            {

            }
        }
    }
}
