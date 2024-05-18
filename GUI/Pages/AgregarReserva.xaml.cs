using BLL;
using Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para AgregarReserva.xaml
    /// </summary>
    public partial class AgregarReserva : Page
    {

        ClienteBLL clienteBLL = new ClienteBLL();
        public AgregarReserva()
        {
            InitializeComponent();
        }

        public void btnFecha_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RegistrarReserva_Click(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbCedula_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string cedulaIncompleta = cmbCedula.Text + e.Text;

            List<Cliente> clientesCoincidentes = BuscarClientesPorCedula(cedulaIncompleta);

            cmbCedula.ItemsSource = clientesCoincidentes;
        }

        private List<Cliente> BuscarClientesPorCedula(string cedula)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            List<Cliente> clientes = clienteBLL.BuscarClientesPorCedula(cedula);
            return clientes;
        }


    }
}
