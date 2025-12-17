using FeriaAgricolaApp.Application.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaAgricolaApp.Presentation.Views
{
    public partial class FrmLogin : Form
    {
        private readonly LoginController loginController;
        public FrmLogin(LoginController loginController)
        {
            this.loginController = loginController;
            InitializeComponent();

            
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Debe ingresar el correo y la contraseña.");
                return;
            }

            var usuario = loginController.Login(email, pass);

            if (usuario != null)
            {
                Program.SetUsuarioActual(usuario);
                MessageBox.Show($"Bienvenido {usuario.Nombre}!", "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var principal = Program.CrearFrmPrincipal();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistro registro = new FrmRegistro(loginController);
            registro.ShowDialog();
        }

    }
}
