using System.Windows;

namespace GUI
{
    public partial class Login : Window
    {
        string user = "hotelberlinva@gmail.com";
        string password = "adminhb";

        public Login()
        {
            InitializeComponent();
        }

        public void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Debes ingresar un usuario");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debes ingresar una contraseña");
                return;
            }

            if (user == User.Text && password == Password.Password)
            {
                MainWindow menu = new MainWindow();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
