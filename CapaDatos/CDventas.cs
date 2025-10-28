using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDventas
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarVenta()
        {
            string QueryConsultarVenta = "Select * from tbl_Ventas";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarVenta, cd_conexion.MtdAbrirConexion());
            DataTable dt_Venta = new DataTable();
            dt_adapter.Fill(dt_Venta);
            cd_conexion.MtdCerrarConexion();
            return dt_Venta;
        }

        public void MtdAgregarVenta(int CodigoCliente, int CodigoGranja, DateTime FechaVenta, string TipoVenta, decimal TotalVenta, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarVenta = "Insert into tbl_Ventas(CodigoCliente, CodigoGranja, FechaVenta, TipoVenta, TotalVenta, Estado, UsuarioAuditoria, FechaAuditoria) values (@CodigoCliente, @CodigoGranja, @FechaVenta, @TipoVenta, @TotalVenta, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarVenta = new SqlCommand(QueryAgregarVenta, cd_conexion.MtdAbrirConexion());
            CommandAgregarVenta.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommandAgregarVenta.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandAgregarVenta.Parameters.AddWithValue("@FechaVenta", FechaVenta);
            CommandAgregarVenta.Parameters.AddWithValue("@TipoVenta", TipoVenta);
            CommandAgregarVenta.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            CommandAgregarVenta.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarVenta.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarVenta.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarVenta.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarVenta(int CodigoVenta, int CodigoCliente, int CodigoGranja, DateTime FechaVenta, string TipoVenta, decimal TotalVenta, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarVenta = "Update tbl_Ventas set CodigoCliente = @CodigoCliente, CodigoGranja = @CodigoGranja, FechaVenta = @FechaVenta, TipoVenta = @TipoVenta, TotalVenta = @TotalVenta, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoVenta = @CodigoVenta";
            SqlCommand CommandActualizarVenta = new SqlCommand(QueryActualizarVenta, cd_conexion.MtdAbrirConexion());
            CommandActualizarVenta.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandActualizarVenta.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            CommandActualizarVenta.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandActualizarVenta.Parameters.AddWithValue("@FechaVenta", FechaVenta);
            CommandActualizarVenta.Parameters.AddWithValue("@TipoVenta", TipoVenta);
            CommandActualizarVenta.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            CommandActualizarVenta.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarVenta.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarVenta.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarVenta.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarVenta(int CodigoVenta)
        {
            string QueryEliminarVenta = "Delete tbl_Ventas where CodigoVenta = @CodigoVenta";
            SqlCommand CommandEliminarVenta = new SqlCommand(QueryEliminarVenta, cd_conexion.MtdAbrirConexion());
            CommandEliminarVenta.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandEliminarVenta.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
