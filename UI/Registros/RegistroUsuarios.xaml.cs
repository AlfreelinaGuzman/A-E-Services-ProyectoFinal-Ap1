using WaoCellDominicana_ProyectoFinal_Ap1.BLL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.ComponentModel; // CancelEventArgs
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros
{
    public partial class RegistroUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();
        public RegistroUsuarios()
        {
            InitializeComponent();
            this.DataContext=usuarios;
            
        }

        private bool Validar() 
        { 
            bool Validado = true;  

            if (UsuarioIdTextBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!Regex.Match(NombresTextBox.Text, @"^[a-zA-Z]+$").Success|| Regex.Match(NombresTextBox.Text, @"^[0-9]+$").Success || NombresTextBox.Text.Length <= 3 || NombresTextBox.Text.Length >=11)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, Nombre invalido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!Regex.Match(ApellidosTextBox.Text, @"^[a-zA-Z]+$").Success || Regex.Match(ApellidosTextBox.Text, @"^[0-9]+$").Success || ApellidosTextBox.Text.Length <= 3 || ApellidosTextBox.Text.Length >= 11)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, El apellido es invalido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (NombreUsuarioTextBox.Text.Length < 4|| NombreUsuarioTextBox.Text.Length >14)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, el nombre de ususario debe tnere entre [5-14] caracteres", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (PasswordTextBox.Password.Length > 5|| PasswordTextBox.Password.Length < 19)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, La contraseña debe tener un rango de [5-18] ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (PasswordTextBox.Password != VerificarContraseñaTextBox.Password)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, Las contraseña s no coinciden ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
            if (!Regex.Match(TelefonoTextBox.Text, @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").Success)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, El numero de telefono no es valido ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!Regex.Match(TelefonoTextBox.Text, @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").Success)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, El numero de telefono no es valido ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!IsValid(CorreoTextBox.Text))
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, El Correo no es valido ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Validado;
            
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

        private void Limpiar(){
            this.usuarios = new Usuarios();
            this.DataContext = usuarios;
        }

        private void BuscarButton_click(object sender, RoutedEventArgs e){
            var encontrado = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));
            if(encontrado!= null)
                usuarios = encontrado;
            else
            {
                Limpiar();

            }
            this.DataContext = usuarios;
        }

        

        private void NuevoButton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e){
            usuarios.Password=PasswordTextBox.Password;
            if (!Validar())
                return;
            var paso = UsuariosBLL.Guardar(usuarios);
            if (paso){
                MessageBox.Show("Guardado Correctamente!");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error 01: No se pudo guardar!");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e){

            if(UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text))){
                MessageBox.Show("Se elimino correctamente!");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error 02: No se pudo Eliminar");
            }
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            
        }

    }

}