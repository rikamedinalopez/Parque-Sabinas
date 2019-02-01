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

        int cont = 1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnConfig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddToDataGrid_Click(object sender, RoutedEventArgs e)
        {
            Buyout compra = new Buyout();
            compra.Quantity = txtQuianity.Text.ToString();
            compra.Customer = comboBoxTypeCustomer.Text.ToString();
            compra.Price = "20";

            dataGridShowTotal.Items.Add(compra);
            DataTable table = new DataTable();

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
            dataGridShowTotal.Items.Clear();
        }
    }
}
