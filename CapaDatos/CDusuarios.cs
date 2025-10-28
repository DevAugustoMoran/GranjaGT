using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDusuarios
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarUsuario()
        {
            string QueryConsultarUsuario = "Select * from tbl_Usuarios";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarUsuario, cd_conexion.MtdAbrirConexion());
            DataTable dt_usuario = new DataTable();
            dt_adapter.Fill(dt_usuario);
            cd_conexion.MtdCerrarConexion();
            return dt_usuario;
        }

        public void MtdAgregarUsuario(int CodigoRol, string Nombre, string Estado, string UsuarioSistema, DateTime FechaAuditoria, DateTime FechaRegistro)
        {
            string QueryAgregarUsuario = "Insert into tbl_Usuarios(CodigoRol, Nombre, Estado, UsuarioAuditoria, FechaAuditoria, FechaRegistro) values (@CodigoRol, @Nombre, @Estado, @UsuarioAuditoria, @FechaAuditoria, @FechaRegistro)";
            SqlCommand CommandAgregarUsuario = new SqlCommand(QueryAgregarUsuario, cd_conexion.MtdAbrirConexion());
            CommandAgregarUsuario.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandAgregarUsuario.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarUsuario.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarUsuario.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioSistema);
            CommandAgregarUsuario.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarUsuario.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            CommandAgregarUsuario.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarUsuario(int CodigoUsuario, int CodigoRol, string Nombre, string Estado, string UsuarioSistema, DateTime FechaAuditoria, DateTime FechaRegistro)
        {
            string QueryActualizarUsuario = "Update tbl_Usuarios set CodigoRol= @CodigoRol, Nombre = @Nombre, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria, FechaRegistro = @FechaRegistro where CodigoUsuario = @CodigoUsuario";
            SqlCommand CommandActualizarUsuario = new SqlCommand(QueryActualizarUsuario, cd_conexion.MtdAbrirConexion());
            CommandActualizarUsuario.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            CommandActualizarUsuario.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandActualizarUsuario.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarUsuario.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarUsuario.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioSistema);
            CommandActualizarUsuario.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarUsuario.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
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

    }
}
