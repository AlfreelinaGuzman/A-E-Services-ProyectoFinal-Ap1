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
using WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros;
using WaoCellDominicana_ProyectoFinal_Ap1.UI.Consultas;

namespace WaoCellDominicana_ProyectoFinal_Ap1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void RegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuarios RU = new RegistroUsuarios();
            RU.Show();
        }

        private void ConsultarUsuario_Click(object sender, RoutedEventArgs e)
        {
            ConsultaUsuarios RU = new ConsultaUsuarios();
            RU.Show();
        }

    }
}
