using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public class CDusuarios
    {
        CDconexion cd_conexion = new CDconexion();

        //LLAVE FORANEA
        public List<dynamic> MtdListarUsuarios()
        {
            List<dynamic> ListaUsuarios = new List<dynamic>();
            string QueryListaUsuarios = "Select CodigoRol, NombreRol from tbl_Roles";
            SqlCommand cmd = new SqlCommand(QueryListaUsuarios, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaUsuarios.Add(new
                {
                    Value = reader["CodigoRol"],
                    Text = $"{reader["CodigoRol"]} - {reader["NombreRol"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaUsuarios;
        }

        //METODOS:
        public DataTable MtdConsultarUsuario()
        {
            string QueryConsultarUsuario = "Select * from tbl_Usuarios";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarUsuario, cd_conexion.MtdAbrirConexion());
            DataTable dt_usuario = new DataTable();
            dt_adapter.Fill(dt_usuario);
            cd_conexion.MtdCerrarConexion();
            return dt_usuario;
        }

        public void MtdAgregarUsuario(int CodigoRol, string Nombre, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria, DateTime FechaRegistro, string Contrasena)
        {
            string QueryAgregarUsuario = "Insert into tbl_Usuarios(CodigoRol, Nombre, Estado, UsuarioAuditoria, FechaAuditoria, FechaRegistro, Contrasena) values (@CodigoRol, @Nombre, @Estado, @UsuarioAuditoria, @FechaAuditoria, @FechaRegistro, @Contrasena)";
            SqlCommand CommandAgregarUsuario = new SqlCommand(QueryAgregarUsuario, cd_conexion.MtdAbrirConexion());
            CommandAgregarUsuario.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandAgregarUsuario.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarUsuario.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarUsuario.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarUsuario.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarUsuario.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            CommandAgregarUsuario.Parameters.AddWithValue("@Contrasena", Contrasena);
            CommandAgregarUsuario.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarUsuario(int CodigoUsuario, int CodigoRol, string Nombre, string Estado, string UsuarioSistema, DateTime FechaAuditoria, DateTime FechaRegistro, string Contrasena)
        {
            string QueryActualizarUsuario = "Update tbl_Usuarios set CodigoRol= @CodigoRol, Nombre = @Nombre, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria, FechaRegistro = @FechaRegistro, Contrasena = @Contrasena where CodigoUsuario = @CodigoUsuario";
            SqlCommand CommandActualizarUsuario = new SqlCommand(QueryActualizarUsuario, cd_conexion.MtdAbrirConexion());
            CommandActualizarUsuario.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            CommandActualizarUsuario.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandActualizarUsuario.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarUsuario.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarUsuario.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioSistema);
            CommandActualizarUsuario.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarUsuario.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            CommandActualizarUsuario.Parameters.AddWithValue("@Contrasena", Contrasena);
            CommandActualizarUsuario.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarUsuario(int CodigoUsuario)
        {
            string QueryEliminarUsuario = "Delete tbl_Usuarios where CodigoUsuario = @CodigoUsuario";
            SqlCommand CommandEliminarUsuario = new SqlCommand(QueryEliminarUsuario, cd_conexion.MtdAbrirConexion());
            CommandEliminarUsuario.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            CommandEliminarUsuario.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public bool MtdConsultarEmpleados(int CodigoUsuario)
        {
            string QueryConsultarEncabezado = "SELECT 1 FROM tbl_Empleados WHERE CodigoUsuario = @CodigoUsuario";
            SqlCommand CommandEliminarMesa = new SqlCommand(QueryConsultarEncabezado, cd_conexion.MtdAbrirConexion());
            CommandEliminarMesa.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarMesa.ExecuteScalar(); // devuelve 1 o null
            cd_conexion.MtdCerrarConexion();

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}