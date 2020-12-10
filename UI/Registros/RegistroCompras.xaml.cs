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

namespace WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros {
    /// <summary>
    /// Interaction logic for RegistroCompras.xaml
    /// </summary>
    public partial class RegistroCompras : Window {
        private Compras compras = new Compras();

        public RegistroCompras() 
        {
            InitializeComponent();
            this.DataContext = compras;


            ArticuloIdComboBox.ItemsSource = ArticulosBLL.GetArticulos();
            ArticuloIdComboBox.SelectedValuePath = "ArticuloId";
            ArticuloIdComboBox.DisplayMemberPath = "ArticuloId";

            ProveedorIdComboBox.ItemsSource = ProveedoresBLL.GetList();
            ProveedorIdComboBox.SelectedValuePath = "ProveedorId";
            ProveedorIdComboBox.DisplayMemberPath = "ProveedorId";

        }
private void Limpiar() {
            compras = new Compras();
            this.DataContext = compras;
            ActualizadGrid();
        }

        private void Actualizar() {
            this.DataContext = null;
            this.DataContext = compras;
        }

        private void ActualizadGrid() {
            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = compras.ComprasDetalles;
        }
        private bool ExisteDB() {
            compras = ComprasBLL.Buscar(Convert.ToInt32(CompraIdTextBox.Text));
            return (compras != null);
        }

        private void GuardarButton_Click(object sender , RoutedEventArgs e) {
            if (!Validar()) {
                return;
            }
            
            compras.ProveedorId = (int) ProveedorIdComboBox.SelectedValue;
            if (ComprasBLL.Guardar(compras)) {
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
                compras = anterior;
                Actualizar();
                ActualizadGrid();
            } else {
                MessageBox.Show("No se encontro");
            }
            this.DataContext = compras;
        }

        private void AgregarButton_Click(object sender , RoutedEventArgs e) {

            
            if (!int.TryParse(CantidadTextBox.Text, out int cantidad)) {
                MessageBox.Show("La cantidad no es valida");
                return;
            }
             if (int.Parse(CantidadTextBox.Text)<= 0)
            {
                MessageBox.Show("Ingrese un numero mayor que 0");
            } 
             
             //decimal itbis ;

            var filaDetalle = new ComprasDetalles {
                CompraId = this.compras.CompraId ,
                ArticuloId = Convert.ToInt32(ArticuloIdComboBox.SelectedValue.ToString()) ,
                Costo = Convert.ToDecimal(CostoTextBox.Text) ,
                Cantidad = Convert.ToInt32(CantidadTextBox.Text) ,
                ITBIS = Convert.ToDecimal(ITBISTextBox.Text),
                //PorcientoItbis = Convert.ToDecimal(ITBISTextBox.Text) / 100,
                Monto  = Convert.ToDecimal(CostoTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text) * ((Convert.ToDecimal(ITBISTextBox.Text) / 100)+1)
                
            };
            
           // VentasBLL.RestaCantidad(Convert.ToInt32(ArticuloIdComboBox.SelectedValue.ToString()), Convert.ToInt32(CantidadTextBox.Text));

            this.compras.ComprasDetalles.Add(filaDetalle);
            CalcularTotal();

            Actualizar();
            ActualizadGrid();

            ArticuloIdComboBox.SelectedIndex = -1;
            CostoTextBox.Clear();
            CantidadTextBox.Clear();
            ITBISTextBox.Clear();
        }

        private void CalcularTotal() {
            compras.Total = 0;
            foreach (var ventadetalle in compras.ComprasDetalles) {
                compras.Total += ventadetalle.Monto;
            }
        }

        private void RemoverButton_Click(object sender , RoutedEventArgs e) {
            try {
                decimal total = Convert.ToDecimal(TotalTextBox.Text);
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1) {
                    compras.ComprasDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);
                    //ventas.Total -= total;
                    CalcularTotal();

                    Actualizar();

                    DetalleDataGrid.ItemsSource = null;
                    DetalleDataGrid.ItemsSource = compras.ComprasDetalles;
                }
            } catch {
                MessageBox.Show("Por favor seleccione una Fila\n\nElija la Fila a Remover.");
            }
        }

        private bool Existe() {
            Ventas esValido = VentasBLL.Buscar(compras.CompraId);

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
                ITBISTextBox.Text = articulos.ITBIs.ToString();
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
                MessageBox.Show("Transaccion Fallida en Cliente" , "Error" , MessageBoxButton.OK , MessageBoxImage.Error);
            }
            if (string.IsNullOrWhiteSpace(NCFTextBox.Text)) {
                Validado = false;
                Mensaje += "Ingrese el NCF";
            }
            /*if (string.IsNullOrWhiteSpace(ITBISTextBox.Text)) {
                Validado = false;
                Mensaje += "Ingrese el % de Itbis";
            }*/

            if (Validado == false) {
                MessageBox.Show(Mensaje , "Error" , MessageBoxButton.OK , MessageBoxImage.Error);
            }
            return Validado;
        }
    }
}