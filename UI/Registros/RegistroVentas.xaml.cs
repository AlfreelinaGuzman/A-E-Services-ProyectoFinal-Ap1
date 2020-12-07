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

namespace WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros
{
    /// <summary>
    /// Interaction logic for Registroventas.xaml
    /// </summary>
    public partial class RegistroVentas : Window
    {
      private Ventas ventas = new Ventas();

        public RegistroVentas ()
        {
            InitializeComponent();
            this.DataContext = ventas;

            
            ArticuloIdComboBox.ItemsSource = ArticulosBLL.GetArticulos();
            ArticuloIdComboBox.SelectedValuePath = "ArticuloId";
            ArticuloIdComboBox.DisplayMemberPath = "ArticuloId";

            ClienteIdComboBox.ItemsSource = ClientesBLL.GetClientes();
            ClienteIdComboBox.SelectedValuePath = "ClienteId";
            ClienteIdComboBox.DisplayMemberPath = "ClienteId";

        }


        private void Limpiar()
        {
            ventas = new Ventas();
            this.DataContext = ventas;
        }

           private void Actualizar() 
        {
            this.DataContext = null;
            this.DataContext = ventas;
        }

        private bool ExisteDB(){
            ventas= VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));
            return (ventas != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
           if (!Validar())
            {
                return;
            }
           /// bool paso = false;
           ventas.ClienteId = (int) ClienteIdComboBox.SelectedValue;
            if (VentasBLL.Guardar(ventas))
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
            id = Convert.ToInt32(VentaIdTextBox.Text);

            Limpiar();

            if(VentasBLL.Eliminar(id))
                MessageBox.Show("Se elimino Correctamente");
            else
                MessageBox.Show(VentaIdTextBox.Text,"No se pudo eliminar!");
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas anterior = VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));

            if(anterior != null)
            {
                ventas = anterior; 
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
            this.DataContext = ventas;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e) 
        {
            var filaDetalle = new VentasDetalle 
            { 
                VentaId = this.ventas.VentaId,
                ArticuloId = Convert.ToInt32(ArticuloIdComboBox.SelectedValue.ToString()),
                //Articulos = ((Articulos)ArticuloIdComboBox.SelectedItem),
                Costo = Convert.ToDecimal(CostoTextBox.Text), 
                Cantidad = Convert.ToDecimal(CantidadTextBox.Text),
                Monto = Convert.ToDecimal(CostoTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text)
               // ventas.Total += Monto

        };
            //Monto = Convert.ToDecimal(CostoTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text);
           // ventas.Total += Convert.ToDecimal(CantidadTextBox.text.ToString());
            this.ventas.VentasDetalle.Add(filaDetalle); 

            Actualizar();

            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = ventas.VentasDetalle;

            ArticuloIdComboBox.SelectedIndex = -1; 
            CostoTextBox.Clear(); 
            CantidadTextBox.Clear();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e) 
    { 
        try { 
            decimal total = Convert.ToDecimal(TotalTextBox.Text); 
         if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
          { 
            ventas.VentasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
            ventas.Total -= total; 
             Actualizar(); 
            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = ventas.VentasDetalle;
         } 
        } 
        catch
        { 
         MessageBox.Show("Por favor seleccione una Fila\n\nElija la Fila a Remover."); 
        }
   }
    
        private bool Existe()
        {
            Ventas esValido = VentasBLL.Buscar(ventas.VentaId);

            return (esValido != null);
        }

    private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e) { 
        try 
        { 
            if (CantidadTextBox.Text.Trim() != "") {
                 decimal resultado = decimal.Parse(CantidadTextBox.Text);
        }
        } catch { 
            MessageBox.Show($"Porfavor, digite un numero.");
            CantidadTextBox.Clear();
            CantidadTextBox.Focus(); 
            } }

    private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e) { 
        try 
        { 
            if (CostoTextBox.Text.Trim() != "") {
                 decimal resultado = decimal.Parse(CostoTextBox.Text);
        }
        } catch { 
            MessageBox.Show($"Porfavor, digite un numero.");
            CostoTextBox.Clear();
            CostoTextBox.Focus(); 
            } 
    }

private void ITBISTextBox_TextChanged(object sender, TextChangedEventArgs e) { 
        try 
        { 
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
            }
        }
    
        private bool Validar() 
        { 
            bool Validado = true;  
            string Mensaje = "";

            if (VentaIdTextBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (ClienteIdComboBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida en Cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrWhiteSpace(NCFTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese el NCF";
            }
             if (string.IsNullOrWhiteSpace(ITBISTextBox.Text))
            {
                Validado = false; 
                Mensaje += "Ingrese el % de Itbis";
            }
          
            if(Validado == false){
                MessageBox.Show(Mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Validado; 
        }
    }
    }