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
    /// <summary>
    /// Interaction logic for RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroArticulos : Window
    {
        private Articulos Articulo = new Articulos();
        public RegistroArticulos()
        {
            InitializeComponent();
            this.DataContext=Articulo;
            
        }

        private bool Validar() 
        { 
            bool Validado = true;  

            if (ArticuloIdTextBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Validado; 
        }

        private void Limpiar(){
            this.Articulo = new Articulos();
            this.DataContext = Articulo;
        }

        private void BuscarButton_click(object sender, RoutedEventArgs e){
            var encontrado = ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdTextBox.Text));
            if(encontrado!= null)
                Articulo = encontrado;
            else
            {
                Limpiar();

            }
            this.DataContext = Articulo;
        }

        

        private void NuevoButton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e){
            var paso = ArticulosBLL.Guardar(Articulo);
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

            if(ArticulosBLL.Eliminar(Convert.ToInt32(ArticuloIdTextBox.Text))){
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
            MessageBox.Show("Closing called");

            // If data is dirty, notify user and ask for a response
            
        }

    }

}