using Logica.Models;
using System;
using System.Collections;
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
    public partial class FrmBuscarProducto : Form
    {
        DataTable ListaProductos {  get; set; }

        Producto MiProductoLocal { get; set; }
        public FrmBuscarProducto()
        {
            InitializeComponent();
            ListaProductos = new DataTable();
            MiProductoLocal = new Producto();

        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            if (dgLista.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgLista.SelectedRows[0];

                int ProductoID = Convert.ToInt32(row.Cells["CCodigo"].Value);
                string ProductoNombre = Convert.ToString(row.Cells["CNombre"].Value);
                decimal ProductoPrecio = Convert.ToDecimal(row.Cells["CPrecio"].Value);
                int ProductoCantidad = Convert.ToInt32(numCantidad.Value);

                DataRow MiFila = Globales.MiFormRegistoPedido.ListaProductos.NewRow();

                MiFila["ProductoID"] = ProductoID;
                MiFila["ProductoNombre"] = ProductoNombre;
                MiFila["pedidoDetallePrecio"] = ProductoPrecio;
                MiFila["pedidoDetalleCantidad"] = ProductoCantidad;

                Globales.MiFormRegistoPedido.ListaProductos.Rows.Add(MiFila);

                DialogResult = DialogResult.OK;

            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarProductos();
        }
    }
}
