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
    /// Lógica de interacción para AddCaja.xaml
    /// </summary>
    public partial class AddCaja : Window
    {
        public AddCaja()
        {
            InitializeComponent();
        }
        cs.Section section = new cs.Section();

        private void BtnSaveCaja_Click(object sender, RoutedEventArgs e)
        {
            section.NameCaja = txtCajaName.Text;
            if (section.addCaja() == 1)
            {
                MessageBox.Show("Caja agregada correctamente", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar la caja", "OK", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
