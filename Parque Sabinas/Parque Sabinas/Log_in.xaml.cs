using MySql.Data.MySqlClient;
using Parque_Sabinas.cs;
using Parque_Sabinas.database;
using Parque_Sabinas.dialogs;
using Parque_Sabinas.Properties;
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
        UserInfo user = new UserInfo();

        private void Btn_log_in_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Settings.Default.IPDatabase))
            {
                if (!string.IsNullOrEmpty(txtUser.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Password.ToString().Trim()))
                {
                    MySqlConnection conn;
                    try
                    {
                        conn = connection.Conectando();
                        MySqlCommand cmd = new MySqlCommand(string.Format($"select count(*) count, id_user, name_user, user_name, pwd_user, type_user, (Select name_section from sections where users.id_section = sections.id_section and status = 'A') section from users where user_name='{ txtUser.Text }' and pwd_user='{ txtPassword.Password.ToString() }';"), conn);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable tableUser = new DataTable();
                        adapter.Fill(tableUser);


                        if (tableUser.Rows[0][0].ToString() == "1")
                        {
                            user.Id = Convert.ToInt16(tableUser.Rows[0]["id_user"]);
                            user.Name_User = tableUser.Rows[0]["name_user"].ToString();
                            user.User_Name = tableUser.Rows[0]["user_name"].ToString();
                            user.Type_User = tableUser.Rows[0]["type_user"].ToString();
                            user.Section = tableUser.Rows[0]["section"].ToString();
                            new MainWindow().Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error usuario o contraseña incorrectos");
                        }
                        conn.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error conexion base de datos");
                    }


                }
                else
                {
                    MessageBox.Show("Error campos vacios");
                }
            } else
            {
                MessageBox.Show("Contacte con su administrador para configurar la aplicacion");
            }
            
            
            
  
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.O))
            {

                Config config = new Config();
                config.ShowDialog();

            }

        }
    }
}
