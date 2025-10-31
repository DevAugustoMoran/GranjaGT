using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDproveedores
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarProveedores()
        {
            string QueryConsultarProveedores = "Select * from tbl_Proveedores";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarProveedores, cd_conexion.MtdAbrirConexion());
            DataTable dt_Proveedores = new DataTable();
            sqlAdapter.Fill(dt_Proveedores);
            cd_conexion.MtdCerrarConexion();
            return dt_Proveedores;
        }

        public void MtdAgregarProveedor(string Nombre,string Telefono,string Correo,string Direccion,string Estado,string UsuarioAuditoria,DateTime FechaAuditoria)
        {
            string QueryAgregarProveedor = "Insert into tbl_Proveedores(Nombre, Telefono, Correo, Direccion, Estado, UsuarioAuditoria, FechaAuditoria) values (@Nombre, @Telefono, @Correo, @Direccion, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarProveedor = new SqlCommand(QueryAgregarProveedor, cd_conexion.MtdAbrirConexion());
            CommandAgregarProveedor.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarProveedor.Parameters.AddWithValue("@Telefono", Telefono);
            CommandAgregarProveedor.Parameters.AddWithValue("@Correo", Correo);
            CommandAgregarProveedor.Parameters.AddWithValue("@Direccion", Direccion);
            CommandAgregarProveedor.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarProveedor.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarProveedor.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarProveedor.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarProveedor(int CodigoProveedor, string Nombre, string Telefono, string Correo, string Direccion, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarProveedor = "Update tbl_Proveedores set Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoProveedor = @CodigoProveedor";
            SqlCommand CommandActualizarProveedor = new SqlCommand(QueryActualizarProveedor, cd_conexion.MtdAbrirConexion());
            CommandActualizarProveedor.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            CommandActualizarProveedor.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarProveedor.Parameters.AddWithValue("@Telefono", Telefono);
            CommandActualizarProveedor.Parameters.AddWithValue("@Correo", Correo);
            CommandActualizarProveedor.Parameters.AddWithValue("@Direccion", Direccion);
            CommandActualizarProveedor.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarProveedor.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarProveedor.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarProveedor.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarProveedor(int CodigoProveedor)
        {
            string QueryEliminarProveedor = "Delete from tbl_Proveedores where CodigoProveedor = @CodigoProveedor";
            SqlCommand CommandEliminarProveedor = new SqlCommand(QueryEliminarProveedor, cd_conexion.MtdAbrirConexion());
            CommandEliminarProveedor.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            CommandEliminarProveedor.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public bool MtdConsultarInsumos(int CodigoProveedor)
        {
            string QueryConsultarProveedor = "SELECT 1 FROM tbl_Insumos WHERE CodigoProveedor = @CodigoProveedor";
            SqlCommand CommandEliminarProveedor = new SqlCommand(QueryConsultarProveedor, cd_conexion.MtdAbrirConexion());
            CommandEliminarProveedor.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarProveedor.ExecuteScalar(); // devuelve 1 o null
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
