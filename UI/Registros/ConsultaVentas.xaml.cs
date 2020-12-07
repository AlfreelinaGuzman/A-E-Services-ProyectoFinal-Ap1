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
    public partial class ConsultaVentas : Window
    {
        public ConsultaVentas()
        {
            InitializeComponent();
        }

         public List<Ventas> ventas { get; set; } = new List<Ventas>();

       private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            //var listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        ventas = VentasBLL.GetList(c => true);
                    break;
                    case 1:
                        ventas = VentasBLL.GetList(p => p.VentaId == this.ToInt(CriterioTextBox.Text));
                     break;
                    
                
                }
            }
            else
            {
                ventas = VentasBLL.GetList(c => true);
            }
            
            if (DesdeDatePicker.SelectedDate != null) {
                ventas = ventas.Where(r => r.Fecha >= DesdeDatePicker.SelectedDate).ToList();
            }

            if (HastaDatePicker.SelectedDate != null) {
                ventas = ventas.Where(r => r.Fecha <= HastaDatePicker.SelectedDate).ToList();
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = ventas;

        }

        public int ToInt(string value)
        {
            int retorno = 0;

            int.TryParse(value,                                                                                      out retorno);

            return retorno;
        }

    }
}
