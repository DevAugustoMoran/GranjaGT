using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDventasDetalle
    {
        CDconexion cd_conexion = new CDconexion();

        public List<dynamic> MtdListarVentas()
        {
            List<dynamic> ListaVentas = new List<dynamic>();
            string QueryListaVentas = "Select CodigoVenta, TipoVenta from tbl_Ventas";
            SqlCommand cmd = new SqlCommand(QueryListaVentas, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaVentas.Add(new
                {
                    Value = reader["CodigoVenta"],
                    Text = $"{reader["CodigoVenta"]} - {reader["TipoVenta"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaVentas;
        }

        public List<dynamic> MtdListarAnimal()
        {
            List<dynamic> ListaAnimal = new List<dynamic>();
            string QueryListaAnimal = "Select CodigoAnimal, TipoAnimal from tbl_Animales";
            SqlCommand cmd = new SqlCommand(QueryListaAnimal, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaAnimal.Add(new
                {
                    Value = reader["CodigoAnimal"],
                    Text = $"{reader["CodigoAnimal"]} - {reader["TipoAnimal"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaAnimal;
        }

        public List<dynamic> MtdListarCultivo()
        {
            List<dynamic> ListaCultivo = new List<dynamic>();
            string QueryListaCultivo = "Select CodigoCultivo, TipoCultivo from tbl_Cultivos";
            SqlCommand cmd = new SqlCommand(QueryListaCultivo, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaCultivo.Add(new
                {
                    Value = reader["CodigoCultivo"],
                    Text = $"{reader["CodigoCultivo"]} - {reader["TipoCultivo"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaCultivo;
        }

        public List<dynamic> MtdListarProducto()
        {
            List<dynamic> ListaProducto = new List<dynamic>();
            string QueryListaProducto = "Select CodigoProducto, Nombre from tbl_Productos";
            SqlCommand cmd = new SqlCommand(QueryListaProducto, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaProducto.Add(new
                {
                    Value = reader["CodigoProducto"],
                    Text = $"{reader["CodigoProducto"]} - {reader["Nombre"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaProducto;
        }

        public DataTable MtdConsultarVentasDetalle()
        {
            string QueryConsultarVentasDetalle = "Select * from tbl_VentasDetalle";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarVentasDetalle, cd_conexion.MtdAbrirConexion());
            DataTable dt_ventasdetalle = new DataTable();
            dt_adapter.Fill(dt_ventasdetalle);
            cd_conexion.MtdCerrarConexion();
            return dt_ventasdetalle;
        }

        public void MtdAgregarVentasDetalle(int CodigoVenta, int CodigoAnimal, int CodigoCultivo, int CodigoProducto, decimal Cantidad, decimal PrecioUnitario, decimal Total, decimal Descuento, decimal Impuesto, decimal TotalVenta, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarVentasDetalle = "Insert into tbl_VentasDetalle(CodigoVenta, CodigoAnimal, CodigoCultivo, CodigoProducto, Cantidad, PrecioUnitario, Total, Descuento, Impuesto, TotalVenta, Estado, UsuarioAuditoria, FechaAuditoria) values (@CodigoVenta, @CodigoAnimal, @CodigoCultivo, @CodigoProducto, @Cantidad, @PrecioUnitario, @Total, @Descuento, @Impuesto, @TotalVenta, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarVentasDetalle = new SqlCommand(QueryAgregarVentasDetalle, cd_conexion.MtdAbrirConexion());
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@CodigoAnimal", (CodigoAnimal == 0) ? (object)DBNull.Value : CodigoAnimal);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@CodigoCultivo", (CodigoCultivo == 0) ? (object)DBNull.Value : CodigoCultivo);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@CodigoProducto", (CodigoProducto == 0) ? (object)DBNull.Value : CodigoProducto);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@Cantidad", Cantidad);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@PrecioUnitario", PrecioUnitario);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@Total", Total);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@Descuento", Descuento);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@Impuesto", Impuesto);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarVentasDetalle.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarVentasDetalle.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarVentasDetalle(int CodigoDetalle, int CodigoVenta, int CodigoAnimal, int CodigoCultivo, int CodigoProducto, decimal Cantidad, decimal PrecioUnitario, decimal Total, decimal Descuento, decimal Impuesto, decimal TotalVenta, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarVentasDetalle = "Update tbl_VentasDetalle set CodigoVenta = @CodigoVenta, CodigoAnimal = @CodigoAnimal, CodigoCultivo = @CodigoCultivo, CodigoProducto = @CodigoProducto, Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario, Total = @Total, Descuento = @Descuento, Impuesto = @Impuesto, TotalVenta = @TotalVenta, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoDetalle = @CodigoDetalle";
            SqlCommand CommandActualizarVentasDetalle = new SqlCommand(QueryActualizarVentasDetalle, cd_conexion.MtdAbrirConexion());
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@CodigoDetalle", CodigoDetalle);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@CodigoAnimal", (CodigoAnimal == 0) ? (object)DBNull.Value : CodigoAnimal);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@CodigoCultivo", (CodigoCultivo == 0) ? (object)DBNull.Value : CodigoCultivo);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@CodigoProducto", (CodigoProducto == 0) ? (object)DBNull.Value : CodigoProducto);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@Cantidad", Cantidad);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@PrecioUnitario", PrecioUnitario);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@Total", Total);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@Descuento", Descuento);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@Impuesto", Impuesto);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@TotalVenta", TotalVenta);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarVentasDetalle.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarVentasDetalle.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarVentasDetalle(int CodigoDetalle)
        {
            string QueryEliminarVentasDetalle = "Delete tbl_VentasDetalle where CodigoDetalle = @CodigoDetalle";
            SqlCommand CommandEliminarVentasDetalle = new SqlCommand(QueryEliminarVentasDetalle, cd_conexion.MtdAbrirConexion());
            CommandEliminarVentasDetalle.Parameters.AddWithValue("@CodigoDetalle", CodigoDetalle);
            CommandEliminarVentasDetalle.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public bool MtdConsultarPagosVentas(int CodigoDetalle)
        {
            string QueryConsultarPagosVentas = "SELECT 1 FROM tbl_PagosVentas WHERE CodigoDetalle = @CodigoDetalle";
            SqlCommand CommandEliminarVentaDetalle = new SqlCommand(QueryConsultarPagosVentas, cd_conexion.MtdAbrirConexion());
            CommandEliminarVentaDetalle.Parameters.AddWithValue("@CodigoDetalle", CodigoDetalle);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarVentaDetalle.ExecuteScalar(); // devuelve 1 o null
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
