using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WaoCellDominicana_ProyectoFinal_Ap1.BLL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;

namespace WaoCellDominicana_ProyectoFinal_Ap1.UI.Consultas
{
    /// <summary>
    /// </summary>
    public partial class ConsultaVentas : Window
    {
   /*     public ConsultaVentas()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = VentasBLL.GetList(p => p.VentaId == this.ToInt(CriterioTextBox.Text));
                        break;

                 /*   case 1:
                        listado = VentasBLL.GetList(p => p.ArticuloId == this.ToInt(CriterioTextBox.Text));
                        break;*/
                }
            }
            else
            {
                listado = VentasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }

        public int ToInt(string value)
        {
            int retorno = 0;

            int.TryParse(value,                                                                                      out retorno);

            return retorno;
        }

        
    }
}
