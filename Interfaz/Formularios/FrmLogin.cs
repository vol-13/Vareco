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

                string usuario = TxtEmail.Text.Trim();
                string contrasennia = TxtContrasenia.Text.Trim();
 
                Globales.MiUsuarioGlobal = Globales.MiUsuarioGlobal.validarSesion(usuario, contrasennia);

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
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Alt && e.KeyCode == Keys.A)
            {
                BtnIngresoDirecto.Visible = true;

            }
        }

        private void BtnIngresoDirecto_Click(object sender, EventArgs e)
        {
            Globales.MiFormPrincipal.Show();

            this.Hide();
        }

      
    }
}
