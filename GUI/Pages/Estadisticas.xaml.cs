using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para Estadisticas.xaml
    /// </summary>
    public partial class Estadisticas : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ObservableCollection<string> Dates { get; set; }

        public Estadisticas()
        {
            InitializeComponent();
            DataContext = this;
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 3, 5, 7, 4, 5 }
                }
            };

            Dates = new ObservableCollection<string>
            {
                "2022-01-01",
                "2022-01-02",
                "2022-01-03",
                "2022-01-04",
                "2022-01-05"
            };
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Window ventana = Window.GetWindow(this);

            if (ventana != null)
            {
                Login login = new Login();
                login.Show();

                ventana.Close();
            }
        }
    }
}
