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
    /// <summary>
    /// Interaction logic for RegistroArticulo.xaml
    /// </summary>
    public partial class ConsultaArticulos : Window
    {
        
        public ConsultaArticulos()
        {
            InitializeComponent();
            
        }


        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
             var listado = new List<Articulos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            listado = ArticulosBLL.GetList(e=>true);
                        }
                        catch (System.Exception e0)
                        {
                            
                            MessageBox.Show(e0.Message,"Error!",MessageBoxButton.OK);
                        }
                        
                    break;
                    
                  
                }

                
            }
            else
            {
                listado = ArticulosBLL.GetList(c => true);
            }

          
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }


}