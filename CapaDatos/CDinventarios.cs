using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDinventarios
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarInventario()
        {
            string QueryConsultarInventario = "Select * from tbl_Inventarios";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarInventario, cd_conexion.MtdAbrirConexion());
            DataTable dt_inventario = new DataTable();
            dt_adapter.Fill(dt_inventario);
            cd_conexion.MtdCerrarConexion();
            return dt_inventario;
        }

        public void MtdAgregarInventario(int CodigoGranja, int CodigoInsumo, decimal CantidadDisponible, decimal CostoUnitario, decimal CostoTotal, DateTime FechaRegistro, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarInventario = "Insert into tbl_Inventarios(CodigoGranja, CodigoInsumo, CantidadDisponible, CostoUnitario, CostoTotal, FechaRegistro, Estado, UsuarioAuditoria, FechaAuditoria) values (@CodigoGranja, @CodigoInsumo, @CantidadDisponible, @CostoUnitario, @CostoTotal, @FechaRegistro, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarInventario = new SqlCommand(QueryAgregarInventario, cd_conexion.MtdAbrirConexion());
            CommandAgregarInventario.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandAgregarInventario.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);
            CommandAgregarInventario.Parameters.AddWithValue("@CantidadDisponible", CantidadDisponible);
            CommandAgregarInventario.Parameters.AddWithValue("@CostoUnitario", CostoUnitario);
            CommandAgregarInventario.Parameters.AddWithValue("@CostoTotal", CostoTotal);
            CommandAgregarInventario.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            CommandAgregarInventario.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarInventario.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarInventario.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarInventario.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarInventario(int CodigoInventario, int CodigoGranja, int CodigoInsumo, decimal CantidadDisponible, decimal CostoUnitario, decimal CostoTotal, DateTime FechaRegistro, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarInventario = "Update tbl_Inventarios set CodigoGranja = @CodigoGranja, CodigoInsumo = @CodigoInsumo, CantidadDisponible = @CantidadDisponible, CostoUnitario = @CostoUnitario, CostoTotal = @CostoTotal, FechaRegistro = @FechaRegistro, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoInventario = @CodigoInventario";
            SqlCommand CommandActualizarInventario = new SqlCommand(QueryActualizarInventario, cd_conexion.MtdAbrirConexion());
            CommandActualizarInventario.Parameters.AddWithValue("@CodigoInventario", CodigoInventario);
            CommandActualizarInventario.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandActualizarInventario.Parameters.AddWithValue("@CodigoInsumo", CodigoInsumo);
            CommandActualizarInventario.Parameters.AddWithValue("@CantidadDisponible", CantidadDisponible);
            CommandActualizarInventario.Parameters.AddWithValue("@CostoUnitario", CostoUnitario);
            CommandActualizarInventario.Parameters.AddWithValue("@CostoTotal", CostoTotal);
            CommandActualizarInventario.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            CommandActualizarInventario.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarInventario.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarInventario.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarInventario.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarInventario(int CodigoInventario)
        {
            string QueryEliminarInventario = "Delete tbl_Inventarios where CodigoInventario = @CodigoInventario";
            SqlCommand CommandEliminarInventario = new SqlCommand(QueryEliminarInventario, cd_conexion.MtdAbrirConexion());
            CommandEliminarInventario.Parameters.AddWithValue("@CodigoInventario", CodigoInventario);
            CommandEliminarInventario.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
