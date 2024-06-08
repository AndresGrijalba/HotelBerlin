using LiveCharts.Defaults;
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
using System.Collections.ObjectModel;
using BLL;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para Example.xaml
    /// </summary>
    public partial class GraficaReservas : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ObservableCollection<string> Periodos { get; set; }
        public ObservableCollection<string> PeriodoOptions { get; set; }
        public string SelectedPeriodo { get; set; }
        public LiveCharts.Wpf.Separator AxisYSeparator { get; set; }

        private ReservaBLL reservaBLL;

        public GraficaReservas()
        {
            InitializeComponent();
            DataContext = this;

            reservaBLL = new ReservaBLL();
            PeriodoOptions = new ObservableCollection<string> { "Día", "Mes", "Año" };
            SelectedPeriodo = "Día";
            AxisYSeparator = new LiveCharts.Wpf.Separator { Step = 1 };
            LoadDataFromDatabase(SelectedPeriodo);
        }

        private void LoadDataFromDatabase(string periodo)
        {
            var reservasPorPeriodo = reservaBLL.ObtenerReservasPorPeriodo(periodo);

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Reservas",
                    Values = new ChartValues<int>(reservasPorPeriodo.Values),
                    Stroke = new SolidColorBrush(Color.FromRgb(0, 120, 215)), 
                    Fill = new SolidColorBrush(Color.FromArgb(50, 0, 120, 215))
                }
            };

            Periodos = new ObservableCollection<string>(reservasPorPeriodo.Keys);
            AdjustAxisYMaxValue();
            Chart.Series = SeriesCollection;
            Chart.AxisX[0].Labels = Periodos;
        }

        private void AdjustAxisYMaxValue()
        {
            var maxReservas = SeriesCollection
                .SelectMany(series => series.Values.Cast<int>())
                .DefaultIfEmpty(0)
                .Max();

            var yAxis = Chart.AxisY.FirstOrDefault();
            if (yAxis != null)
            {
                yAxis.MaxValue = Math.Ceiling(maxReservas / 5.0) * 5;
                yAxis.MinValue = 0;
            }
        }

        private void PeriodoSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PeriodoComboBox.SelectedItem != null)
            {
                string selectedPeriodo = PeriodoComboBox.SelectedItem.ToString();
                LoadDataFromDatabase(selectedPeriodo);
            }
        }

        private void UpdateAllOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();

            foreach (var series in SeriesCollection)
            {
                foreach (var observable in series.Values.Cast<ObservableValue>())
                {
                    observable.Value = r.Next(0, 10);
                }
            }
        }
    }
}
