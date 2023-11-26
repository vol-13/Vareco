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
    public partial class FrmRegistroPedido : Form
    {
        public Pedido MiPedidoLocal {  get; set; }

        public DataTable ListaProductos { get; set; }
        public FrmRegistroPedido()
        {
            InitializeComponent();
            MiPedidoLocal = new Pedido();
            ListaProductos = new DataTable();
        }

        private void FrmRegistroPedido_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.MiFormPrincipal;
            EstadoCompra();
            LimpiarForm();
        }

        private void EstadoCompra()
        {
            DataTable dtEstados = new DataTable();

            dtEstados = MiPedidoLocal.MiEstadoPedido.Listar();

            cBoxEstado.ValueMember = "ID";
            cBoxEstado.DisplayMember = "Descripcion";

            cBoxEstado.DataSource = dtEstados;

            cBoxEstado.SelectedIndex = -1;

        }

        private void LimpiarForm()
        {
            txtCliente.Clear();
            txtNotas.Clear();
            txtTotal.Text = "0";
            txtItems.Text = "0";
            cBoxEstado.SelectedIndex = -1;

            ListaProductos = MiPedidoLocal.CargarEsquemaDetalle();

            dgLista.DataSource = ListaProductos;
        }

        private void btnClienteBuscar_Click(object sender, EventArgs e)
        {
            Form FormBuscarCliente = new FrmBuscarCliente();

            DialogResult R = FormBuscarCliente.ShowDialog();

            if (R == DialogResult.OK)
            {
                txtCliente.Text = MiPedidoLocal.MiCliente.clienteNombre;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Form MiFormBuscarProducto = new FrmBuscarProducto();

            DialogResult R = MiFormBuscarProducto.ShowDialog();

            if (R == DialogResult.OK)
            {
                dgLista.DataSource = ListaProductos;
                Total();
            }
        }

        private void Total()
        {
            if(ListaProductos.Rows.Count > 0)
            {
                int totalProductos = 0;
                decimal totalMonto = 0;

                foreach (DataRow row in ListaProductos.Rows)
                {
                    totalProductos += Convert.ToInt32(row["pedidoDetalleCantidad"]);
                    totalMonto += Convert.ToDecimal(row["pedidoDetallePrecio"]) * Convert.ToInt32(row["pedidoDetalleCantidad"]);
                }

                txtItems.Text = totalProductos.ToString();
                txtTotal.Text = totalMonto.ToString() + " ₡";
            }
        }

        private bool ValidarCompra()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(txtCliente.Text.Trim()) && cBoxEstado.SelectedIndex >= 0
                && ListaProductos.Rows.Count > 0)
            {
                R = true;

            }
            else
            {
                if (string.IsNullOrEmpty(txtCliente.Text.Trim()))
                {
                    MessageBox.Show("Se debe seleccionar un cliente", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (cBoxEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Se debe seleccionar un estado de pedido", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (ListaProductos.Rows.Count == 0)
                {
                    MessageBox.Show("Debe existir al menos una fila en el detalle", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
            }

            return R;
        }

        private void TrasladoDetallesPedido()
        {
            int cantidad = 0;
            decimal precio = 0;
            int Total = 0;

            foreach (DataRow row in ListaProductos.Rows)
            {
                cantidad = Convert.ToInt32(row["pedidoDetalleCantidad"]);
                precio = Convert.ToDecimal(row["pedidoDetallePrecio"]);
                Total = Convert.ToInt32(precio) * cantidad;

                PedidoDetalle detalle = new PedidoDetalle();
                detalle.MiProducto.productoID = Convert.ToInt32(row["ProductoID"]);
                detalle.pedidoDetalleCantidad = Convert.ToInt32(row["pedidoDetalleCantidad"]);
                detalle.pedidoDetallePrecio = Convert.ToDecimal(Total);

                MiPedidoLocal.ListaPedidosDetalles.Add(detalle);

            }
        }

        private void btnCrearPedido_Click(object sender, EventArgs e)
        {
            if(ValidarCompra())
            {
                MiPedidoLocal.MiEstadoPedido.estadoPedidoID = Convert.ToInt32(cBoxEstado.SelectedValue);
                MiPedidoLocal.pedidoNotas = txtNotas.Text.Trim();
                MiPedidoLocal.pedidoFechaEntrega = dateEntrega.Value;
                MiPedidoLocal.MiTipoUsuario.usuarioID = Globales.MiUsuarioGlobal.usuarioID;

                TrasladoDetallesPedido();

                if (MiPedidoLocal.Agregar())
                {
                    MessageBox.Show("Pedido realizado de forma correcta", "", MessageBoxButtons.OK);

                    LimpiarForm();
                }
            }
        }



    }
}
