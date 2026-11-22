using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanesVuelo
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Load(object sender, EventArgs e)
        {

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Recoger los datos introducidos
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Comprobar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Debes rellenar todos los campos.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Comprobar que las contraseñas coincidan
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "Error de registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtPassword.Focus();

                return;
            }

            try
            {
                // Intentar registrar el usuario en SQLite
                bool registrado = UserDatabase.RegisterUser(username, password);

                if (registrado)
                {
                    MessageBox.Show(
                        "¡Usuario registrado correctamente!",
                        "Registro completado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Volver al formulario de Login
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Este nombre de usuario ya está registrado.",
                        "Usuario existente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Se ha producido un error al registrar el usuario:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
