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
    public partial class ConsultaCompras : Window
    {
        public ConsultaCompras()
        {
            InitializeComponent();
        }

         public List<Compras> Compras { get; set; } = new List<Compras>();

       private void ConsultarButton_Click(object sender, RoutedEComprargs e)
        {
            //var listado = new List<Compras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        Compras = ComprasBLL.GetList(c => true);
                    break;
                    case 1:
                        Compras = ComprasBLL.GetList(p => p.CompraId == this.ToInt(CriterioTextBox.Text));
                     break;
                    
                
                }
            }
            else
            {
                Compras = ComprasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = Compras;

        }

        public int ToInt(string value)
        {
            int retorno = 0;

            int.TryParse(value,                                                                                      out retorno);

            return retorno;
        }

    }
}
