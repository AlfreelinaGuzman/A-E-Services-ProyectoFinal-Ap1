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
using System.ComponentModel; // CancelEComprargs
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
    public partial class RegistroCompras : Window
    {
        private Compras Compra = new Compras();
        public RegistroCompras()
        {
            InitializeComponent();
            ArticuloIdComboBox.ItemsSource = ArticulosBLL.GetArticulos();
            ArticuloIdComboBox.SelectedValuePath = "ArticuloId";
            ArticuloIdComboBox.DisplayMemberPath = "Descripcion";

            ProveedorIdComboBox.ItemsSource = ProveedoresBLL.GetList();
            ProveedorIdComboBox.SelectedValuePath = "ProveedorId";
            ProveedorIdComboBox.DisplayMemberPath = "Nombres";
            
        }

        private void Limpiar() {
            Compra = new Compras();
            this.DataContext = Compra;
            ActualizadGrid();
        }

        private void Actualizar() {
            this.DataContext = null;
            this.DataContext = Compra;
        }

        private void ActualizadGrid() {
            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = Compra.Detalle;
        }
        private bool ExisteDB() {
            Compra = ComprasBLL.Buscar(Convert.ToInt32(CompraIdTextBox.Text));
            return (Compra != null);
        }

        private void GuardarButton_Click(object sender , RoutedEventArgs e) {
            if (!Validar()) {
                return;
            }
            
            Compra.ProveedorId = ProveedorIdComboBox.SelectedIndex+1;
            if (ComprasBLL.Guardar(Compra)) {
                Limpiar();
                MessageBox.Show("Guardado!" , "Exito" ,
                    MessageBoxButton.OK , MessageBoxImage.Information);
            } else
                MessageBox.Show("Fallo al guardar" , "Fallo" ,
                    MessageBoxButton.OK , MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender , RoutedEventArgs e) {
            int id;
            id = Convert.ToInt32(CompraIdTextBox.Text);

            Limpiar();

            if (ComprasBLL.Eliminar(id))
                MessageBox.Show("Se elimino Correctamente");
            else
                MessageBox.Show(CompraIdTextBox.Text , "No se pudo eliminar!");
        }
        private void NuevoButton_Click(object sender , RoutedEventArgs e) {
            Limpiar();
        }

        private void BuscarButton_Click(object sender , RoutedEventArgs e) {
            Compras anterior = ComprasBLL.Buscar(Convert.ToInt32(CompraIdTextBox.Text));

            if (anterior != null) {
                Compra = anterior;
                Actualizar();
                ActualizadGrid();
            } else {
                MessageBox.Show("No se encontro");
            }
            this.DataContext = Compra;
        }

        private void AgregarButton_Click(object sender , RoutedEventArgs e) {
            
            if (!int.TryParse(CantidadTextBox.Text, out int cantidad)) {
                MessageBox.Show("La cantidad no es valida");
                return;
            }
           
            var filaDetalle = new ComprasDetalles {
                CompraId = this.Compra.CompraId ,
                ArticuloId = Convert.ToInt32(ArticuloIdComboBox.SelectedIndex+1) ,
                //Articulos = ((Articulos)ArticuloIdComboBox.SelectedItem),
                Cantidad = Convert.ToInt32(CantidadTextBox.Text), //Convert.ToInt32(CantidadTextBox.Text)

                ITBIS = Convert.ToDecimal(ITBISTextBox.Text),
                //PorcientoItbis = Convert.ToDecimal(ITBISTextBox.Text) / 100,
                Monto = Convert.ToDecimal(CostoTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text) * ((Convert.ToDecimal(ITBISTextBox.Text) / 100) + 1)
            };
           
            this.Compra.Detalle.Add(filaDetalle);
            CalcularTotal();

            Actualizar();
            ActualizadGrid();

            ArticuloIdComboBox.SelectedIndex = -1;
            CostoTextBox.Clear();
            CantidadTextBox.Clear();
        }

        private void CalcularTotal() {
            Compra.Total = 0;
            foreach (var Compradetalle in Compra.Detalle) {
                Compra.Total += Compradetalle.Monto;
            }
        }

        private void RemoverButton_Click(object sender , RoutedEventArgs e) {
            try {
                decimal total = Convert.ToDecimal(TotalTextBox.Text);
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1) {
                    Compra.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                    Compra.Total -= total;
                    Actualizar();
                    DetalleDataGrid.ItemsSource = null;
                    DetalleDataGrid.ItemsSource = Compra.Detalle;
                    ComprasBLL.QuitarArticulo(Convert.ToInt32(ArticuloIdComboBox.Text), Convert.ToInt32(CantidadTextBox));
                }
            } catch {
                MessageBox.Show("Por favor seleccione una Fila\n\nElija la Fila a Remover.");
            }
        }

        private bool Existe() {
            Compras esValido = ComprasBLL.Buscar(Compra.CompraId);

            return (esValido != null);
        }

        private void CantidadTextBox_TextChanged(object sender , TextChangedEventArgs e) {
            try {
                if (CantidadTextBox.Text.Trim() != "") {
                    decimal resultado = decimal.Parse(CantidadTextBox.Text);
                }
            } catch {
                MessageBox.Show($"Porfavor, digite un numero.");
                CantidadTextBox.Clear();
                CantidadTextBox.Focus();
            }
        }

   

        private void CostoTextBox_TextChanged(object sender , TextChangedEventArgs e) {
            try {
                if (CostoTextBox.Text.Trim() != "") {
                    decimal resultado = decimal.Parse(CostoTextBox.Text);
                }
            } catch {
                MessageBox.Show($"Porfavor, digite un numero.");
                CostoTextBox.Clear();
                CostoTextBox.Focus();
            }
        }

        private void ITBISTextBox_TextChanged(object sender , TextChangedEventArgs e) {
            try {
                if (ITBISTextBox.Text.Trim() != "") {
                    decimal resultado = decimal.Parse(ITBISTextBox.Text);
                }
            } catch {
                MessageBox.Show($"Porfavor, digite un numero.");
                ITBISTextBox.Clear();
                ITBISTextBox.Focus();
            }
        }

        private void ArticuloIdComboBox_SelectionChanged(object sender , SelectionChangedEventArgs e) {
            var articulos = ((ComboBox) sender).Items.CurrentItem as Articulos;
            if (articulos != null) {
                CostoTextBox.Text = articulos.Costo.ToString();
                //ITBISTextBox.Text = articulos.ITBIS.ToString();
            }
        }

        private bool Validar() {
            bool Validado = true;
            string Mensaje = "";

            if (CompraIdTextBox.Text.Length == 0) {
                Validado = false;
                MessageBox.Show("Transaccion Fallida " , "Error" , MessageBoxButton.OK , MessageBoxImage.Error);
            }
            if (ProveedorIdComboBox.Text.Length == 0) {
                Validado = false;
                MessageBox.Show("Transaccion Fallida en Proveedor" , "Error" , MessageBoxButton.OK , MessageBoxImage.Error);
            }
            if (string.IsNullOrWhiteSpace(NCFTextBox.Text)) {
                Validado = false;
                Mensaje += "Ingrese el NCF";
            }
            if (string.IsNullOrWhiteSpace(ITBISTextBox.Text)) {
                Validado = false;
                Mensaje += "Ingrese el % de Itbis";
            }

            if (Validado == false) {
                MessageBox.Show(Mensaje , "Error" , MessageBoxButton.OK , MessageBoxImage.Error);
            }
            return Validado;
        }

        private void DetalleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}