using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CapaDatos
{
    public class CDproductos
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarProductos()
        {
            string QueryConsultarProductos = "Select * from tbl_Productos";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarProductos, cd_conexion.MtdAbrirConexion());
            DataTable dt_Productos = new DataTable();
            sqlAdapter.Fill(dt_Productos);
            cd_conexion.MtdCerrarConexion();
            return dt_Productos;
        }

        public void MtdAgregarProducto(string Nombre, string TipoProducto, Decimal Precio, int Stock, DateTime FechaIngreso, DateTime FechaVencimiento, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarProducto = "Insert into tbl_Productos (Nombre, TipoProducto, Precio, Stock, FechaIngreso, FechaVencimiento, Estado, UsuarioAuditoria, FechaAuditoria) values (@Nombre, @TipoProducto, @Precio, @Stock, @FechaIngreso, @FechaVencimiento, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarProducto = new SqlCommand(QueryAgregarProducto, cd_conexion.MtdAbrirConexion());
            CommandAgregarProducto.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarProducto.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            CommandAgregarProducto.Parameters.AddWithValue("@Precio", Precio);
            CommandAgregarProducto.Parameters.AddWithValue("@Stock", Stock);
            CommandAgregarProducto.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            CommandAgregarProducto.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            CommandAgregarProducto.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarProducto.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarProducto.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarProducto.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarProducto(int CodigoProducto, string Nombre, string TipoProducto, Decimal Precio, int Stock, DateTime FechaIngreso, DateTime FechaVencimiento, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarProducto = "Update tbl_Productos set Nombre = @Nombre, TipoProducto = @TipoProducto, Precio = @Precio, Stock = @Stock, FechaIngreso = @FechaIngreso, FechaVencimiento = @FechaVencimiento, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoProducto = @CodigoProducto";
            SqlCommand CommandActualizarProducto = new SqlCommand(QueryActualizarProducto, cd_conexion.MtdAbrirConexion());
            CommandActualizarProducto.Parameters.AddWithValue("@CodigoProducto", CodigoProducto);
            CommandActualizarProducto.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarProducto.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            CommandActualizarProducto.Parameters.AddWithValue("@Precio", Precio);
            CommandActualizarProducto.Parameters.AddWithValue("@Stock", Stock);
            CommandActualizarProducto.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            CommandActualizarProducto.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            CommandActualizarProducto.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarProducto.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarProducto.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarProducto.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarProducto(int CodigoProducto)
        {
            string QueryEliminarProducto = "Delete from tbl_Productos where CodigoProducto = @CodigoProducto";
            SqlCommand CommandEliminarProducto = new SqlCommand(QueryEliminarProducto, cd_conexion.MtdAbrirConexion());
            CommandEliminarProducto.Parameters.AddWithValue("@CodigoProducto", CodigoProducto);
            CommandEliminarProducto.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
