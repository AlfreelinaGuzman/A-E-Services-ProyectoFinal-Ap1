using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WaoCellDominicana_ProyectoFinal_Ap1.BLL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;

namespace WaoCellDominicana_ProyectoFinal_Ap1
{
    public partial class Login : Window
    {
        Usuarios usuarios = new Usuarios();
        MainWindow MenuPrincipal = new MainWindow();

        public Login()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        //Cancelar
        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //Iniciar sesion
        private void IniciarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = UsuariosBLL.Autenticar(NombreUsuarioTextBox.Text, PasswordTextBox.Password);

            if (NombreUsuarioTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Nombre Usuario) está vacío.\n\nPor favor, escriba su nombre de usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreUsuarioTextBox.Clear();
                NombreUsuarioTextBox.Focus();
                return;
            }

            if (paso)
            {
                this.Hide();
                MenuPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Nombre de Usuario o Contraseña incorrectos.", "Precaución", MessageBoxButton.OK, MessageBoxImage.Warning);
                PasswordTextBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }
        //Nombre usuario al hacer enter
        private void NombreUsuarioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                PasswordTextBox.Focus();
            }
        }
        //Password al hacer enter
        private void PasswordPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                bool paso = UsuariosBLL.Autenticar(NombreUsuarioTextBox.Text, PasswordTextBox.Password);

                if (paso)
                {
                    this.Hide();
                    MenuPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Nombre de Usuario o Contraseña incorrectos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PasswordTextBox.Clear();
                    NombreUsuarioTextBox.Focus();
                }
            }
        }
    }
}
