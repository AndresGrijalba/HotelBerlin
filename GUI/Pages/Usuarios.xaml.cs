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
    public partial class Usuarios : Page
    {
        private UsuarioBLL usuarioBLL;

        public Usuarios()
        {
            InitializeComponent();

            usuarioBLL = new UsuarioBLL(); // Crea una instancia de UsuarioBLL
            CargarUsuarios(); // Llama al método para cargar los usuarios en la interfaz
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = usuarioBLL.ObtenerUsuarios(); 

            StackPanel mainStackPanel = new StackPanel();
            mainStackPanel.Orientation = Orientation.Vertical;
            mainStackPanel.Margin = new Thickness(0,80,0,0);



            foreach (var usuario in usuarios)
            {
                // Crea un Border para cada usuario
                Border border = new Border();
                border.CornerRadius = new CornerRadius(10); // Ajusta el radio de las esquinas según tu preferencia
                border.BorderThickness = new Thickness(0);
                border.BorderBrush = Brushes.Transparent; // Puedes cambiar el color del borde si lo deseas
                border.Margin = new Thickness(18, 15, 0, 0);
                border.Background = Brushes.White;

                // Crea un StackPanel dentro del Border para colocar los elementos del usuario
                StackPanel usuarioPanel = new StackPanel();
                usuarioPanel.Orientation = Orientation.Horizontal;
                usuarioPanel.Height = 40;

                // Crea TextBlocks para mostrar la información del usuario
                TextBlock nombreTextBlock = new TextBlock();
                nombreTextBlock.Text = " " + usuario.Nombre;
                nombreTextBlock.FontWeight = FontWeights.Bold;
                nombreTextBlock.Foreground = Brushes.Black;
                nombreTextBlock.Margin = new Thickness(0, 0, 0, 0);
                nombreTextBlock.Width = 100;
                nombreTextBlock.VerticalAlignment = VerticalAlignment.Center;

                TextBlock apellidoTextBlock = new TextBlock();
                apellidoTextBlock.Text = " " + usuario.Apellido;
                apellidoTextBlock.FontWeight = FontWeights.Bold;
                apellidoTextBlock.Foreground = Brushes.Black;
                apellidoTextBlock.Margin = new Thickness(10, 0, 0, 0);
                apellidoTextBlock.Width = 100;
                apellidoTextBlock.VerticalAlignment = VerticalAlignment.Center;

                TextBlock cedulaTextBlock = new TextBlock();
                cedulaTextBlock.Text = " " + usuario.Cedula;
                cedulaTextBlock.FontWeight = FontWeights.Bold;
                cedulaTextBlock.Foreground = Brushes.Black;
                cedulaTextBlock.Margin = new Thickness(10, 0, 0, 0);
                cedulaTextBlock.Width = 100;
                cedulaTextBlock.VerticalAlignment = VerticalAlignment.Center;

                TextBlock correoTextBlock = new TextBlock();
                correoTextBlock.Text = " " + usuario.Correo;
                correoTextBlock.FontWeight = FontWeights.Bold;
                correoTextBlock.Foreground = Brushes.Black;
                correoTextBlock.Margin = new Thickness(10, 0, 0, 0);
                correoTextBlock.Width = 200;
                correoTextBlock.VerticalAlignment = VerticalAlignment.Center;

                // Agrega los TextBlocks al StackPanel del usuario
                usuarioPanel.Children.Add(nombreTextBlock);
                usuarioPanel.Children.Add(apellidoTextBlock);
                usuarioPanel.Children.Add(cedulaTextBlock);
                usuarioPanel.Children.Add(correoTextBlock);

                // Añade el StackPanel del usuario al Border
                border.Child = usuarioPanel;

                // Añade el Border al StackPanel principal
                mainStackPanel.Children.Add(border);
            }


            // Agrega el StackPanel principal al Grid (o al contenedor adecuado en tu XAML)
            ContentGrid.Children.Add(mainStackPanel); // ContentGrid es el Grid donde quieres mostrar los usuarios
        }
    }
}