using System;

using System.Windows.Forms;

namespace Interfaz.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

       

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnContrasenia_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar = false;
        }

        private void BtnContrasenia_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar = true;

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()) && !string.IsNullOrEmpty(TxtContrasenia.Text.Trim()))
            {

                string correo = TxtEmail.Text.Trim();
                string contrasenia = TxtContrasenia.Text.Trim();
 
                Globales.MiUsuarioGlobal = Globales.MiUsuarioGlobal.validarSesion(correo, contrasenia);

                if (Globales.MiUsuarioGlobal.usuarioID > 0)
                {

                    Globales.MiFormPrincipal.Show();

                    this.Hide();


                }

                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrecta", "Error de validación", MessageBoxButtons.OK);

                    TxtContrasenia.Focus();
                    TxtContrasenia.SelectAll();

                }


            }
            else
            {
                MessageBox.Show("Falta la información requerida", "Error de validación", MessageBoxButtons.OK);

            }


        }

        private void BtnIngresoDirecto_Click(object sender, EventArgs e)
        {
            Globales.MiFormPrincipal.Show();

            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
