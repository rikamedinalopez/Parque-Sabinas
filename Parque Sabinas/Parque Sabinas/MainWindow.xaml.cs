using Parque_Sabinas.cs;
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
        int cont = 1;
        int subtotal = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Buyout buyout = new Buyout();
            comboBoxTypeCustomer.ItemsSource = buyout.Customers().Tables[0].DefaultView;
            comboBoxTypeCustomer.DisplayMemberPath = "type_customer";
            comboBoxTypeCustomer.SelectedValuePath = "id_type_customer";
            comboBoxTypeCustomer.SelectedIndex = 0;
            compra.Customer = comboBoxTypeCustomer.Text;
            compra.Price = compra.CheckPrice();
            txtUnitprice.Text = compra.CheckPrice() + "$";
        }        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Log_in login = new Log_in();
            login.Show();
        }

        private void BtnConfig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddToDataGrid_Click(object sender, RoutedEventArgs e)
        {            
            compra.Quantity = Convert.ToInt16(txtQuianity.Text);
            subtotal += compra.SubTotalPrice();
            txtQuanityTotal.Text = Convert.ToString(subtotal) + "$";

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
    }
}
