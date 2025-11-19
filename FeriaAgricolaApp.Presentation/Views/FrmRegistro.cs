using FeriaAgricolaApp.Presentation.Controllers;
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
    public partial class FrmRegistro : Form
    {
        private readonly LoginController loginController;
        public FrmRegistro(LoginController loginController  )
        {
            this.loginController = loginController;
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.",
                    "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Debe ingresar un correo válido.",
                    "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar registrar
            bool registrado = loginController.RegistrarUsuario(nombre, email, pass, telefono);

            if (registrado)
            {
                MessageBox.Show("Usuario registrado correctamente.\nYa puede iniciar sesión.",
                    "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Regresa al login
            }
            else
            {
                MessageBox.Show("El correo ingresado ya se encuentra registrado.",
                    "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
