using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros;
using WaoCellDominicana_ProyectoFinal_Ap1.UI.Consultas;

namespace WaoCellDominicana_ProyectoFinal_Ap1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void RegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuarios RU = new RegistroUsuarios();
            RU.Show();
        }

        private void RegistrarArticulo_Click(object sender, RoutedEventArgs e)
        {
            RegistroArticulos RU = new RegistroArticulos();
            RU.Show();
        }

        private void RegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            RegistroClientes ventana = new RegistroClientes();
            ventana.Show();
        }

        private void RegistrarCompra_Click(object sender, RoutedEventArgs e)
        {
            RegistroCompras RU = new RegistroCompras();
            RU.Show();
        }

        private void RegistrarProveedor_Click(object sender, RoutedEventArgs e)
        {
            RegistroProveedores Ventana = new RegistroProveedores();
            Ventana.Show();
        }
        //RegistrarVentas_Click

        private void RegistrarVentas_Click(object sender, RoutedEventArgs e)
        {
            RegistroVentas Ventana = new RegistroVentas();
            Ventana.Show();
        }
        private void ConsultarArticulos_Click(object sender, RoutedEventArgs e)
        {
            ConsultaArticulos Ventana = new ConsultaArticulos();
            Ventana.Show();
        }

        private void ConsultarUsuario_Click(object sender, RoutedEventArgs e)
        {
            ConsultaUsuarios RU = new ConsultaUsuarios();
            RU.Show();
        }

         private void ConsultarClientes_Click(object sender, RoutedEventArgs e)
        {
            ConsultaClientes Ventana = new ConsultaClientes();
            Ventana.Show();
        }

        private void ConsultarVentas_Click(object sender, RoutedEventArgs e)
        {
            ConsultaVentas Ventana = new ConsultaVentas();
            Ventana.Show();
        }

        private void ConsultarProveedores_Click(object sender, RoutedEventArgs e)
        {
            ConsultaProveedores Ventana = new ConsultaProveedores();
            Ventana.Show();
        }
        private void ConsultarCompras_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCompras Ventana = new ConsultaCompras();
            Ventana.Show();
        }
        /* void DataWindow_Closing(object sender, CancelEventArgs e)
         {

             this.Close();
             // If data is dirty, notify user and ask for a response
         }*/
    }
}
