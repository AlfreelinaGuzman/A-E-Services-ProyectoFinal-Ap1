using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WaoCellDominicana_ProyectoFinal_Ap1.BLL;
using WaoCellDominicana_ProyectoFinal_Ap1.DAL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;
using WaoCellDominicana_ProyectoFinal_Ap1.UI;

namespace  WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroProveedores.xaml
    /// </summary>
    public partial class RegistroProveedores : Window
    {
        private Proveedores proveedores = new Proveedores ();
        public RegistroProveedores()
        {
           InitializeComponent();
           this.DataContext = proveedores;

        }

        private void Limpiar()
        {
            proveedores= new Proveedores();
            this.DataContext = proveedores;
        }

           private void Actualizar() 
        {
            this.DataContext = null;
            this.DataContext = proveedores;
        }

        private bool ExisteDB(){
            proveedores= ProveedoresBLL.Buscar(Convert.ToInt32(ProveedorIdTextBox.Text));
            return (proveedores != null);
        }
        private bool Validar() 
        { 
            bool Validado = true;  
            string Mensaje = ""; 

            if (ProveedorIdTextBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese el Nombre";
            }
             if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese la Cedula";
            }
            if (string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese el Telefono";
            }

            if (string.IsNullOrWhiteSpace(CelularTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese la Celular";
            }

             if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese la Direccion";
            }

            if (string.IsNullOrWhiteSpace(EMailTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese el Email";
            }
            if(Validado == false){
                MessageBox.Show(Mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             
            return Validado; 
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
           /// bool paso = false;
            if (ProveedoresBLL.Guardar(proveedores))
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(ProveedorIdTextBox.Text);

            Limpiar();

            if(ProveedoresBLL.Eliminar(id))
                MessageBox.Show("Se elimino Correctamente");
            else
                MessageBox.Show(ProveedorIdTextBox.Text,"No se pudo eliminar!");
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proveedores anterior = ProveedoresBLL.Buscar(Convert.ToInt32(ProveedorIdTextBox.Text));

            if(anterior != null)
            {
                proveedores = anterior;
                //this.DataContext = null;
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
            this.DataContext = proveedores;

        }
        
        private bool Existe()
        {
            Proveedores esValido = ProveedoresBLL.Buscar(proveedores.ProveedorId);

            return (esValido != null);
        }

    }
}