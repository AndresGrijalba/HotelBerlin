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
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : Page
    {
        public List<Factura> factura = null;
        FacturaBLL servicio = new FacturaBLL();
        private FacturaBLL facturaBLL = new FacturaBLL(); 

        public Facturas()
        {
            InitializeComponent();
            DataContext = this;
            factura = servicio.ObtenerFacturas();
            FacturasDataGrid.ItemsSource = factura;
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            List<Factura> facturas = facturaBLL.ObtenerFacturas();
            FacturasDataGrid.ItemsSource = facturas;
        }
    }
}
