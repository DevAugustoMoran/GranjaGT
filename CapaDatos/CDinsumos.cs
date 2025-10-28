using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDinsumos
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarInsumos()
        {
            string QueryConsultarInsumos = "Select * from tbl_Insumos";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarInsumos, cd_conexion.MtdAbrirConexion());
            DataTable dt_insumos = new DataTable();
            dt_adapter.Fill(dt_insumos);
            cd_conexion.MtdCerrarConexion();
            return dt_insumos;
        }

        public void MtdAgregarInsumos(int CodigoProveedor, string Nombre, string TipoInsumo, decimal CostoUnitario, string UnidadMedida, decimal Peso, string Observacion, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarInsumos = "Insert into tbl_Insumos(CodigoProveedor, Nombre, TipoInsumo, CostoUnitario, UnidadMedida, Peso, Observacion, Estado, UsuarioAuditoria, FechaAuditoria) values (@CodigoProveedor, @Nombre, @TipoInsumo, @CostoUnitario, @UnidadMedida, @Peso, @Observacion, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarInsumos = new SqlCommand(QueryAgregarInsumos, cd_conexion.MtdAbrirConexion());
            CommandAgregarInsumos.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            CommandAgregarInsumos.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarInsumos.Parameters.AddWithValue("@TipoInsumo", TipoInsumo);
            CommandAgregarInsumos.Parameters.AddWithValue("@CostoUnitario", CostoUnitario);
            CommandAgregarInsumos.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);
            CommandAgregarInsumos.Parameters.AddWithValue("@Peso", Peso);
            CommandAgregarInsumos.Parameters.AddWithValue("@Observacion", Observacion);
            CommandAgregarInsumos.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarInsumos.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarInsumos.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarInsumos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarInsumos(int CodigoInsumo, int CodigoProveedor, string Nombre, string TipoInsumo, decimal CostoUnitario, string UnidadMedida, decimal Peso, string Observacion, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarInsumos = "Update tbl_Insumos set CodigoProveedor = @CodigoProveedor, Nombre = @Nombre, TipoInsumo = @TipoInsumo, CostoUnitario = @CostoUnitario, UnidadMedida = @UnidadMedida, Peso = @Peso, Observacion = @Observacion, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoInsumo = @CodigoInsumo";
            SqlCommand CommandActualizarInsumos = new SqlCommand(QueryActualizarInsumos, cd_conexion.MtdAbrirConexion());
            CommandActualizarInsumos.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);
            CommandActualizarInsumos.Parameters.AddWithValue("@CodigoProveedor", CodigoProveedor);
            CommandActualizarInsumos.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarInsumos.Parameters.AddWithValue("@TipoInsumo", TipoInsumo);
            CommandActualizarInsumos.Parameters.AddWithValue("@CostoUnitario", CostoUnitario);
            CommandActualizarInsumos.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);
            CommandActualizarInsumos.Parameters.AddWithValue("@Peso", Peso);
            CommandActualizarInsumos.Parameters.AddWithValue("@Observacion", Observacion);
            CommandActualizarInsumos.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarInsumos.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarInsumos.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarInsumos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarInsumos(int CodigoInsumo)
        {
            string QueryEliminarInsumos = "Delete tbl_Insumos where CodigoInsumo = @CodigoInsumo";
            SqlCommand CommandEliminarInsumos = new SqlCommand(QueryEliminarInsumos, cd_conexion.MtdAbrirConexion());
            CommandEliminarInsumos.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);
            CommandEliminarInsumos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
