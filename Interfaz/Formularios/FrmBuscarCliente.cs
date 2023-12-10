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
    public partial class FrmBuscarCliente : Form
    {
        Cliente MiClienteLocal {  get; set; }
        DataTable Lista {  get; set; }
        public FrmBuscarCliente()
        {
            InitializeComponent();
            MiClienteLocal = new Cliente();
            Lista = new DataTable();
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            ListaClientes();
        }

        private void ListaClientes()
        {
            dgLista.AutoGenerateColumns = false;

            Lista = new DataTable();

            string filtroBusqueda = "";

            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {

                filtroBusqueda = TxtBuscar.Text.Trim();

            }

            Lista = MiClienteLocal.ListarActivos(filtroBusqueda);

            dgLista.DataSource = Lista;

            dgLista.ClearSelection();

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(dgLista.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgLista.SelectedRows[0];

                int clienteID = Convert.ToInt32(row.Cells["CClienteID"].Value);

                string clienteNombre = Convert.ToString(row.Cells["CClienteNombre"].Value);

                Globales.MiFormRegistoPedido.MiPedidoLocal.MiCliente.clienteID = clienteID;

                Globales.MiFormRegistoPedido.MiPedidoLocal.MiCliente.clienteNombre = clienteNombre;

                DialogResult = DialogResult.OK;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListaClientes();
        }
    }
}
