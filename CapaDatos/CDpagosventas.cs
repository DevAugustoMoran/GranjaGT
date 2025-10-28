using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDpagosventas
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarPagosVentas()
        {
            string QueryConsultarPagosVentas = "Select * from tbl_PagosVentas";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarPagosVentas, cd_conexion.MtdAbrirConexion());
            DataTable dt_PagosVentas = new DataTable();
            dt_adapter.Fill(dt_PagosVentas);
            cd_conexion.MtdCerrarConexion();
            return dt_PagosVentas;
        }

        public void MtdAgregarPagosVentas(int CodigoVenta, decimal Monto, string TipoPago, string NumReferencia, DateTime FechaPago, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarPagosVentas = "Insert into tbl_PagosVentas(CodigoVenta, Monto, TipoPago, NumReferencia, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria) values (@CodigoVenta, @Monto, @TipoPago, @NumReferencia, @FechaPago, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarPagosVentas = new SqlCommand(QueryAgregarPagosVentas, cd_conexion.MtdAbrirConexion());
            CommandAgregarPagosVentas.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@Monto", Monto);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@TipoPago", TipoPago);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@NumReferencia", NumReferencia);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarPagosVentas.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarPagosVentas(int CodigoPago, int CodigoVenta, decimal Monto, string TipoPago, string NumReferencia, DateTime FechaPago, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarPagosVentas = "Update tbl_PagosVentass set CodigoVenta = @CodigoVenta, Monto = @Monto, TipoPago = @TipoPago, NumReferencia = @NumReferencia, FechaPago = @FechaPago, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoPago = @CodigoPago";
            SqlCommand CommandActualizarPagosVentas = new SqlCommand(QueryActualizarPagosVentas, cd_conexion.MtdAbrirConexion());
            CommandActualizarPagosVentas.Parameters.AddWithValue("@CodigoPago", CodigoPago);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@Monto", Monto);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@TipoPago", TipoPago);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@NumReferencia", NumReferencia);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarPagosVentas.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarPagosVentas(int CodigoPago)
        {
            string QueryEliminarPagosVentas = "Delete tbl_PagosVentas where CodigoPago = @CodigoPago";
            SqlCommand CommandEliminarPagosVentas = new SqlCommand(QueryEliminarPagosVentas, cd_conexion.MtdAbrirConexion());
            CommandEliminarPagosVentas.Parameters.AddWithValue("@CodigoPago", CodigoPago);
            CommandEliminarPagosVentas.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
