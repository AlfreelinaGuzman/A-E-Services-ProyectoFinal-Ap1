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
    /// Interaction logic for RegistroUsuario.xaml
    /// </summary>
    public partial class ConsultaUsuarios : Window
    {
        
        public ConsultaUsuarios()
        {
            InitializeComponent();
            
        }


        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
             var listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            listado = UsuariosBLL.GetList(e=>true);
                        }
                        catch (System.Exception e0)
                        {
                            
                            MessageBox.Show(e0.Message,"Error!",MessageBoxButton.OK);
                        }
                        
                        break;
                    case 1:
                    try
                        {
                            listado = UsuariosBLL.GetList(e => e.UsuarioId == Convert.ToInt32(CriterioTextBox.Text));
                        }
                        catch (System.Exception e1)
                        {
                            
                            MessageBox.Show(e1.Message,"Error!",MessageBoxButton.OK);
                        }
                        break;
                    case 2:
                        try
                        {
                            listado = UsuariosBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text));
                        }
                        catch (System.Exception e2)
                        {
                            
                            MessageBox.Show(e2.Message,"Error!",MessageBoxButton.OK);
                        }
                        
                        break;
                    case 3:
                        try
                        {
                            listado = UsuariosBLL.GetList(e => e.Apellidos.Contains(CriterioTextBox.Text));
                        }
                        catch (System.Exception e3)
                        {
                            
                            MessageBox.Show(e3.Message,"Error!",MessageBoxButton.OK);
                        }
                        
                        break;
                    
                    case 4:
                        try
                        {
                            listado = UsuariosBLL.GetList(e => e.NombreUsuario.Contains(CriterioTextBox.Text));
                        }
                        catch (System.Exception e4)
                        {
                            
                            MessageBox.Show(e4.Message,"Error!",MessageBoxButton.OK);
                        }
                        
                        break;
                    case 5:
                        try
                        {
                            listado = UsuariosBLL.GetList(e => e.Telefono.Contains(CriterioTextBox.Text));
                        }
                        catch (System.Exception e5)
                        {
                            
                           MessageBox.Show(e5.Message,"Error!",MessageBoxButton.OK);
                        }
                        
                        break;
                    case 6:
                        try
                        {
                            listado = UsuariosBLL.GetList(e => e.Correo.Contains(CriterioTextBox.Text));
                        }
                        catch (System.Exception e6)
                        {
                            
                            MessageBox.Show(e6.Message,"Error!",MessageBoxButton.OK);
                        }
                        
                        break;
                  
                }

                
            }
            else
            {
                listado = UsuariosBLL.GetList(c => true);
            }

          
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }


}