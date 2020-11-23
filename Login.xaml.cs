using WaoCellDominicana_ProyectoFinal_Ap1;
using WaoCellDominicana_ProyectoFinal_Ap1.UI.Registros;
using WaoCellDominicana_ProyectoFinal_Ap1.DAL;
using WaoCellDominicana_ProyectoFinal_Ap1.Entidades;
using WaoCellDominicana_ProyectoFinal_Ap1.BLL;
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

namespace WaoCellDominicana_ProyectoFinal_Ap1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window {
        
        public Login() {
            InitializeComponent();
            UserNameTextBox.Focus();
           // PasswordTextBox.Password = string.Empty;

        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void IniciarSesionButton_Click(object sender , RoutedEventArgs e) {

          if (string.IsNullOrWhiteSpace(UserNameTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Password)) {
                MessageBox.Show("Ingrese sus datos de login");
                return;
            } else {
                this.Hide();
            
           }
            List<Usuarios> usuariosList = new List<Usuarios>();
            usuariosList = UsuariosBLL.GetList(u => u.NombreUsuario == UserNameTextBox.Text);
            if(usuariosList.Count == 1) {
                
               // string ClaveEncriptada = UsuariosBLL.GetSHA256(PasswordTextBox.Password);
                    //        if (usuariosList[0].Contraseña == ClaveEncriptada) 

                if (usuariosList[0].Contraseña == PasswordTextBox.Password) {
                    
                    this.Hide();
                    MainWindow menuPrincipal = new MainWindow();
                    menuPrincipal.Owner = this;
                    menuPrincipal.Show();

                } else {
                    MessageBox.Show("Contraseña incorrecta.");
                    this.Show();
                }

            } else {
                MessageBox.Show("Este usuario no existe.");
            } 
        }
    }
}
