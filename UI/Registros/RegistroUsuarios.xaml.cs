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
        private Usuarios usuarios = new Usuarios();
        public RegistroUsuarios()
        {
            InitializeComponent();
            
        }

        private bool Validar() 
        { 
            bool Validado = true;  

            if (UsuarioIdTextBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Validado; 
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
    }
}