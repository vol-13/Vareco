using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto
    {
        public int productoID { get; set; }
        public string productoNombre { get; set; }
        public int productoStock { get; set; }
        public decimal productoPrecio { get; set; }
        public string produtoNotas { get; set; }
        public bool activo { get; set; }


        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.productoNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Stock", this.productoStock));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Precio", this.productoPrecio));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Notas", this.produtoNotas));


            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProductoAgregar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Editar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.productoNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Stock", this.productoStock));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Precio", this.productoPrecio));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Notas", this.produtoNotas));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.productoID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProductoEditar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.productoNombre));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPProductoEliminar");

            if (respuesta > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Activar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.productoNombre));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPProductoActivar");

            if (respuesta > 0)
            {
                R = true;
            }

            return R;
        }

        public bool Consultar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.productoNombre));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPConsultarProducto");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public Producto ConsultarObj()
        {
            Producto R = new Producto();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.productoNombre));

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPConsultarProducto");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.productoID = Convert.ToInt32(dr["ProductoID"]);
                R.productoNombre = Convert.ToString(dr["ProductoNombre"]);
                R.productoStock = Convert.ToInt32(dr["ProductoStock"]);
                R.productoPrecio = Convert.ToDecimal(dr["ProductoPrecio"]);
                R.produtoNotas = Convert.ToString(dr["ProductoNotas"]);

                
            }

            return R;
        }

        public DataTable ListarActivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarActivosProductos");

            return R;
        }

        public DataTable ListarInactivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarInactivosProductos");

            return R;
        }


    }
}
