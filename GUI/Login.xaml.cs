﻿using System;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string user = "Admin";
        string password = "1234";
        public Login()
        {
            InitializeComponent();
        }

        public void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            ValidarCredenciales();
            if (user == User.Text && password == Password.Password)
            {
                MainWindow menu = new MainWindow();
                menu.Show();
                this.Close();
            }
        }

        public void ValidarCredenciales()
        {
            if (!string.IsNullOrEmpty(user))
            {
                if (!string.IsNullOrEmpty(password)){
                    MessageBox.Show("Debes ingresar una contraseña");
                }
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
