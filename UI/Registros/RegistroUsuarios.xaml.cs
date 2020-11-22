using WaoCellDominicana_ProyectoFinal_Ap1.BLL;
using WaoCellDominicana_ProyectoFinal_Ap1.DAL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuarios : Window
    {
        private Usuarios new_User = new Usuarios();
        public RegistroUsuarios()
        {
            InitializeComponent();
            
        }

        private void Limpiar()
        {
            new_User = new Usuarios();
            ContraseñaTextBox.Password = string.Empty;
            VerificarContraseñaTextBox.Password = string.Empty;
            DataContext = new_User;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ValidarId()
        {
            bool esValido = false;

            if (!Regex.IsMatch(UsuarioIdTextBox.Text, @" ^[0-9] +$"))
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Dato dentro del id es inalido", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                UsuarioIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (!Regex.IsMatch(NombresTextBox.Text, @"^[A-Za-z ]+$"))
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Solo Se Permiten Letras En Este Campo", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled= false;
                MessageBox.Show("Nombres Está Vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombre Usuario Está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreUsuarioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if(!IsValid(CorreoTextBox.Text))
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Email invalido", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CorreoTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (VerificarContraseñaTextBox.Password.Length < 6 || ContraseñaTextBox.Password.Length<6)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Clave debe tener al menos 6 caracter", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ContraseñaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (VerificarContraseñaTextBox.Password != ContraseñaTextBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("La contraseña no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VerificarContraseñaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (VerificarContraseñaTextBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Confirmar contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VerificarContraseñaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (VerificarContraseñaTextBox.Password != ContraseñaTextBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("La contraseña no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VerificarContraseñaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            if (UsuarioIdTextBox.Text != "0")
            {
                new_User.Contraseña = ContraseñaTextBox.Password;
                bool esOk = UsuariosBLL.Modificar(new_User);
                if (esOk)
                {
                    Limpiar();
                    MessageBox.Show("Modificacion exitosa!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else { MessageBox.Show("Modificacion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                Contexto context = new Contexto();
                if (context.Usuarios.Any(p => p.NombreUsuario == NombreUsuarioTextBox.Text))
                {
                    MessageBox.Show("Este nombre de usuario ->" + NombreUsuarioTextBox.Text + "<- ya existe, por favor usar otro.",
                        "Usuario ya existente", MessageBoxButton.OK, MessageBoxImage.Error);
                    NombreUsuarioTextBox.Clear();
                    NombreUsuarioTextBox.Focus();
                }
                else
                {
                    new_User.Contraseña = ContraseñaTextBox.Password;
                    
                    bool user = UsuariosBLL.Guardar(new_User);

                    if (user)
                    {
                        Limpiar();
                        MessageBox.Show("Transaccion exitosa!", "Exito",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Usuario eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios cuenta = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if (cuenta != null)
            {
                new_User = cuenta;
                DataContext = new_User;
            }
            else { Limpiar(); }
        }

    }
}