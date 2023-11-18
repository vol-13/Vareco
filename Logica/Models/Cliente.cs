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
    public class Cliente
    {
        public int clienteID { get; set; }
        public string clienteCedula { get; set; }
        public string clienteNombre { get; set; }
        public string clienteTelefono { get; set; }
        public string clienteEmail { get; set; }
        public string clienteDireccion { get; set; }
        public bool activo { get; set; }

        TipoCliente MiTipoCliente { get; set; }

        public Cliente()
        {
            MiTipoCliente = new TipoCliente();
        }
    

        

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.clienteCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.clienteNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.clienteTelefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.clienteEmail));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.clienteDireccion));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@TipoID", this.MiTipoCliente.tipoClienteID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPClienteAgregar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.clienteCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.clienteNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.clienteTelefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.clienteEmail));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.clienteDireccion));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@TipoID", this.MiTipoCliente.tipoClienteID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.clienteID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPClienteEditar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.clienteCedula));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPClienteEliminar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.clienteCedula));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPClienteActivar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.clienteCedula));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPConsultarCliente");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public Cliente ConsultarObj()
        {
            Cliente R = new Cliente();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.clienteCedula));

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPConsultarCliente");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.clienteID = Convert.ToInt32(dr["ClienteID"]);
                R.clienteNombre = Convert.ToString(dr["ClienteNombre"]);
                R.clienteCedula = Convert.ToString(dr["ClienteCedula"]);
                R.clienteEmail = Convert.ToString(dr["ClienteEmail"]);
                R.clienteTelefono = Convert.ToString(dr["ClienteTelefono"]);
                R.clienteDireccion = Convert.ToString(dr["ClienteDireccion"]);

                R.MiTipoCliente.tipoClienteID = Convert.ToInt32(dr["TipoClienteID"]);
                R.MiTipoCliente.tipoClienteDescripcion = Convert.ToString(dr["TipoClienteDescripcion"]);
            }

            return R;
        }

        public DataTable ListarActivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarActivosClientes");

            return R;
        }

        public DataTable ListarInactivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarInactivosClientes");

            return R;
        }



    }
}
        