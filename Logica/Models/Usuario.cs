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
    public class Usuario
    {
        public int usuarioID { get; set; }
        public string usuarioCorreo { get; set; }
        public string usuarioContrasenia { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioCedula { get; set; }
        public string usuarioTelefono { get; set; }
        public string usuarioDireccion { get; set; }
        public bool activo { get; set; }

        public UsuarioRol MiTipoRol { get; set; }

        public Usuario()
        {
            MiTipoRol = new UsuarioRol();
        }
        
        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.usuarioCorreo));

            
            Crytpo Micrytpo = new Crytpo();
            string ContrasenniaEncriptada = Micrytpo.EncriptarEnUnSentido(this.usuarioContrasenia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasenia", ContrasenniaEncriptada));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.usuarioNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.usuarioCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.usuarioTelefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.usuarioDireccion));

           
            MiCnn.ListaDeParametros.Add(new SqlParameter("@RolID", this.MiTipoRol.usuarioRolID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioAgregar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.usuarioCorreo));
            
            Crytpo Micrytpo = new Crytpo();
            string ContrasenniaEncriptada = Micrytpo.EncriptarEnUnSentido(this.usuarioContrasenia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasenia", ContrasenniaEncriptada));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.usuarioNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.usuarioCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.usuarioTelefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.usuarioDireccion));

           
            MiCnn.ListaDeParametros.Add(new SqlParameter("@RolID", this.MiTipoRol.usuarioRolID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.usuarioID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioEditar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.usuarioCedula));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioEliminar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.usuarioCedula));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioActivar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.usuarioCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDUsuario", this.usuarioID));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPConsultarUsuario");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public Usuario ConsultarObj()
        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.usuarioCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDUsuario", this.usuarioID));

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPConsultarUsuario");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.usuarioID = Convert.ToInt32(dr["UsuarioID"]);
                R.usuarioNombre = Convert.ToString(dr["UsuarioNombre"]);
                R.usuarioCedula = Convert.ToString(dr["UsuarioCedula"]);
                R.usuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]);
                R.usuarioTelefono = Convert.ToString(dr["UsuarioTelefono"]);
                R.usuarioDireccion = Convert.ToString(dr["UsuarioDireccion"]);

                R.usuarioContrasenia = string.Empty;

                R.MiTipoRol.usuarioRolID = Convert.ToInt32(dr["UsuarioRolID"]);
                R.MiTipoRol.usuarioRolDescripcion = Convert.ToString(dr["UsuarioRolDescripcion"]);
            }

            return R;

        }

        public DataTable ListarActivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

           
            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarActivosUsuarios");

            return R;
        }

        public DataTable ListarInactivos(string pBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@filtroBusqueda", pBusqueda));

            R = MiCnn.EjecutarSELECT("SPListarInactivosUsuarios");

            return R;
        }

        public Usuario validarSesion(string pCorreo, string pContrasenia)
        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            Crytpo crytpo = new Crytpo();
            string ContrasenniaEncriptada = crytpo.EncriptarEnUnSentido(pContrasenia);



            MiCnn.ListaDeParametros.Add(new SqlParameter("@correo", pCorreo));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@contrasenia", ContrasenniaEncriptada));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioValidarSesion");

            if (dt != null && dt.Rows.Count > 0)
            {
               
                DataRow dr = dt.Rows[0];

                R.usuarioID = Convert.ToInt32(dr["UsuarioID"]);
                R.usuarioNombre = Convert.ToString(dr["UsuarioNombre"]);
                R.usuarioCedula = Convert.ToString(dr["UsuarioCedula"]);
                R.usuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]);
                R.usuarioTelefono = Convert.ToString(dr["UsuarioTelefono"]);
                R.usuarioDireccion = Convert.ToString(dr["UsuarioDireccion"]);

                R.usuarioContrasenia = string.Empty;

                R.MiTipoRol.usuarioRolID = Convert.ToInt32(dr["UsuarioRolID"]);
                R.MiTipoRol.usuarioRolDescripcion = Convert.ToString(dr["UsuarioRolDescripcion"]);

            }

            return R;

        }




    }
}
