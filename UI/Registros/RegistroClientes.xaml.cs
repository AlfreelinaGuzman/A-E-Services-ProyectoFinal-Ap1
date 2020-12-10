using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegistroClientes.xaml
    /// </summary>
    public partial class RegistroClientes : Window
    {
        private Clientes clientes = new Clientes ();
        public RegistroClientes()
        {
           InitializeComponent();
            this.DataContext = clientes;

        }

        private void Limpiar()
        {
            clientes= new Clientes();
            this.DataContext = clientes;
        }

           private void Actualizar() 
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }

        private bool ExisteDB(){
            clientes= ClientesBLL.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));
            return (clientes != null);
        }
        
        private bool Validar() 
        { 
            bool Validado = true;  
            string Mensaje = "";

            if (ClienteIdTextBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese el Nombre";
            }
            if (!Regex.Match(NombresTextBox.Text, @"^[a-zA-Z]+$").Success || Regex.Match(NombresTextBox.Text, @"^[0-9]+$").Success)
            {
                Validado = false;
                Mensaje += "El Nombre es invalido";
            }
            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text) || !Regex.Match(CedulaTextBox.Text, @"^\(?\d{3}\)?-? *\d{7}-? *-?\d{1}").Success)
            {
                Validado = false; 
                Mensaje += "La Cedula es invalida";
            }
            if (string.IsNullOrWhiteSpace(TelefonoTextBox.Text) || !Regex.Match(TelefonoTextBox.Text, @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").Success)
            {
                Validado = false; 
                Mensaje += "Ingrese el Telefono";
            }

            if (string.IsNullOrWhiteSpace(CelularTextBox.Text)|| (!Regex.Match(CelularTextBox.Text, @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").Success))
            {
                Validado = false; 
                Mensaje += "Celular esta vacio o invalido";
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

            if (!IsValid(EMailTextBox.Text))
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida, El Correo no es valido ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Validado == false){
                MessageBox.Show(Mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
           /// bool paso = false;
            if (ClientesBLL.Guardar(clientes))
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
            id = Convert.ToInt32(ClienteIdTextBox.Text);

            Limpiar();

            if(ClientesBLL.Eliminar(id))
                MessageBox.Show("Se elimino Correctamente");
            else
                MessageBox.Show(ClienteIdTextBox.Text,"No se pudo eliminar!");
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes anterior = ClientesBLL.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));

            if(anterior != null)
            {
                clientes = anterior;
                
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
            
            this.DataContext = null;
            this.DataContext = clientes;
        }
        private bool Existe()
        {
            Clientes esValido = ClientesBLL.Buscar(clientes.ClienteId);

            return (esValido != null);
        }

    }
    }