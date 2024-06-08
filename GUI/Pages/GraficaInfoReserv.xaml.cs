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
    public partial class GraficaInfoReserv : UserControl
    {
        public GraficaInfoReserv()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            var bll = new ReservaBLL();
            int canceladas = bll.ObtenerReservasCanceladas().Count;
            int confirmadas = bll.ObtenerReservasConfirmadas().Count;
            int pendientes = bll.ObtenerReservasPendientes().Count;

            GraficaReservas.Series = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Canceladas",
            Values = new ChartValues<int> { canceladas },
            DataLabels = true,
            LabelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation)
        },
        new PieSeries
        {
            Title = "Confirmadas",
            Values = new ChartValues<int> { confirmadas },
            DataLabels = true,
            LabelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation)
        },
        new PieSeries
        {
            Title = "Pendientes",
            Values = new ChartValues<int> { pendientes },
            DataLabels = true,
            LabelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation)
        }
    };
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            // Clear selected slice
            foreach (PieSeries Series in chart.Series)
                Series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
