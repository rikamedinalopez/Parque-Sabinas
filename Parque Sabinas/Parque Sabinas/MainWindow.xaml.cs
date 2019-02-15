using Parque_Sabinas.cs;
using Parque_Sabinas.dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Parque_Sabinas.Properties;

namespace Parque_Sabinas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Buyout compra = new Buyout();
        Buyout buyout = new Buyout();
        UserInfo user = new UserInfo();
        int cont = 1;
        int subtotal = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            comboBoxTypeCustomer.ItemsSource = buyout.Customers().Tables[0].DefaultView;
            comboBoxTypeCustomer.DisplayMemberPath = "type_customer";
            comboBoxTypeCustomer.SelectedValuePath = "id_type_customer";
            comboBoxTypeCustomer.SelectedIndex = 0;
            compra.Customer = comboBoxTypeCustomer.Text;
            compra.Price = compra.CheckPrice();
            txtUnitprice.Text = compra.CheckPrice() + "$";


            //Asignar valores

            if (!string.IsNullOrEmpty(user.Section))
            {
                txtSection.Text = user.Section;
            }
            else
            {
                txtSection.Text = "No asignada";
            }

            if (!string.IsNullOrEmpty(Settings.Default.NumberCashBox))
            {
                txtBoxNumber.Text = Settings.Default.NumberCashBox;
            } else
            {
                txtBoxNumber.Text = "No asignada";
            }                        
            
        }        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            
            Log_in login = new Log_in();
            login.Show();
            this.Close();
        }

        private void BtnConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigDevice configDevice = new ConfigDevice();
            configDevice.ShowDialog();
            
        }

        private void Btn_AddToDataGrid_Click(object sender, RoutedEventArgs e)
        {            
            compra.Quantity = txtQuianity.Text;
            compra.SubTotal = compra.SubTotalPrice();
            subtotal += compra.SubTotal;
            txtQuanityTotal.Text = Convert.ToString(subtotal) + "$";
            compra.Quantity = "x" + compra.Quantity;
            dataGridShowTotal.Items.Add(compra);            

            ResetCont();
        }        

        private void Btn_Minus_Click(object sender, RoutedEventArgs e)
        {
            
            if (cont > 1)
            {
                cont--;
                int a = cont;
                txtQuianity.Text = Convert.ToString(a);
            }                                     
        }

        private void Btn_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (cont < 20)
            {
                cont++;
                int a = cont;
                txtQuianity.Text = Convert.ToString(a);
            }
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            ResetCont();
            dataGridShowTotal.Items.Clear();
            subtotal = 0;
            txtQuanityTotal.Text = Convert.ToString(subtotal);
        }

        private void ComboBoxTypeCustomer_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {            
            compra.Customer = comboBoxTypeCustomer.Text;
            compra.Price = compra.CheckPrice();
            txtUnitprice.Text = compra.CheckPrice() + "$";            


        }

        public void ResetCont()
        {
            cont = 1;
            txtQuianity.Text = Convert.ToString(cont);
        }

        private void Btn_Customers_Click(object sender, RoutedEventArgs e)
        {
            Customers windowCustomers = new Customers();
            windowCustomers.ShowDialog();
        }

        private void Btn_Users_Click(object sender, RoutedEventArgs e)
        {
            Users windowUsers = new Users();
            windowUsers.ShowDialog();
        }

        private void Btn_Corte_Click(object sender, RoutedEventArgs e)
        {
            Corte windowCorte = new Corte();
            windowCorte.ShowDialog();
        }

        private void Btn_Movements_Click(object sender, RoutedEventArgs e)
        {
            Movements moviments = new Movements();
            moviments.ShowDialog();
        }

        
        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.E))
            {

                ConfigDevice config = new ConfigDevice();
                config.ShowDialog();

            }
        }

        private void Btn_Sections_Click(object sender, RoutedEventArgs e)
        {
            Sections section = new Sections();
            section.ShowDialog();
        }
    }
}
