using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDclientes
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarClientes()
        {
            string QueryConsultarClientes = "Select * from tbl_Clientes";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarClientes, cd_conexion.MtdAbrirConexion());
            DataTable dt_Clientes = new DataTable();
            sqlAdapter.Fill(dt_Clientes);
            cd_conexion.MtdCerrarConexion();
            return dt_Clientes;
        }

        public void MtdAgregarCliente( string Nombre, string Tipo, string Telefono, string Correo, string Direccion, string Estado, string UsuarioAuditoria, string FechaAuditoria)
        {
            string QueryAgregarCliente = "Insert into tbl_Clientes(Nombre, Tipo, Telefono, Correo, Direccion, Estado, UsuarioAuditoria, FechaAuditoria) values (@Nombre, @Tipo, @Telefono, @Correo, @Direccion, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarCliente = new SqlCommand(QueryAgregarCliente, cd_conexion.MtdAbrirConexion());
            CommandAgregarCliente.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarCliente.Parameters.AddWithValue("@Tipo", Tipo);
            CommandAgregarCliente.Parameters.AddWithValue("@Telefono", Telefono);
            CommandAgregarCliente.Parameters.AddWithValue("@Correo", Correo);
            CommandAgregarCliente.Parameters.AddWithValue("@Direccion", Direccion);
            CommandAgregarCliente.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarCliente.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarCliente.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarCliente.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarCliente(int CodigoCliente, string Nombre, string Tipo, string Telefono, string Correo, string Direccion, string Estado, string UsuarioAuditoria, string FechaAuditoria)
        {
            string QueryActualizarCliente = "Update tbl_Clientes set Nombre = @Nombre, Tipo = @Tipo, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoCliente = @CodigoCliente";
            SqlCommand CommandActualizarCliente = new SqlCommand(QueryActualizarCliente, cd_conexion.MtdAbrirConexion());
            CommandActualizarCliente.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommandActualizarCliente.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarCliente.Parameters.AddWithValue("@Tipo", Tipo);
            CommandActualizarCliente.Parameters.AddWithValue("@Telefono", Telefono);
            CommandActualizarCliente.Parameters.AddWithValue("@Correo", Correo);
            CommandActualizarCliente.Parameters.AddWithValue("@Direccion", Direccion);
            CommandActualizarCliente.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarCliente.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarCliente.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarCliente.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarCliente(int CodigoCliente)
        {
            string QueryEliminarCliente = "Delete from tbl_Clientes where CodigoCliente = @CodigoCliente";
            SqlCommand CommandEliminarCliente = new SqlCommand(QueryEliminarCliente, cd_conexion.MtdAbrirConexion());
            CommandEliminarCliente.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommandEliminarCliente.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

    }
}
