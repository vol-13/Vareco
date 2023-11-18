using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class PedidoDetalle
    {
        public int pedidoDetalleCantidad { get; set; }
        public decimal pedidoDetallePrecio { get; set; }

        public Producto MiProducto { get; set; }

        PedidoDetalle()
        {
            MiProducto = new Producto();
        }

    }


}
