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

namespace WaoCellDominicana_ProyectoFinal_Ap1.UI.Consultas
{
    public partial class ConsultaProveedores : Window
    {
        public List<Proveedores> proveedores { get; set; } = new List<Proveedores>();

        public ConsultaProveedor()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
           // var listado = new List<proveedores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                     try
                        {
                            proveedores = ProveedoresBLL.GetList(e=>true);
                        }
                        catch (System.Exception e0)
                        {
                            
                            MessageBox.Show(e0.Message,"Error!",MessageBoxButton.OK);
                        }
                        break;

                    case 1:
                        proveedores = ProveedoresBLL.GetList(p => p.ProveedorId == this.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                proveedores = ProveedoresBLL.GetList(c => true);
            }
            
            if (DesdeDatePicker.SelectedDate != null) {
                proveedores = proveedores.Where(r => r.FechaRegistro >= DesdeDatePicker.SelectedDate).ToList();
            }

            if (HastaDatePicker.SelectedDate != null) {
                proveedores = proveedores.Where(r => r.FechaRegistro <= HastaDatePicker.SelectedDate).ToList();
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = proveedores;
        }

        public int ToInt(string value)
        {
            int retorno = 0;

            int.TryParse(value, out retorno);

            return retorno;
        }

        private void DatosDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
