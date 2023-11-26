using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class TipoCliente
    {
        public int tipoClienteID { get; set; }
        public string tipoClienteDescripcion { get; set; }
        
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            Services.Conexion MiCnn = new Services.Conexion();

            R = MiCnn.EjecutarSELECT("SPListarTipoCliente");

            return R;
        }

        

    }


}
