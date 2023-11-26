using System.Windows.Forms;

namespace Interfaz
{
    public static class Globales
    {

        public static Form MiFormPrincipal = new Formularios.FrmMDI();

        public static Formularios.FrmUsuarios MiFormUsuarios = new Formularios.FrmUsuarios();
        public static Formularios.FrmClientes MiFormClientes = new Formularios.FrmClientes();
        public static Formularios.FrmProductos MiFormProductos = new Formularios.FrmProductos();
        public static Formularios.FrmRegistroPedido MiFormRegistoPedido = new Formularios.FrmRegistroPedido();
        public static Formularios.FrmPedidos MiFormPedidos = new Formularios.FrmPedidos();
        public static Formularios.FrmInformacion MiFormInfo = new Formularios.FrmInformacion();

        public static Logica.Models.Usuario MiUsuarioGlobal = new Logica.Models.Usuario();

    }
}
