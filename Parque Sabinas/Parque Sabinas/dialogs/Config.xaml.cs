using Parque_Sabinas.database;
using Parque_Sabinas.Properties;
using System;
using System.Collections.Generic;
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

namespace Parque_Sabinas.dialogs
{
    /// <summary>
    /// Lógica de interacción para Config.xaml
    /// </summary>
    public partial class Config : Window
    {
        public Config()
        {
            InitializeComponent();
        }

        Connection connection = new Connection();
        bool check;

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtIP.Text = Settings.Default.IPDatabase;
            txtPort.Text = Settings.Default.PortDatabase;
            txtUser.Text = Settings.Default.UserDatabase;
            txtPassword.Password = Settings.Default.PwdDatabase;
        }

        private void BtnCheckConnextion_Click(object sender, RoutedEventArgs e)
        {            
            connection.Ip = txtIP.Text.ToString().Trim();
            connection.Port = txtPort.Text.ToString().Trim();
            connection.User = txtUser.Text.ToString().Trim();
            connection.Pwd = txtPassword.Password.ToString().Trim();

            if (connection.VerifyConnection())
            {
                check = true;
                btnSaveConfig.IsEnabled = true;
            } else
            {
                check = false;
                btnSaveConfig.IsEnabled = false;
            }
        }

        private void BtnSaveConfig_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.IPDatabase = txtIP.Text.ToString().Trim();
            Settings.Default.PortDatabase = txtPort.Text.ToString().Trim();
            Settings.Default.UserDatabase = txtUser.Text.ToString().Trim();
            Settings.Default.PwdDatabase = txtPassword.Password.ToString().Trim();
            Settings.Default.Save();
            this.Close();
        }

        private void TxtIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (check)
            {
                btnSaveConfig.IsEnabled = false;
            }
        }

        private void TxtPort_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (check)
            {
                btnSaveConfig.IsEnabled = false;
            }
        }

        private void TxtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (check)
            {
                btnSaveConfig.IsEnabled = false;
            }
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (check)
            {
                btnSaveConfig.IsEnabled = false;
            }
        }
    }
}
