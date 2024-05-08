using Entity;
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
using BLL;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Clientes : Page
    {
        private ClienteBLL clienteBLL;
        private StackPanel mainStackPanel;

        public Clientes()
        {
            InitializeComponent();

            clienteBLL = new ClienteBLL();
            mainStackPanel = new StackPanel();
            CargarClientes(); 
        }

        private void CargarClientes()
        {
            List<Cliente> clientes = clienteBLL.ObtenerClientes(); 

            mainStackPanel.Orientation = Orientation.Vertical;
            mainStackPanel.Margin = new Thickness(0,80,0,0);



            foreach (var cliente in clientes)
            {

                Border border = new Border();
                border.CornerRadius = new CornerRadius(10); 
                border.BorderThickness = new Thickness(0);
                border.BorderBrush = Brushes.Transparent;
                border.Margin = new Thickness(18, 15, 0, 0);
                border.Background = Brushes.White;

                StackPanel usuarioPanel = new StackPanel();
                usuarioPanel.Orientation = Orientation.Horizontal;
                usuarioPanel.Height = 40;

                TextBlock cedulaTextBlock = new TextBlock();
                cedulaTextBlock.Text = " " + cliente.Cedula;
                cedulaTextBlock.FontWeight = FontWeights.Bold;
                cedulaTextBlock.Foreground = Brushes.Black;
                cedulaTextBlock.Margin = new Thickness(10, 0, 0, 0);
                cedulaTextBlock.Width = 100;
                cedulaTextBlock.VerticalAlignment = VerticalAlignment.Center;

                TextBlock nombreTextBlock = new TextBlock();
                nombreTextBlock.Text = " " + cliente.Nombre;
                nombreTextBlock.FontWeight = FontWeights.Bold;
                nombreTextBlock.Foreground = Brushes.Black;
                nombreTextBlock.Margin = new Thickness(0, 0, 0, 0);
                nombreTextBlock.Width = 100;
                nombreTextBlock.VerticalAlignment = VerticalAlignment.Center;

                TextBlock apellidoTextBlock = new TextBlock();
                apellidoTextBlock.Text = " " + cliente.Apellido;
                apellidoTextBlock.FontWeight = FontWeights.Bold;
                apellidoTextBlock.Foreground = Brushes.Black;
                apellidoTextBlock.Margin = new Thickness(10, 0, 0, 0);
                apellidoTextBlock.Width = 100;
                apellidoTextBlock.VerticalAlignment = VerticalAlignment.Center;

                TextBlock correoTextBlock = new TextBlock();
                correoTextBlock.Text = " " + cliente.Correo;
                correoTextBlock.FontWeight = FontWeights.Bold;
                correoTextBlock.Foreground = Brushes.Black;
                correoTextBlock.Margin = new Thickness(10, 0, 0, 0);
                correoTextBlock.Width = 200;
                correoTextBlock.VerticalAlignment = VerticalAlignment.Center;

                usuarioPanel.Children.Add(cedulaTextBlock);
                usuarioPanel.Children.Add(nombreTextBlock);
                usuarioPanel.Children.Add(apellidoTextBlock);
                usuarioPanel.Children.Add(correoTextBlock);

                border.Child = usuarioPanel;

                mainStackPanel.Children.Add(border);

                usuarioPanel.Children.Add(crearBotonEliminar());
            }

            ContentGrid.Children.Add(mainStackPanel); 
        }


        private Button crearBotonEliminar()
        {
            Button eliminarButton = new Button();
            eliminarButton.Content = "Eliminar";
            eliminarButton.Click += EliminarUsuario_Click;        
            return eliminarButton;
        }

        private void EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Button botonEliminar = sender as Button;
            string cedulaCliente = botonEliminar.Tag as string;
            MessageBox.Show(cedulaCliente);
        }
        private void EditarCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CrearCliente_Click(object sender, RoutedEventArgs e)
        {
            mainStackPanel.Children.Clear();

            //frameContent.Navigate(new AgregarClientes());
        }
    }
}