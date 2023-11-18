using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Pedido
    {
        public int pedidoID { get; set; }
        public int pedidoNumero { get; set; }
        public DateTime pedidoFecha { get; set; }
        public DateTime pedidoFechaEntrega { get; set; }
        public string pedidoNotas { get; set; }
        public bool activo { get; set; }

        public EstadoPedido MiEstadoPedido { get; set; }
        public Usuario MiTipoUsuario { get; set; }
        public Cliente MiCliente { get; set; }

        public List<PedidoDetalle> ListaPedidosDetalles { get; set; }

        public Pedido()
        {
            MiEstadoPedido = new EstadoPedido();
            MiTipoUsuario = new Usuario();
            MiCliente = new Cliente();
            ListaPedidosDetalles = new List<PedidoDetalle>();
        }
    } }/*
        public bool Agregar()
        {

        }

        public bool Editar()
        {

        }

        public bool Eliminar()
        {

        }

        public bool Activar()
        {

        }

        public bool Consultar()
        {

        }

        public Pedido ConsultarObj()
        {

        }

        public DataTable ListarActivos()
        {

        }

        public DataTable ListarInactivos()
        {

        }



    }
}
*/