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
    public partial class ConsultaClientes : Window
    {
        //public List<Clientes> clientes { get; set; } = new List<Clientes>();

        public ConsultaClientes()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var clientes = new List<Clientes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                     try
                        {
                            clientes = ClientesBLL.GetList(e=>true);
                        }
                        catch (System.Exception e0)
                        {
                            
                            MessageBox.Show(e0.Message,"Error!",MessageBoxButton.OK);
                        }
                        break;

                    case 1:
                        clientes = ClientesBLL.GetList(p => p.ClienteId == this.ToInt(CriterioTextBox.Text));
                        break;
                    case 2:
                        clientes = ClientesBLL.GetClientes().Where(p => p.Nombres.Contains(CriterioTextBox.Text)).ToList();
                        break;
                    case 3:
                        clientes = ClientesBLL.GetClientes().Where(p => p.Cedula.Contains(CriterioTextBox.Text)).ToList();
                        break;
                }
            }

            if (DesdeDatePicker.SelectedDate != null) {
                clientes = clientes.Where(r => r.FechaRegistro >= DesdeDatePicker.SelectedDate).ToList();
            }

            if (HastaDatePicker.SelectedDate != null) {
                clientes = clientes.Where(r => r.FechaRegistro <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                clientes = ClientesBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = clientes;
        }

        public int ToInt(string value)
        {
            int retorno = 0;

            int.TryParse(value, out retorno);

            return retorno;
        }

    }
}
