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
    public partial class RegistroArticulos : Window
    {
        private Articulos Articulo = new Articulos();
        public RegistroArticulos()
        {
            InitializeComponent();
            this.DataContext = Articulo;

            MarcaComboBox.ItemsSource = MarcasBLL.GetMarcas();
            MarcaComboBox.SelectedValuePath = "MarcaId";
            MarcaComboBox.DisplayMemberPath = "Marca";

            ModeloComboBox.ItemsSource = ModelosBLL.GetModelos();
            ModeloComboBox.SelectedValuePath = "ModeloId";
            ModeloComboBox.DisplayMemberPath = "Modelo";

            ProveedorComboBox.ItemsSource = ProveedoresBLL.GetList();
            ProveedorComboBox.SelectedValuePath = "ProveedorId";
            ProveedorComboBox.DisplayMemberPath = "Nombres";
        }

        private bool Validar()
        {
            bool Validado = true;

            if (ArticuloIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Convert.ToInt32(CantidadTextBox.Text)<=0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

            if (DescripcionTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Convert.ToDecimal(CostoTextBox.Text)<=0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

            return Validado;
        }

        private void Limpiar()
        {
            this.Articulo = new Articulos();
            MarcaComboBox.SelectedIndex = -1;
            ModeloComboBox.SelectedIndex = -1;
            this.DataContext = Articulo;

        }

        private void BuscarButton_click(object sender, RoutedEventArgs e)
        {
            var encontrado = ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdTextBox.Text));
            if (encontrado != null)
                Articulo = encontrado;
            else
            {
                Limpiar();

            }
            MarcaComboBox.SelectedIndex=Convert.ToInt32(Articulo.MarcaId);
            ModeloComboBox.SelectedIndex =  Convert.ToInt32(Articulo.ModeloId);
            ProveedorComboBox.SelectedIndex= Convert.ToInt32(Articulo.ProveedorId);
            this.DataContext = Articulo;
        }



        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            Articulo.MarcaId = Convert.ToInt32(MarcaComboBox.SelectedIndex);
            Articulo.ModeloId = Convert.ToInt32(ModeloComboBox.SelectedIndex);
            Articulo.ProveedorId = Convert.ToInt32(ProveedorComboBox.SelectedIndex);
            var paso = ArticulosBLL.Guardar(Articulo);
            if (paso)
            {
                MessageBox.Show("Guardado Correctamente!");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error 01: No se pudo guardar!");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            if (ArticulosBLL.Eliminar(Convert.ToInt32(ArticuloIdTextBox.Text)))
            {
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