﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            RegistroClientes RU = new RegistroClientes();
            RU.Show();
        }

         private void RegistrarCompra_Click(object sender, RoutedEventArgs e)
        {
            RegistroCompras RU = new RegistroCompras();
            RU.Show();
        }

        private void RegistrarVenta_Click(object sender, RoutedEventArgs e)
        {
            RegistroVentas RU = new RegistroVentas();
            RU.Show();
        }

        private void ConsultarUsuario_Click(object sender, RoutedEventArgs e)
        {
            ConsultaUsuarios RU = new ConsultaUsuarios();
            RU.Show();
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            
            this.Close();
            // If data is dirty, notify user and ask for a response
            
        }

    }
}
