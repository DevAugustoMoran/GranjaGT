using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDroles
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarRol()
        {
            string QueryConsultarRol = "Select * from tbl_Roles";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarRol, cd_conexion.MtdAbrirConexion());
            DataTable dt_Rol = new DataTable();
            sqlAdapter.Fill(dt_Rol);

            cd_conexion.MtdCerrarConexion();
            return dt_Rol;
        }

        public void MtdAgregarRol(string NombreRol, string Estado, string UsuarioAuditoria, int NivelAcceso, string Descripcion, DateTime FechaAuditoria, DateTime FechaCreación)
        {
            string QueryAgregarRol = "Insert into tbl_Roles(NombreRol, Estado, UsuarioAuditoria, NivelAcceso, Descripcion, FechaAuditoria, FechaCreación) values (@NombreRol, @Estado, @UsuarioAuditoria, @NivelAcceso, @Descripcion, @FechaAuditoria, @FechaCreación)";
            SqlCommand CommandAgregarRol = new SqlCommand(QueryAgregarRol, cd_conexion.MtdAbrirConexion());
            CommandAgregarRol.Parameters.AddWithValue("@NombreRol", NombreRol);
            CommandAgregarRol.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarRol.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarRol.Parameters.AddWithValue("NivelAcceso", NivelAcceso);
            CommandAgregarRol.Parameters.AddWithValue("@Descripcion", Descripcion);
            CommandAgregarRol.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarRol.Parameters.AddWithValue("@FechaCreación", FechaCreación);
            CommandAgregarRol.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        
        public void MtdActualizarRol(int CodigoRol, string NombreRol, string Estado, string UsuarioAuditoria, int NivelAcceso, string Descripcion, DateTime FechaAuditoria, DateTime FechaCreación)
        {
            string QueryActualizarRol = "Update tbl_Roles set NombreRol = @NombreRol, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, NivelAcceso = @NivelAcceso, Descripcion = @Descripcion, FechaAuditoria = @FechaAuditoria, FechaCreación = @FechaCreación where CodigoRol = @CodigoRol";
            SqlCommand CommandActualizarRol = new SqlCommand(QueryActualizarRol, cd_conexion.MtdAbrirConexion());
            CommandActualizarRol.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandActualizarRol.Parameters.AddWithValue("@NombreRol", NombreRol);
            CommandActualizarRol.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarRol.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarRol.Parameters.AddWithValue("NivelAcceso", NivelAcceso);
            CommandActualizarRol.Parameters.AddWithValue("@Descripcion", Descripcion);
            CommandActualizarRol.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarRol.Parameters.AddWithValue("@FechaCreación", FechaCreación);
            CommandActualizarRol.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarRol(int CodigoRol)
        {
            string QueryEliminarRol = "Delete from tbl_Roles where CodigoRol = @CodigoRol";
            SqlCommand CommandEliminarRol = new SqlCommand(QueryEliminarRol, cd_conexion.MtdAbrirConexion());
            CommandEliminarRol.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            CommandEliminarRol.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public bool MtdConsultarUsuarios(int CodigoRol)
        {
            string QueryConsultarUsuarios = "SELECT 1 FROM tbl_Usuarios WHERE CodigoRol = @CodigoRol";
            SqlCommand CommandEliminarRol = new SqlCommand(QueryConsultarUsuarios, cd_conexion.MtdAbrirConexion());
            CommandEliminarRol.Parameters.AddWithValue("@CodigoRol", CodigoRol);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarRol.ExecuteScalar(); // devuelve 1 o null
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
