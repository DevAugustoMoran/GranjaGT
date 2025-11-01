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

        //LLAVE FORANEA
        public List<dynamic> MtdListarDetallesVentas()
        {
            List<dynamic> ListaVentas = new List<dynamic>();
            string QueryListaVentas = "Select CodigoDetalle, Estado from tbl_VentasDetalle";
            SqlCommand cmd = new SqlCommand(QueryListaVentas, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaVentas.Add(new
                {
                    Value = reader["CodigoDetalle"],
                    Text = $"{reader["CodigoDetalle"]} - {reader["Estado"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaVentas;
        }

        public DataTable MtdConsultarPagosVentas()
        {
            string QueryConsultarPagosVentas = "Select * from tbl_PagosVentas";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarPagosVentas, cd_conexion.MtdAbrirConexion());
            DataTable dt_PagosVentas = new DataTable();
            dt_adapter.Fill(dt_PagosVentas);
            cd_conexion.MtdCerrarConexion();
            return dt_PagosVentas;
        }

        public void MtdAgregarPagosVentas(decimal Monto, string TipoPago, string NumReferencia, DateTime FechaPago, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria, int CodigoDetalle)
        {
            string QueryAgregarPagosVentas = "Insert into tbl_PagosVentas(Monto, TipoPago, NumReferencia, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria, CodigoDetalle) values (@Monto, @TipoPago, @NumReferencia, @FechaPago, @Estado, @UsuarioAuditoria, @FechaAuditoria, @CodigoDetalle)";
            SqlCommand CommandAgregarPagosVentas = new SqlCommand(QueryAgregarPagosVentas, cd_conexion.MtdAbrirConexion());
            CommandAgregarPagosVentas.Parameters.AddWithValue("@Monto", Monto);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@TipoPago", TipoPago);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@NumReferencia", NumReferencia);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarPagosVentas.Parameters.AddWithValue("@CodigoDetalle", CodigoDetalle);
            CommandAgregarPagosVentas.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarPagosVentas(int CodigoPago, decimal Monto, string TipoPago, string NumReferencia, DateTime FechaPago, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria, int CodigoDetalle)
        {
            string QueryActualizarPagosVentas = "Update tbl_PagosVentas set Monto = @Monto, TipoPago = @TipoPago, NumReferencia = @NumReferencia, FechaPago = @FechaPago, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria, CodigoDetalle = @CodigoDetalle where CodigoPago = @CodigoPago";
            SqlCommand CommandActualizarPagosVentas = new SqlCommand(QueryActualizarPagosVentas, cd_conexion.MtdAbrirConexion());
            CommandActualizarPagosVentas.Parameters.AddWithValue("@CodigoPago", CodigoPago);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@Monto", Monto);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@TipoPago", TipoPago);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@NumReferencia", NumReferencia);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarPagosVentas.Parameters.AddWithValue("@CodigoVenta", CodigoDetalle);
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

        public Decimal MtdMonto(int CodigoDetalle)
        {
            decimal montototal = 0;

            string QueryConsultarMonto = "SELECT TotalVenta FROM tbl_VentasDetalle WHERE CodigoDetalle = @CodigoDetalle";
            SqlCommand CommandMonto = new SqlCommand(QueryConsultarMonto, cd_conexion.MtdAbrirConexion());
            CommandMonto.Parameters.AddWithValue("@CodigoDetalle", CodigoDetalle);
            SqlDataReader reader = CommandMonto.ExecuteReader();

            if (reader.Read())
            {
                montototal = decimal.Parse(reader["TotalVenta"].ToString());
            }
            else
            {
                montototal = 0;
            }

            cd_conexion.MtdCerrarConexion();
            return montototal;
        }
    }
}