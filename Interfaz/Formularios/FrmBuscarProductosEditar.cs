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
    public partial class FrmBuscarProductosEditar : Form
    {
        DataTable ListaProductos { get; set; }

        Producto MiProductoLocal { get; set; }
        public FrmBuscarProductosEditar()
        {
            InitializeComponent();
            MiProductoLocal = new Producto();
            ListaProductos = new DataTable();
        }

        private void FrmBuscarPedidosEditar_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void ListarProductos()
        {
            dgLista.AutoGenerateColumns = false;

            ListaProductos = new DataTable();

            string filtroBusqueda = "";

            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {

                filtroBusqueda = TxtBuscar.Text.Trim();
            }

            ListaProductos = MiProductoLocal.ListarActivos(filtroBusqueda);

            dgLista.DataSource = ListaProductos;

            dgLista.ClearSelection();

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgLista.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgLista.SelectedRows[0];

                int productoID = Convert.ToInt32(row.Cells["CCodigo"].Value);

                string productoNombre = Convert.ToString(row.Cells["CNombre"].Value);

                Globales.MiFormPedidos.MiPedidoLocalG.MiPedidoDetalle.MiProducto.productoID = productoID;

                Globales.MiFormPedidos.MiPedidoLocalG.MiPedidoDetalle.MiProducto.productoNombre = productoNombre;

                DialogResult = DialogResult.OK;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
