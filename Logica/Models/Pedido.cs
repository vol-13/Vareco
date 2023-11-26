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
    public class Pedido
    {
        public int pedidoID { get; set; }
        public DateTime pedidoFecha { get; set; }
        public DateTime pedidoFechaEntrega { get; set; }
        public string pedidoNotas { get; set; }
        public bool activo { get; set; }

        public EstadoPedido MiEstadoPedido { get; set; }
        public Usuario MiTipoUsuario { get; set; }
        public Cliente MiCliente { get; set; }

        public PedidoDetalle MiPedidoDetalle { get; set; }

        public List<PedidoDetalle> ListaPedidosDetalles { get; set; }

        public Pedido()
        {
            MiEstadoPedido = new EstadoPedido();
            MiTipoUsuario = new Usuario();
            MiCliente = new Cliente();
            MiPedidoDetalle = new PedidoDetalle();
            ListaPedidosDetalles = new List<PedidoDetalle>();
        }

        public DataTable CargarEsquemaDetalle()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.EjecutarSELECT("SPPedidoDetalleEsquema", true);

            R.PrimaryKey = null;

            return R;
        }

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDCliente", this.MiCliente.clienteID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@EstadoPedido", this.MiEstadoPedido.estadoPedidoID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDUsuario", this.MiTipoUsuario.usuarioID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Notas", this.pedidoNotas));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@FechaEntrega", this.pedidoFechaEntrega));


            Object retorno = MiCnn.EjecutarSELECTEscalar("SPPedidoAgregar");

            int IDGenerada;

            if (retorno != null)
            {

                try
                {
                    IDGenerada = Convert.ToInt32(retorno.ToString());

                    this.pedidoID = IDGenerada;


                    foreach (PedidoDetalle item in this.ListaPedidosDetalles)
                    {
                        Conexion MiCnnDetalle = new Conexion();

                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDPedido", IDGenerada));
                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDProducto", item.MiProducto.productoID));
                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Cantidad", item.pedidoDetalleCantidad));
                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Precio", item.pedidoDetallePrecio));

                        MiCnnDetalle.EjecutarSELECT("SPPedidoDetalleAgregar");

                    }

                    R = true;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }


            return R;
        }

        public bool Editar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDPedido", this.pedidoID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@PedidoFechaEntraga", this.pedidoFechaEntrega));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@PedidoNotas", this.pedidoNotas));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@EstadoPedidoID", this.MiEstadoPedido.estadoPedidoID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ClienteID", this.MiCliente.clienteID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@UsuarioID", this.MiTipoUsuario.usuarioID));
         
            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPPedidoEditar");

            if (resultado > 0)
            {
                MiCnn.ListaDeParametros.Add(new SqlParameter("@IDPedido", this.pedidoID));
                MiCnn.ListaDeParametros.Add(new SqlParameter("@ProductoID", this.MiPedidoDetalle.MiProducto.productoID));
                MiCnn.ListaDeParametros.Add(new SqlParameter("@pedidoDetalleCantidad", this.MiPedidoDetalle.pedidoDetalleCantidad));
                MiCnn.ListaDeParametros.Add(new SqlParameter("@pedidoDetallePrecio", this.MiPedidoDetalle.pedidoDetallePrecio));
                int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPPedidoDetalleEditar");

                if(respuesta > 0)
                {
                    R = true;

                }

            }

            return R;
        }

        public DataTable ListarActivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarActivosPedidos");

            return R;
        }

        public DataTable ListarInactivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarInactivosPedidos");

            return R;
        }

        public bool Consultar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDPedido", this.pedidoID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDProducto", this.MiPedidoDetalle.MiProducto.productoID));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPConsultarPedido");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }
        public Pedido ConsultarObj()
        {
            Pedido R = new Pedido();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDPedido", this.pedidoID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDProducto", this.MiPedidoDetalle.MiProducto.productoID));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPConsultarPedido");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.pedidoID = Convert.ToInt32(dr["PedidoID"]);
                R.pedidoFecha = Convert.ToDateTime(dr["PedidoFecha"]);
                R.pedidoFechaEntrega = Convert.ToDateTime(dr["PedidoFechaEntraga"]);
                R.pedidoNotas = Convert.ToString(dr["PedidoNotas"]);

                R.MiEstadoPedido.estadoPedidoID = Convert.ToInt32(dr["ID"]);
                R.MiEstadoPedido.estadoPedidoDescripcion = Convert.ToString(dr["TIPO"]);

                R.MiTipoUsuario.usuarioNombre = Convert.ToString(dr["UsuarioNombre"]);

                R.MiCliente.clienteNombre = Convert.ToString(dr["ClienteNombre"]);

                R.MiPedidoDetalle.pedidoDetalleCantidad = Convert.ToInt32(dr["pedidoDetalleCantidad"]);
                R.MiPedidoDetalle.pedidoDetallePrecio = Convert.ToDecimal(dr["pedidoDetallePrecio"]);
                R.MiPedidoDetalle.MiProducto.productoNombre = Convert.ToString(dr["ProductoNombre"]);





            }

            return R;
        }


        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDPedido", this.pedidoID));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPPedidoEliminar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDPedido", this.pedidoID));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPPedidoActivar");

            if (respuesta > 0)
            {
                R = true;
            }

            return R;
        }
    }
}

