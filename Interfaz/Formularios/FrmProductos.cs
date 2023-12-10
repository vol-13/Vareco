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
    public partial class FrmProductos : Form
    {
        private Logica.Models.Producto MiProductoLocal {  get; set; }

        private DataTable ListaProductos { get; set; }

        public FrmProductos()
        {
            InitializeComponent();
            MiProductoLocal = new Logica.Models.Producto();
            ListaProductos = new DataTable();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarListaProductos();
            ActivarAgregar();
        }

        private void LimpiarFormulario()
        {
            txtProductoID.Clear();
            txtProductoNombre.Clear();
            txtProductoNotas.Clear();
            txtProductoPrecio.Clear();
            txtProductoStock.Clear();
            
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
        public void CargarListaProductos()
        {
            ListaProductos = new DataTable();

            string filtroBusqueda = "";

            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {

                filtroBusqueda = TxtBuscar.Text.Trim();

            }

            if (cBoxVerActivos.Checked)
            {
                ListaProductos = MiProductoLocal.ListarActivos(filtroBusqueda);
            }
            else
            {
                ListaProductos = MiProductoLocal.ListarInactivos(filtroBusqueda);

            }

            dgLista.DataSource = ListaProductos;

        }

        private void cBoxVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaProductos();

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

                int productoCodigo = Convert.ToInt32(MiFila.Cells["CProductoID"].Value); 

                MiProductoLocal = new Logica.Models.Producto();

                MiProductoLocal.productoID = productoCodigo;

                MiProductoLocal = MiProductoLocal.ConsultarObj();

                if (MiProductoLocal != null && MiProductoLocal.productoID > 0)
                {
                    txtProductoID.Text = Convert.ToString(MiProductoLocal.productoID);
                    txtProductoNombre.Text = MiProductoLocal.productoNombre;
                    txtProductoStock.Text = Convert.ToString(MiProductoLocal.productoStock);
                    txtProductoPrecio.Text = Convert.ToString(MiProductoLocal.productoPrecio);
                    txtProductoNotas.Text = MiProductoLocal.produtoNotas;
                   

                    ActivarEditarEliminar();


                }



            }
        }

        private bool ValidarDatos()
        {
            bool R = true;


            if (string.IsNullOrEmpty(txtProductoNombre.Text.Trim()))
            {
                MessageBox.Show("Debe digitar un nombre para el producto", "Error de validación", MessageBoxButtons.OK);
                txtProductoNombre.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtProductoStock.Text.Trim()))
            {
                MessageBox.Show("Debe digitar una cantidad de stock para el cliente", "Error de validación", MessageBoxButtons.OK);
                txtProductoStock.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtProductoPrecio.Text.Trim()))
            {
                MessageBox.Show("Debe digitar un precio para el producto", "Error de validación", MessageBoxButtons.OK);
                txtProductoPrecio.Focus();
                return false;
            }

            return R;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                bool id;

                MiProductoLocal = new Logica.Models.Producto();

                MiProductoLocal.productoNombre = txtProductoNombre.Text.Trim();
                MiProductoLocal.productoStock = Convert.ToInt32(txtProductoStock.Text.Trim());
                MiProductoLocal.productoPrecio = Convert.ToDecimal(txtProductoPrecio.Text.Trim());
                MiProductoLocal.produtoNotas = txtProductoNotas.Text.Trim();

                id = MiProductoLocal.Consultar();

                if (id == false)
                {
                    string msj = string.Format("¿Está seguro que desea agregar el producto {0}?", MiProductoLocal.productoNombre);

                    DialogResult respuesta = MessageBox.Show(msj, "", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiProductoLocal.Agregar();


                        if (ok)
                        {
                            MessageBox.Show("Producto almacenado correctamente", "", MessageBoxButtons.OK);

                            LimpiarFormulario();

                            CargarListaProductos();

                        }
                        else
                        {
                            MessageBox.Show("El producto no se almacenó correctamente, algo ha salido mnal", "", MessageBoxButtons.OK);

                        }

                    }

                }
                else
                {
                    if (id)
                    {
                        MessageBox.Show("Ya existe este producto", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                MiProductoLocal.productoNombre = txtProductoNombre.Text.Trim();
                MiProductoLocal.productoStock = Convert.ToInt32(txtProductoStock.Text.Trim());
                MiProductoLocal.productoPrecio = Convert.ToDecimal(txtProductoPrecio.Text.Trim());
                MiProductoLocal.produtoNotas = txtProductoNotas.Text.Trim();


                if (MiProductoLocal.Consultar())
                {


                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea modificar el producto?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiProductoLocal.Editar())
                        {
                            MessageBox.Show("El producto ha sido modificado correctamente", "", MessageBoxButtons.OK);

                            LimpiarFormulario();
                            CargarListaProductos();
                            ActivarAgregar();
                        }
                    }


                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MiProductoLocal.productoID > 0 && MiProductoLocal.Consultar())
            {

                if (cBoxVerActivos.Checked)
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea eliminar al producto?", "", MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiProductoLocal.Eliminar())
                        {
                            MessageBox.Show("El producto ha sido eliminado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaProductos();
                            ActivarAgregar();
                        }

                    }

                }
                else
                {
                    DialogResult r = MessageBox.Show("¿Está seguro que desea activar el producto?", "", MessageBoxButtons.YesNo
                     , MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiProductoLocal.Activar())
                        {
                            MessageBox.Show("El producto ha sido activado satisfactoriamente", "", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaProductos();
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

        private void txtProductoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);

        }

        private void txtProductoPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);
        }

        private void txtProductoStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);

        }

        private void txtProductoNotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarListaProductos();
        }



    }
}
