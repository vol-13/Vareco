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
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
            this.IsMdiContainer = true;


        }

        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!Globales.MiFormUsuarios.Visible)
            {
                Globales.MiFormUsuarios = new FrmUsuarios();

                Globales.MiFormUsuarios.Show();
            }
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            string InfoUsuario = string.Format("{0} - {1}({2})",
            Globales.MiUsuarioGlobal.usuarioNombre,
            Globales.MiUsuarioGlobal.usuarioCorreo,
            Globales.MiUsuarioGlobal.MiTipoRol.usuarioRolDescripcion);

            lblUsuario.Text = InfoUsuario;

            switch (Globales.MiUsuarioGlobal.MiTipoRol.usuarioRolID)
            {
                case 1:
                    break;

                case 2:
                    gestiónDeUsuariosToolStripMenuItem.Visible = false;
                    break;

            }
        }

        
        private void gestiónDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiFormProductos.Visible)
            {
                Globales.MiFormProductos = new FrmProductos();

                Globales.MiFormProductos.Show();
            }
        }

        private void gestónDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiFormPedidos.Visible)
            {
                Globales.MiFormPedidos = new FrmPedidos();

                Globales.MiFormPedidos.Show();
            }
        }

        private void aCERCADEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Globales.MiFormInfo.Visible)
            {
                Globales.MiFormInfo = new FrmInformacion();

                Globales.MiFormInfo.Show();
            }
        }

        private void rEGISTRODEPEDIDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiFormRegistoPedido.Visible)
            {
                Globales.MiFormRegistoPedido = new FrmRegistroPedido();

                Globales.MiFormRegistoPedido.Show();
            }
        }

        private void gestiónDeClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!Globales.MiFormClientes.Visible)
            {
                Globales.MiFormClientes = new FrmClientes();

                Globales.MiFormClientes.Show();
            }
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!Globales.MiFormUsuarios.Visible)
            {
                Globales.MiFormUsuarios = new FrmUsuarios();

                Globales.MiFormUsuarios.Show();
            }
        }
    }
}
