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
using System.ComponentModel; // CancelEventArgs
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
            ProveedorComboBox.ItemsSource = ProveedoresBLL.GetList();
            ProveedorComboBox.SelectedValuePath = "ProveedoresId";
            ProveedorComboBox.DisplayMemberPath = "Nombre";
            ArticuloComboBox.ItemsSource = ArticulosBLL.GetList();
            ArticuloComboBox.SelectedValuePath = "ArticuloId";
            ArticuloComboBox.DisplayMemberPath = "Nombre";
            MonedaComboBox.ItemsSource = MonedasBLL.GetList();
            MonedaComboBox.SelectedValuePath = "MonedaId";
            MonedaComboBox.DisplayMemberPath = "Tipo";
            
        }

    }

}