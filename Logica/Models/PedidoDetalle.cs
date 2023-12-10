using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class PedidoDetalle
    {
        public int pedidoID { get; set; }
        public int pedidoDetalleCantidad { get; set; }
        public decimal pedidoDetallePrecio { get; set; }

        public Producto MiProducto { get; set; }

        public PedidoDetalle()
        {
            MiProducto = new Producto();
        }

        public bool Editar()
        {
            bool R = false;

            Conexion MiCnnDetalle = new Conexion();

            MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDPedido", this.pedidoID));
            MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@ProductoID", this.MiProducto.productoID));
            MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@pedidoDetalleCantidad", this.pedidoDetalleCantidad));

            int resultado = MiCnnDetalle.EjecutarInsertUpdateDelete("SPPedidoDetalleEditar");

            if (resultado > 0)
            {
                R = true;

            }
            return R;

        }


    }
}
