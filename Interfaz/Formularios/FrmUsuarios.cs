using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Formularios
{
    public partial class FrmUsuarios : Form
    {
        private Logica.Models.Usuario MiUsuarioLocal {  get; set; }

        private DataTable ListaUsuarios { get; set; }
        public FrmUsuarios()
        {
            InitializeComponent();
            MiUsuarioLocal = new Logica.Models.Usuario();
            ListaUsuarios = new DataTable();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.MiFormPrincipal;
            CargarListaUsuarios();
            CargarRoles();
            ActivarAgregar();
        }
        private void LimpiarFormulario()
        {
            txtUsuarioID.Clear();
            txtUsuarioCedula.Clear();
            txtUsuarioContrasenia.Clear();
            txtUsuarioCorreo.Clear();
            txtUsuarioDireccion.Clear();
            txtUsuarioNombre.Clear();
            txtUsuarioTelefono.Clear();
            cbUsuarioRol.SelectedIndex = -1;

        }
        private void ActivarAgregar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void ActivarEditarEliminar()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }
        public void CargarListaUsuarios()
        {
            ListaUsuarios = new DataTable();

            string filtroBusqueda = "";

            if(!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {
                
                filtroBusqueda = TxtBuscar.Text.Trim();

            }

            if (cBoxVerActivos.Checked)
            {
                ListaUsuarios = MiUsuarioLocal.ListarActivos(filtroBusqueda);
            }
            else
            {
                ListaUsuarios = MiUsuarioLocal.ListarInactivos(filtroBusqueda);

            }

            dgLista.DataSource = ListaUsuarios;

        }

        public void CargarRoles()
        {
            Logica.Models.UsuarioRol usuarioRol = new Logica.Models.UsuarioRol();
            
            DataTable dt = new DataTable();

            dt = usuarioRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                cbUsuarioRol.ValueMember = "ID";
                cbUsuarioRol.DisplayMember = "Descripcion";
                cbUsuarioRol.DataSource = dt;
                cbUsuarioRol.SelectedIndex = -1;
            }


        }

       

        private void cBoxVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaUsuarios();

            if(cBoxVerActivos.Checked)
            {
                btnEliminar.Text = "ELIMINAR";
                btnEliminar.BackColor = Color.Firebrick;
            }
            else
            {
                btnEliminar.Text = "ACTIVAR";
                btnEliminar.BackColor = Color.OrangeRed;
            }
        }

        private void dgLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgLista.ClearSelection();
        }

        private void dgLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgLista.SelectedRows.Count == 1)
            {
                LimpiarFormulario();

                DataGridViewRow MiFila = dgLista.SelectedRows[0];

                string cedulaUsario = Convert.ToString(MiFila.Cells["CCedula"].Value);

                MiUsuarioLocal = new Logica.Models.Usuario();

                MiUsuarioLocal.usuarioCedula = cedulaUsario;

                MiUsuarioLocal = MiUsuarioLocal.ConsultarObj();

                if (MiUsuarioLocal != null && MiUsuarioLocal.usuarioID > 0)
                {
                    txtUsuarioID.Text = Convert.ToString(MiUsuarioLocal.usuarioID);
                    txtUsuarioCedula.Text = MiUsuarioLocal.usuarioCedula;
                    txtUsuarioCorreo.Text = MiUsuarioLocal.usuarioCorreo;
                    txtUsuarioDireccion.Text = MiUsuarioLocal.usuarioDireccion;
                    txtUsuarioNombre.Text = MiUsuarioLocal.usuarioNombre;
                    txtUsuarioTelefono.Text = MiUsuarioLocal.usuarioTelefono;
                    cbUsuarioRol.SelectedValue = MiUsuarioLocal.MiTipoRol.usuarioRolID;

                    ActivarEditarEliminar();


                }



            }



        }

     

        private bool ValidarDatos(bool omitirContrasenia = false)
        {
            bool R = false;

            if (!string.IsNullOrEmpty(txtUsuarioNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(txtUsuarioCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(txtUsuarioTelefono.Text.Trim()) &&
                !string.IsNullOrEmpty(txtUsuarioCorreo.Text.Trim()) &&

                cbUsuarioRol.SelectedIndex > -1)
            {

                if (omitirContrasenia)
                {
                    R = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtUsuarioContrasenia.Text.Trim()))
                    {
                        R = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe digitar una contraseña para el usuario", "Error de validación", MessageBoxButtons.OK);
                        txtUsuarioContrasenia.Focus();
                        return false;
                    }
                }


            }
            else
            {
                if (string.IsNullOrEmpty(txtUsuarioNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre para el usuario", "Error de validación", MessageBoxButtons.OK);
                    txtUsuarioNombre.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtUsuarioCedula.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una cédula para el usuario", "Error de validación", MessageBoxButtons.OK);
                    txtUsuarioCedula.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtUsuarioTelefono.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un número de teléfono para el usuario", "Error de validación", MessageBoxButtons.OK);
                    txtUsuarioTelefono.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtUsuarioCorreo.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un correo para el usuario", "Error de validación", MessageBoxButtons.OK);
                    txtUsuarioCorreo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtUsuarioContrasenia.Text.Trim()))
                {

                }

                if (cbUsuarioRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un rol para el usuario", "Error de validación", MessageBoxButtons.OK);
                    cbUsuarioRol.Focus();
                    return false;
                }


            }

            return R;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                bool cedula;

                MiUsuarioLocal = new Logica.Models.Usuario();

                MiUsuarioLocal.usuarioNombre = txtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.usuarioCedula = txtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.usuarioTelefono = txtUsuarioTelefono.Text.Trim();
                MiUsuarioLocal.usuarioCorreo = txtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.usuarioContrasenia = txtUsuarioContrasenia.Text.Trim();
                MiUsuarioLocal.usuarioDireccion = txtUsuarioDireccion.Text.Trim();

                MiUsuarioLocal.MiTipoRol.usuarioRolID = Convert.ToInt32(cbUsuarioRol.SelectedValue);

                cedula = MiUsuarioLocal.Consultar();

                if(cedula == false)
                {
                    string msj = string.Format("¿Está seguro que desea agregar al usuario {0}?", MiUsuarioLocal.usuarioNombre);

                    DialogResult respuesta = MessageBox.Show(msj, "", MessageBoxButtons.YesNo);

                    if(respuesta == DialogResult.Yes)
                    {
                        bool ok = MiUsuarioLocal.Agregar();


                        if (ok)
                        {
                            MessageBox.Show("Usuario almacenado correctamente", "", MessageBoxButtons.OK);

                            LimpiarFormulario();

                            CargarListaUsuarios();

                        }
                        else
                        {
                            MessageBox.Show("El Usuario se no almacenó correctamente, algo ha salido mnal", "", MessageBoxButtons.OK);

                        }

                    }

                }
                else
                {
                    if (cedula)
                    {
                        MessageBox.Show("Ya existe este usuario", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }
                }

            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos(true))
            {
                MiUsuarioLocal.usuarioNombre = txtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.usuarioCedula = txtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.usuarioTelefono = txtUsuarioTelefono.Text.Trim();
                MiUsuarioLocal.usuarioCorreo = txtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.usuarioContrasenia = txtUsuarioContrasenia.Text.Trim();
                MiUsuarioLocal.usuarioDireccion = txtUsuarioDireccion.Text.Trim();
                MiUsuarioLocal.MiTipoRol.usuarioRolID = Convert.ToInt32(cbUsuarioRol.SelectedValue);

                
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea modificar el usuario?"," ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Editar())
                        {
                            MessageBox.Show("El usuario ha sido modificado correctamente", "", MessageBoxButtons.OK);

                            LimpiarFormulario();
                            CargarListaUsuarios();
                        }


                    }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MiUsuarioLocal.usuarioID > 0 && MiUsuarioLocal.Consultar())
            {

                if (cBoxVerActivos.Checked)
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea eliminar el usuario?", "???", MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Eliminar())
                        {
                            MessageBox.Show("El usuario ha sido eliminado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaUsuarios();
                        }

                    }

                }
                else
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea activar el usuario?", "", MessageBoxButtons.YesNo
                     , MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Activar())
                        {
                            MessageBox.Show("El usuario ha sido activado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaUsuarios();
                        }

                    }

                }



            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            dgLista.ClearSelection();
            ActivarAgregar();
        }

        private void txtUsuarioNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);

        }

        private void txtUsuarioCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);

        }

        private void txtUsuarioTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);

        }

        private void txtUsuarioCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);

        }

        private void txtUsuarioContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);

        }

        private void txtUsuarioDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);

        }

        private void txtUsuarioCorreo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuarioCorreo.Text.Trim()))
            {
                if (!Validaciones.ValidarEmail(txtUsuarioCorreo.Text.Trim()))
                {
                    MessageBox.Show("El formato del correo electrónico es incorrecto", "Error de la validación", MessageBoxButtons.OK);
                    txtUsuarioCorreo.Focus();
                }
            }
        }

        private void txtUsuarioCorreo_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuarioCorreo.Text.Trim()))
            {
                txtUsuarioCorreo.SelectAll();
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarListaUsuarios();
        }

        
    }
}
