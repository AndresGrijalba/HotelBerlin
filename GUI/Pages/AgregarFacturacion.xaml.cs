using BLL;
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
    /// Lógica de interacción para AgregarFactutaracion.xaml
    /// </summary>
    public partial class AgregarFacturacion : Page
    {
        public AgregarFacturacion()
        {
            InitializeComponent();
        }

        private void RegistrarReserva_Click(object sender, RoutedEventArgs e)
        {
            int id_reserva = Convert.ToInt32(txtIdReserva.Text);
            double valor_noche = Convert.ToDouble(txtValorNoche.Text);
            int cantidad_noches = Convert.ToInt32(txtCantidadNoches.Text);
            double total = Convert.ToDouble(txtTotal.Text);
            DateTime fecha_emision = Convert.ToDateTime(DateTime.Now);
            
            FacturacionBLL facturacionBLL = new FacturacionBLL();

            try
            {
                facturacionBLL.AgregarFactura(id_reserva, valor_noche, cantidad_noches, total, fecha_emision);
                MessageBox.Show("Facturacion registrada exitosamente.", "Registro Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                //Facturacion facturacionpage = new Facturacion;
                
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
