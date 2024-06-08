using LiveCharts.Wpf;
using LiveCharts;
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
using BLL;

namespace GUI.Pages
{
    public partial class GraficaIngresos : UserControl
    {
        private FacturaBLL facturaBLL = new FacturaBLL();

        public GraficaIngresos()
        {
            InitializeComponent();
            UpdateChart();
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void UpdateChart()
        {
            double totalFacturas = facturaBLL.ObtenerTotalFacturas();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Total Facturas",
                    Values = new ChartValues<double> { totalFacturas },
                    DataLabels = true,
                    LabelPoint = p => p.Y.ToString("C")
                }
            };

            Labels = new[] { "Total" };
            Formatter = val => val.ToString("C");

            DataContext = this;
        }

    }
}
