using System.Windows.Forms;

namespace Interfaz
{
    public static class Globales
    {

        public static Form MiFormPrincipal = new Formularios.FrmMDI();

        public static Formularios.FrmUsuarios MiFormUsuarios = new Formularios.FrmUsuarios();
        public static Formularios.FrmClientes MiFormClientes = new Formularios.FrmClientes();
        public static Formularios.FrmProductos MiFormProductos = new Formularios.FrmProductos();


        public static Logica.Models.Usuario MiUsuarioGlobal = new Logica.Models.Usuario();

    }
}
