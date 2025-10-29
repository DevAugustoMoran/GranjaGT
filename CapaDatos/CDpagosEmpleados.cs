using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDpagosEmpleados
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarPagosEmpleados()
        {
            string QueryConsultarPagosEmpleados = "Select * from tbl_Pagos_Empleados";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarPagosEmpleados, cd_conexion.MtdAbrirConexion());
            DataTable dt_PagosEmpleados = new DataTable();
            sqlAdapter.Fill(dt_PagosEmpleados);
            cd_conexion.MtdCerrarConexion();
            return dt_PagosEmpleados;
        }


        public void MtdAgregarPagoEmpleado(Decimal Salario, Decimal HorasExtras, Decimal Bonos, Decimal Descuentos, Decimal SalarioFinal, DateTime FechaPago, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarPagoEmpleado = "Insert into tbl_Pagos_Empleados(Salario, HorasExtras, Bonos, Descuentos, SalarioFinal, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria) values (@Salario, @HorasExtras, @Bonos, @Descuentos, @SalarioFinal, @FechaPago, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarPagoEmpleado = new SqlCommand(QueryAgregarPagoEmpleado, cd_conexion.MtdAbrirConexion());
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@Salario", Salario);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@HorasExtras", HorasExtras);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@Bonos", Bonos);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@Descuentos", Descuentos);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@SalarioFinal", SalarioFinal);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarPagoEmpleado.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarPagoEmpleado.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }


        public void MtdActualizarPagoEmpleado(int CodigoPagoEmpleado, Decimal Salario, Decimal HorasExtras, Decimal Bonos, Decimal Descuentos, Decimal SalarioFinal, DateTime FechaPago, string Estado, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarPagoEmpleado = "Update tbl_Pagos_Empleados set Salario = @Salario, HorasExtras = @HorasExtras, Bonos = @Bonos, Descuentos = @Descuentos, SalarioFinal = @SalarioFinal, FechaPago = @FechaPago, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoPagoEmpleado = @CodigoPagoEmpleado";
            SqlCommand CommandActualizarPagoEmpleado = new SqlCommand(QueryActualizarPagoEmpleado, cd_conexion.MtdAbrirConexion());
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@CodigoPagoEmpleado", CodigoPagoEmpleado);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@Salario", Salario);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@HorasExtras", HorasExtras);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@Bonos", Bonos);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@Descuentos", Descuentos);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@SalarioFinal", SalarioFinal);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarPagoEmpleado.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarPagoEmpleado.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarPagoEmpleado(int CodigoPagoEmpleado)
        {
            string QueryEliminarPagoEmpleado = "Delete from tbl_Pagos_Empleados where CodigoPagoEmpleado = @CodigoPagoEmpleado";
            SqlCommand CommandEliminarPagoEmpleado = new SqlCommand(QueryEliminarPagoEmpleado, cd_conexion.MtdAbrirConexion());
            CommandEliminarPagoEmpleado.Parameters.AddWithValue("@CodigoPagoEmpleado", CodigoPagoEmpleado);
            CommandEliminarPagoEmpleado.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

    }
}
