using Logica.Models;
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
    public partial class FrmClientes : Form
    {
        private Logica.Models.Cliente MiClienteLocal {  get; set; }

        private DataTable ListaClientes { get; set; }
        public FrmClientes()
        {
            InitializeComponent();
            MiClienteLocal = new Logica.Models.Cliente();
            ListaClientes = new DataTable();
            ActivarAgregar();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarListaClientes();
            CargarRoles();
        }

        private void LimpiarFormulario()
        {
            txtClienteID.Clear();
            txtClienteCedula.Clear();
            txtClienteCorreo.Clear();
            txtClienteDireccion.Clear();
            txtClienteNombre.Clear();
            txtClienteTelefono.Clear();
            cbTipoCliente.SelectedIndex = -1;

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

        
        public void CargarListaClientes()
        {
            ListaClientes = new DataTable();

            string filtroBusqueda = "";

            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {

                filtroBusqueda = TxtBuscar.Text.Trim();

            }

            if (cBoxVerActivos.Checked)
            {
                ListaClientes = MiClienteLocal.ListarActivos(filtroBusqueda);
            }
            else
            {
                ListaClientes = MiClienteLocal.ListarInactivos(filtroBusqueda);

            }

            dgLista.DataSource = ListaClientes;

        }

        public void CargarRoles()
        {
            Logica.Models.TipoCliente clienteRol = new Logica.Models.TipoCliente();

            DataTable dt = new DataTable();

            dt = clienteRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                cbTipoCliente.ValueMember = "ID";
                cbTipoCliente.DisplayMember = "Descripcion";
                cbTipoCliente.DataSource = dt;
                cbTipoCliente.SelectedIndex = -1;
            }


        }

        private void cBoxVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaClientes();

            if (cBoxVerActivos.Checked)
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
            if (dgLista.SelectedRows.Count == 1)
            {
                LimpiarFormulario();

                DataGridViewRow MiFila = dgLista.SelectedRows[0];

                string cedulaCliente = Convert.ToString(MiFila.Cells["CClienteCedula"].Value);

                MiClienteLocal = new Logica.Models.Cliente();

                MiClienteLocal.clienteCedula = cedulaCliente;

                MiClienteLocal = MiClienteLocal.ConsultarObj();

                if (MiClienteLocal != null && MiClienteLocal.clienteID > 0)
                {
                    txtClienteID.Text = Convert.ToString(MiClienteLocal.clienteID);
                    txtClienteCedula.Text = MiClienteLocal.clienteCedula;
                    txtClienteCorreo.Text = MiClienteLocal.clienteEmail;
                    txtClienteDireccion.Text = MiClienteLocal.clienteDireccion;
                    txtClienteNombre.Text = MiClienteLocal.clienteNombre;
                    txtClienteTelefono.Text = MiClienteLocal.clienteTelefono;
                    cbTipoCliente.SelectedValue = MiClienteLocal.MiTipoCliente.tipoClienteID;
                    
                    ActivarEditarEliminar(); 

                    
                   

                }
              

            }
        }

        private bool ValidarDatos()
        {
            bool R = true;


            if (string.IsNullOrEmpty(txtClienteNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre para el cliente", "Error de validación", MessageBoxButtons.OK);
                    txtClienteNombre.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtClienteCedula.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una cédula para el cliente", "Error de validación", MessageBoxButtons.OK);
                    txtClienteCedula.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtClienteTelefono.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un número de teléfono para el cliente", "Error de validación", MessageBoxButtons.OK);
                    txtClienteTelefono.Focus();
                    return false;
                }
              
    

                if (cbTipoCliente.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un rol para el cliente", "Error de validación", MessageBoxButtons.OK);
                    cbTipoCliente.Focus();
                    return false;
                }

            return R;
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                bool cedula;

                MiClienteLocal = new Logica.Models.Cliente();

                MiClienteLocal.clienteNombre = txtClienteNombre.Text.Trim();
                MiClienteLocal.clienteCedula = txtClienteCedula.Text.Trim();
                MiClienteLocal.clienteTelefono = txtClienteTelefono.Text.Trim();
                MiClienteLocal.clienteEmail = txtClienteCorreo.Text.Trim();
                MiClienteLocal.clienteDireccion = txtClienteDireccion.Text.Trim();

                MiClienteLocal.MiTipoCliente.tipoClienteID = Convert.ToInt32(cbTipoCliente.SelectedValue);

                cedula = MiClienteLocal.Consultar();

                if (cedula == false)
                {
                    string msj = string.Format("¿Está seguro que desea agregar al cliente {0}?", MiClienteLocal.clienteNombre);

                    DialogResult respuesta = MessageBox.Show(msj, "", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiClienteLocal.Agregar();


                        if (ok)
                        {
                            MessageBox.Show("Cliente almacenado correctamente", "", MessageBoxButtons.OK);

                            LimpiarFormulario();

                            CargarListaClientes();

                        }
                        else
                        {
                            MessageBox.Show("El cliente no se almacenó correctamente, algo ha salido mnal", "", MessageBoxButtons.OK);

                        }

                    }

                }
                else
                {
                    if (cedula)
                    {
                        MessageBox.Show("Ya existe este cliente", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                MiClienteLocal.clienteNombre = txtClienteNombre.Text.Trim();
                MiClienteLocal.clienteCedula = txtClienteCedula.Text.Trim();
                MiClienteLocal.clienteTelefono = txtClienteTelefono.Text.Trim();
                MiClienteLocal.clienteEmail = txtClienteCorreo.Text.Trim();
                MiClienteLocal.clienteDireccion = txtClienteDireccion.Text.Trim();

                MiClienteLocal.MiTipoCliente.tipoClienteID = Convert.ToInt32(cbTipoCliente.SelectedValue);

                if (MiClienteLocal.Consultar())
                { 
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea modificar el cliente?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiClienteLocal.Editar())
                        {
                            MessageBox.Show("El cliente ha sido modificado correctamente", "", MessageBoxButtons.OK);

                            LimpiarFormulario();
                            CargarListaClientes();
                            ActivarAgregar();
                        }
                    }


                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MiClienteLocal.clienteID > 0 && MiClienteLocal.Consultar())
            {

                if (cBoxVerActivos.Checked)
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea eliminar al cliente?", "", MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiClienteLocal.Eliminar())
                        {
                            MessageBox.Show("El cliente ha sido eliminado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaClientes();
                            ActivarAgregar();
                        }

                    }

                }
                else
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea activar al cliente?", "", MessageBoxButtons.YesNo
                     , MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiClienteLocal.Activar())
                        {
                            MessageBox.Show("El cliente ha sido activado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaClientes();
                            ActivarAgregar();

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

        private void txtClienteNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);

        }

        private void txtClienteCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);

        }

        private void txtClienteTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);

        }

        private void txtClienteCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);

        }

        private void txtClienteDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);

        }

        private void txtClienteCorreo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClienteCorreo.Text.Trim()))
            {
                if (!Validaciones.ValidarEmail(txtClienteCorreo.Text.Trim()))
                {
                    MessageBox.Show("El formato del correo electrónico es incorrecto", "Error de la validación", MessageBoxButtons.OK);
                    txtClienteCorreo.Focus();
                }
            }
        }

        private void txtClienteCorreo_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClienteCorreo.Text.Trim()))
            {
                txtClienteCorreo.SelectAll();
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarListaClientes();
        }
    }
}
