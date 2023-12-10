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
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Interfaz.Formularios
{
    public partial class FrmPedidos : Form
    {
        private Logica.Models.Pedido MiPedidoLocal {  get; set; }
        private Logica.Models.PedidoDetalle MiPedidoDetalle { get; set; }

        private DataTable ListaPedidos { get; set; }
        int productoID = 0;
        public FrmPedidos()
        {
            InitializeComponent();
            MiPedidoLocal = new Logica.Models.Pedido();
            MiPedidoDetalle = new Logica.Models.PedidoDetalle();
            ListaPedidos = new DataTable();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            CargarListaPedidos();
            CargarEstado();
        }

        private void LimpiarFormulario()
        {
            txtPedidoCliente.Clear();
            txtPedidoFecha.Clear();
            txtPedidoNotas.Clear();
            txtPedidoProducto.Clear();
            txtPedidoID.Clear();
            txtPedidoUsuario.Clear();
            txtTotal.Clear();
            cbEstadoPedido.SelectedIndex = -1;
            numCanPedido.Value = 0;
            dateEntrega.Value = DateTime.Now;

        }

       public void CargarListaPedidos()
        {
            ListaPedidos = new DataTable();

            string filtrarBusqueda = "";

            if(!string.IsNullOrEmpty(txtBuscar.Text.Trim()) && txtBuscar.Text.Count() >= 3)
            {
                filtrarBusqueda =txtBuscar.Text.Trim();
            }

            if (cbVerActivos.Checked)
            {
                ListaPedidos = MiPedidoLocal.ListarActivos(filtrarBusqueda);
            }
            else
            {
                ListaPedidos = MiPedidoLocal.ListarInactivos(filtrarBusqueda);
            }

            dgLista.DataSource = ListaPedidos;

        }

        public void CargarEstado()
        {
            Logica.Models.EstadoPedido estado = new Logica.Models.EstadoPedido();

            DataTable dt = new DataTable();

            dt = estado.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                cbEstadoPedido.ValueMember = "ID";
                cbEstadoPedido.DisplayMember = "Descripcion";
                cbEstadoPedido.DataSource = dt;
                cbEstadoPedido.SelectedIndex = -1;
            }
        }


        private void cbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaPedidos();

            if (cbVerActivos.Checked)
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

                int pedidoID = Convert.ToInt32(MiFila.Cells["CCodigo"].Value);

                 productoID = Convert.ToInt32(MiFila.Cells["CIDProducto"].Value);

              

                MiPedidoLocal = new Logica.Models.Pedido();
                MiPedidoDetalle = new Logica.Models.PedidoDetalle();

                MiPedidoLocal.pedidoID = pedidoID;
                MiPedidoLocal.MiPedidoDetalle.MiProducto.productoID = productoID;

             
                MiPedidoLocal = MiPedidoLocal.ConsultarObj();
                

                if (MiPedidoLocal != null && MiPedidoLocal.pedidoID > 0 )
                {
                    txtPedidoID.Text = Convert.ToString(MiPedidoLocal.pedidoID);
                    txtPedidoFecha.Text = Convert.ToString(MiPedidoLocal.pedidoFecha);
                    dateEntrega.Value = MiPedidoLocal.pedidoFechaEntrega;
                    txtPedidoNotas.Text = MiPedidoLocal.pedidoNotas;
                    txtPedidoUsuario.Text = MiPedidoLocal.MiTipoUsuario.usuarioNombre;
                    txtPedidoCliente.Text = MiPedidoLocal.MiCliente.clienteNombre;
                    cbEstadoPedido.SelectedValue = MiPedidoLocal.MiEstadoPedido.estadoPedidoID;
                    txtPedidoProducto.Text = MiPedidoLocal.MiPedidoDetalle.MiProducto.productoNombre;
                    numCanPedido.Value = Convert.ToDecimal(MiPedidoLocal.MiPedidoDetalle.pedidoDetalleCantidad);
                    txtTotal.Text = Convert.ToString(MiPedidoLocal.MiPedidoDetalle.pedidoDetallePrecio);

                }

            }
        }

        private bool ValidarDatos()
        {
            bool R = true;

            if (string.IsNullOrEmpty(dateEntrega.Text.Trim()))
            {
                MessageBox.Show("Debe digitar una fecha de entrega para el pedido", "Error de validación", MessageBoxButtons.OK);
                dateEntrega.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPedidoUsuario.Text.Trim()))
            {
                MessageBox.Show("Debe seleccionar un usuario para el pedido", "Error de validación", MessageBoxButtons.OK);
                txtPedidoUsuario.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPedidoCliente.Text.Trim()))
            {
                MessageBox.Show("Debe seleccionar un cliente para el pedido", "Error de validación", MessageBoxButtons.OK);
                txtPedidoCliente.Focus();
                return false;
            }

            if (cbEstadoPedido.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un esta para el pedido", "Error de validación", MessageBoxButtons.OK);
                cbEstadoPedido.Focus();
                return false;
            }

            if (numCanPedido.Value == 0)
            {
                MessageBox.Show("Debe seleccionar una cantidad de productos para el pedido", "Error de validación", MessageBoxButtons.OK);
                numCanPedido.Focus();
                return false;
            }

            return R;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
                if (ValidarDatos())
                {
                    MiPedidoLocal.pedidoFechaEntrega = dateEntrega.Value;
                    MiPedidoLocal.pedidoNotas = txtPedidoNotas.Text.Trim();
                    MiPedidoLocal.MiEstadoPedido.estadoPedidoID = Convert.ToInt32(cbEstadoPedido.SelectedValue);
                    MiPedidoLocal.MiPedidoDetalle.MiProducto.productoID = productoID;
                    MiPedidoLocal.MiPedidoDetalle.pedidoDetalleCantidad = Convert.ToInt32(numCanPedido.Value);

                    if (MiPedidoLocal.Consultar())
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro que desea modificar el pedido?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.Yes)
                        {
                            if (MiPedidoLocal.Editar())// && MiPedidoDetalle.Editar())
                            {

                                MessageBox.Show("El pedido ha sido modificado correctamente", "", MessageBoxButtons.OK);
                                LimpiarFormulario();
                                CargarListaPedidos();
                                
                            }
                        }
                    }
                }
        }   

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            dgLista.ClearSelection();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MiPedidoLocal.pedidoID > 0 && MiPedidoLocal.ConsultarID())
            {
                if (cbVerActivos.Checked)
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea eliminar el pedido?", "", MessageBoxButtons.YesNo
                       , MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiPedidoLocal.Eliminar())
                        {
                            MessageBox.Show("El pedido ha sido eliminado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaPedidos();
                        }

                    }
                }

                else
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea activar el pedido?", "", MessageBoxButtons.YesNo
                     ,MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiPedidoLocal.Activar())
                        {
                            MessageBox.Show("El pedido ha sido activado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaPedidos();
                        }

                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarListaPedidos();
        }
    }
}
