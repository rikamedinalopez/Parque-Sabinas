using MySql.Data.MySqlClient;
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
using Parque_Sabinas.cs;

namespace Parque_Sabinas.dialogs
{
    /// <summary>
    /// Lógica de interacción para Sections.xaml
    /// </summary>
    public partial class Sections : Window
    {
        public Sections()
        {
            InitializeComponent();
        }

        Connection conn = new Connection();
        cs.Section section = new cs.Section();
        int indexDataGridSection;
        int indexDataGridCaja;

        DataRowView row_selectedSection;
        DataRowView row_selectedCaja;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            dataGridSections.DataContext = section.LoadSections();
        }

        private void BtnAddSection_Click(object sender, RoutedEventArgs e)
        {
            AddSection addSection = new AddSection();
            addSection.ShowDialog();
        }

        private void BtnAddCaja_Click(object sender, RoutedEventArgs e)
        {
            AddCaja addCaja = new AddCaja();
            addCaja.ShowDialog();
        }

        private void DataGridSections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            row_selectedSection = gd.SelectedItem as DataRowView;
            if (row_selectedSection != null)
            {
                section.Id_section = row_selectedSection[0].ToString();
                indexDataGridSection = gd.SelectedIndex;
                dataGridCajas.IsEnabled = true;
                btnAddCaja.IsEnabled = true;
                btnDeleteSection.IsEnabled = true;
                dataGridCajas.DataContext = section.LoadCajas();
            } else
            {
                
                dataGridCajas.IsEnabled = false;
                btnAddCaja.IsEnabled = false;
            }

            
        }

        private void Window_Activated(object sender, EventArgs e)
        {            
            dataGridSections.DataContext = section.LoadSections();
            if (indexDataGridSection > 0)
            {
                dataGridSections.SelectedIndex = indexDataGridSection;
                dataGridCajas.IsEnabled = true;
                btnAddCaja.IsEnabled = true;
            } else
            {
                //dataGridSections.SelectedIndex = 0;
                dataGridCajas.IsEnabled = true;
                btnAddCaja.IsEnabled = true;
            }
            
            
            
        }

        private void BtnDeleteSection_Click(object sender, RoutedEventArgs e)
        {            
            if (section.deletSection() == 1)
            {
                MessageBox.Show("Seccion eliminada correctamente", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error al emlimianr la seccion", "OK", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeleteCaja_Click(object sender, RoutedEventArgs e)
        {
            if (section.deletCaja() == 1)
            {
                MessageBox.Show("Caja eliminada correctamente", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error al emlimianr la Caja", "OK", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGridCajas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            row_selectedCaja = gd.SelectedItem as DataRowView;
            if (row_selectedCaja != null)
            {
                section.Id_caja = row_selectedCaja[0].ToString();
                indexDataGridCaja = gd.SelectedIndex;
                btnDeleteCaja.IsEnabled = true;                
            }
            else
            {
                dataGridCajas.IsEnabled = false;
                btnAddCaja.IsEnabled = false;
                btnDeleteCaja.IsEnabled = false;
            }
        }
    }
}
