using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDenvios
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarEnvios()
        {
            string QueryConsultarEnvios = "Select * from tbl_Envios";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarEnvios, cd_conexion.MtdAbrirConexion());
            DataTable dt_envios = new DataTable();
            dt_adapter.Fill(dt_envios);
            cd_conexion.MtdCerrarConexion();
            return dt_envios;
        }

        public void MtdAgregarEnvios(int CodigoVenta, int CodigoEmpleado, DateTime FechaEnvio, string DireccionEnvio, string TipoTransporte, string PlacaTransporte, string Observacion, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarEnvios = "Insert into tbl_Envios(CodigoVenta, CodigoEmpleado, FechaEnvio, DireccionEnvio, TipoTransporte, PlacaTransporte, Observacion, Estado, UsuarioAuditoria, FechaAuditoria) values (@CodigoVenta, @CodigoEmpleado, @FechaEnvio, @DireccionEnvio, @TipoTransporte, @PlacaTransporte, @Observacion, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarEnvios = new SqlCommand(QueryAgregarEnvios, cd_conexion.MtdAbrirConexion());
            CommandAgregarEnvios.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandAgregarEnvios.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandAgregarEnvios.Parameters.AddWithValue("@FechaEnvio", FechaEnvio);
            CommandAgregarEnvios.Parameters.AddWithValue("@DireccionEnvio", DireccionEnvio);
            CommandAgregarEnvios.Parameters.AddWithValue("@TipoTransporte", TipoTransporte);
            CommandAgregarEnvios.Parameters.AddWithValue("@PlacaTransporte", PlacaTransporte);
            CommandAgregarEnvios.Parameters.AddWithValue("@Observacion", Observacion);
            CommandAgregarEnvios.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarEnvios.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarEnvios.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarEnvios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarEnvios(int CodigoEnvios, int CodigoVenta, int CodigoEmpleado, DateTime FechaEnvio, string DireccionEnvio, string TipoTransporte, string PlacaTransporte, string Observacion, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarEnvios = "Update tbl_Envios set CodigoVenta = @CodigoVenta, CodigoEmpleado = @CodigoEmpleado, FechaEnvio = @FechaEnvio, DireccionEnvio = @DireccionEnvio, TipoTransporte = @TipoTransporte, PlacaTransporte = @PlacaTransporte, Observacion = @Observacion, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoEnvios = @CodigoEnvios";
            SqlCommand CommandActualizarEnvios = new SqlCommand(QueryActualizarEnvios, cd_conexion.MtdAbrirConexion());
            CommandActualizarEnvios.Parameters.AddWithValue("@CodigoEnvios", CodigoEnvios);
            CommandActualizarEnvios.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);
            CommandActualizarEnvios.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandActualizarEnvios.Parameters.AddWithValue("@FechaEnvio", FechaEnvio);
            CommandActualizarEnvios.Parameters.AddWithValue("@DireccionEnvio", DireccionEnvio);
            CommandActualizarEnvios.Parameters.AddWithValue("@TipoTransporte", TipoTransporte);
            CommandActualizarEnvios.Parameters.AddWithValue("@PlacaTransporte", PlacaTransporte);
            CommandActualizarEnvios.Parameters.AddWithValue("@Observacion", Observacion);
            CommandActualizarEnvios.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarEnvios.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarEnvios.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarEnvios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarEnvios(int CodigoEnvios)
        {
            string QueryEliminarEnvios = "Delete tbl_Envios where CodigoEnvios = @CodigoEnvios";
            SqlCommand CommandEliminarEnvios = new SqlCommand(QueryEliminarEnvios, cd_conexion.MtdAbrirConexion());
            CommandEliminarEnvios.Parameters.AddWithValue("@CodigoEnvios", CodigoEnvios);
            CommandEliminarEnvios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
