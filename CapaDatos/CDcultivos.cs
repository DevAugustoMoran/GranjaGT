using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDcultivos
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarCultivos()
        {
            string QueryConsultarCultivos = "Select * from tbl_Cultivos";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarCultivos, cd_conexion.MtdAbrirConexion());
            DataTable dt_Cultivos = new DataTable();
            sqlAdapter.Fill(dt_Cultivos);
            cd_conexion.MtdCerrarConexion();
            return dt_Cultivos;
        }

        public void MtdAgregarCultivo(string TipoCultivo, DateTime Fechasiembra, DateTime FechaCosecha, Decimal CantidadCosecha, Decimal Precio, string Ubicacion, string Observacion, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarCultivo = "Insert into tbl_Cultivos (TipoCultivo, Fechasiembra, FechaCosecha, CantidadCosecha, Precio, Ubicacion, Observacion, Estado, UsuarioAuditoria, FechaAuditoria) values (@TipoCultivo, @Fechasiembra, @FechaCosecha, @CantidadCosecha, @Precio, @Ubicacion, @Observacion, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarCultivo = new SqlCommand(QueryAgregarCultivo, cd_conexion.MtdAbrirConexion());
            CommandAgregarCultivo.Parameters.AddWithValue("@TipoCultivo", TipoCultivo);
            CommandAgregarCultivo.Parameters.AddWithValue("@Fechasiembra", Fechasiembra);
            CommandAgregarCultivo.Parameters.AddWithValue("@FechaCosecha", FechaCosecha);
            CommandAgregarCultivo.Parameters.AddWithValue("@CantidadCosecha", CantidadCosecha);
            CommandAgregarCultivo.Parameters.AddWithValue("@Precio", Precio);
            CommandAgregarCultivo.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            CommandAgregarCultivo.Parameters.AddWithValue("@Observacion", Observacion);
            CommandAgregarCultivo.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarCultivo.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarCultivo.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarCultivo.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarCultivo(int CodigoCultivo, string TipoCultivo, DateTime Fechasiembra, DateTime FechaCosecha, Decimal CantidadCosecha, Decimal Precio, string Ubicacion, string Observacion, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarCultivo = "Update tbl_Cultivos set TipoCultivo = @TipoCultivo, Fechasiembra = @Fechasiembra, FechaCosecha = @FechaCosecha, CantidadCosecha = @CantidadCosecha, Precio = @Precio, Ubicacion = @Ubicacion, Observacion = @Observacion, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoCultivo = @CodigoCultivo";
            SqlCommand CommandActualizarCultivo = new SqlCommand(QueryActualizarCultivo, cd_conexion.MtdAbrirConexion());
            CommandActualizarCultivo.Parameters.AddWithValue("@CodigoCultivo", CodigoCultivo);
            CommandActualizarCultivo.Parameters.AddWithValue("@TipoCultivo", TipoCultivo);
            CommandActualizarCultivo.Parameters.AddWithValue("@Fechasiembra", Fechasiembra);
            CommandActualizarCultivo.Parameters.AddWithValue("@FechaCosecha", FechaCosecha);
            CommandActualizarCultivo.Parameters.AddWithValue("@CantidadCosecha", CantidadCosecha);
            CommandActualizarCultivo.Parameters.AddWithValue("@Precio", Precio);
            CommandActualizarCultivo.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            CommandActualizarCultivo.Parameters.AddWithValue("@Observacion", Observacion);
            CommandActualizarCultivo.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarCultivo.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarCultivo.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarCultivo.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarCultivo(int CodigoCultivo)
        {
            string QueryEliminarCultivo = "Delete from tbl_Cultivos where CodigoCultivo = @CodigoCultivo";
            SqlCommand CommandEliminarCultivo = new SqlCommand(QueryEliminarCultivo, cd_conexion.MtdAbrirConexion());
            CommandEliminarCultivo.Parameters.AddWithValue("@CodigoCultivo", CodigoCultivo);
            CommandEliminarCultivo.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public bool MtdConsultarVentasDetalle(int CodigoCultivo)
        {
            string QueryConsultarVentasDetalle = "SELECT 1 FROM tbl_VentasDetalle WHERE CodigoCultivo = @CodigoCultivo";
            SqlCommand CommandEliminarCultivos = new SqlCommand(QueryConsultarVentasDetalle, cd_conexion.MtdAbrirConexion());
            CommandEliminarCultivos.Parameters.AddWithValue("@CodigoCultivo", CodigoCultivo);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarCultivos.ExecuteScalar(); // devuelve 1 o null
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
