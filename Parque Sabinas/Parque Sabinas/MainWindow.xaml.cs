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

        DataTable table = new DataTable();

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnConfig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddToDataGrid_Click(object sender, RoutedEventArgs e)
        {


            table.Rows.Add("2", "Adulto", "50$");
            table.Rows.Add("1", "Niño", "25$");

            dataGridShowTotal.DataContext = table;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            table.Columns.Add("Cantidad", typeof(string));
            table.Columns.Add("Tipo de cliente", typeof(string));
            table.Columns.Add("Precio", typeof(string));
        }
    }
}
