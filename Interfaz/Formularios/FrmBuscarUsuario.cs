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
    public partial class FrmBuscarUsuario : Form
    {
        Usuario MiUsuarioLocal {  get; set; }

        DataTable Lista {  get; set; }
        public FrmBuscarUsuario()
        {
            InitializeComponent();
            MiUsuarioLocal = new Usuario();
            Lista = new DataTable();
        }

        private void FrmBuscarUsuario_Load(object sender, EventArgs e)
        {
            ListaUsuarios();
        }

        private void ListaUsuarios()
        {
            dgLista.AutoGenerateColumns = false;

            Lista = new DataTable();

            string filtroBusqueda = "";

            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {

                filtroBusqueda = TxtBuscar.Text.Trim();

            }

            Lista = MiUsuarioLocal.ListarActivos(filtroBusqueda);

            dgLista.DataSource = Lista;

            dgLista.ClearSelection();

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgLista.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgLista.SelectedRows[0];

                int usuarioID = Convert.ToInt32(row.Cells["CUsuarioID"].Value);

                string usuarioNombre = Convert.ToString(row.Cells["CUsuarioNombre"].Value);

                Globales.MiFormPedidos.MiPedidoLocalG.MiTipoUsuario.usuarioID = usuarioID;

                Globales.MiFormPedidos.MiPedidoLocalG.MiTipoUsuario.usuarioNombre = usuarioNombre;

                DialogResult = DialogResult.OK;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
