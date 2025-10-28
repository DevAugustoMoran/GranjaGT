using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDempleados
    {
        CDconexion cd_conexion = new CDconexion();
        public DataTable MtdConsultarEmpleado()
        {
            string QueryConsultarEmpleado = "Select * from tbl_Empleados";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarEmpleado, cd_conexion.MtdAbrirConexion());
            DataTable dt_empleado = new DataTable();
            dt_adapter.Fill(dt_empleado);
            cd_conexion.MtdCerrarConexion();
            return dt_empleado;
        }

        public void MtdAgregarEmpleado(int CodigoGranja, int CodigoUsuario, string Nombre, string Telefono, string Correo, string Cargo, string Estado, decimal SalarioBase, DateTime FechaIngreso, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryAgregarEmpleado = "Insert into tbl_Empleados(CodigoGranja, CodigoUsuario, Nombre, Telefono, Correo, Cargo, Estado, SalarioBase, FechaIngreso, UsuarioAuditoria, FechaAuditoria) values (@CodigoGranja, @CodigoUsuario, @Nombre, @Telefono, @Correo, @Cargo, @Estado, @SalarioBase, @FechaIngreso, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarEmpleado = new SqlCommand(QueryAgregarEmpleado, cd_conexion.MtdAbrirConexion());
            CommandAgregarEmpleado.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandAgregarEmpleado.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            CommandAgregarEmpleado.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarEmpleado.Parameters.AddWithValue("@Telefono", Telefono);
            CommandAgregarEmpleado.Parameters.AddWithValue("@Correo", Correo);
            CommandAgregarEmpleado.Parameters.AddWithValue("@Cargo", Cargo);
            CommandAgregarEmpleado.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarEmpleado.Parameters.AddWithValue("@SalarioBase", SalarioBase);
            CommandAgregarEmpleado.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            CommandAgregarEmpleado.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarEmpleado.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarEmpleado.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarEmpleado(int CodigoEmpleado, int CodigoGranja, int CodigoUsuario, string Nombre, string Telefono, string Correo, string Cargo, string Estado, decimal SalarioBase, DateTime FechaIngreso, string UsuarioAuditoria, DateTime FechaAuditoria)
        {
            string QueryActualizarEmpleado = "Update tbl_Empleados set CodigoGranja = @CodigoGranja, CodigoUsuario = @CodigoUsuario, Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Cargo = @Cargo, Estado = @Estado, SalarioBase = @SalarioBase, FechaIngreso = @FechaIngreso, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand CommandActualizarEmpleado = new SqlCommand(QueryActualizarEmpleado, cd_conexion.MtdAbrirConexion());
            CommandActualizarEmpleado.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandActualizarEmpleado.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandActualizarEmpleado.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            CommandActualizarEmpleado.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarEmpleado.Parameters.AddWithValue("@Telefono", Telefono);
            CommandActualizarEmpleado.Parameters.AddWithValue("@Correo", Correo);
            CommandActualizarEmpleado.Parameters.AddWithValue("@Cargo", Cargo);
            CommandActualizarEmpleado.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarEmpleado.Parameters.AddWithValue("@SalarioBase", SalarioBase);
            CommandActualizarEmpleado.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            CommandActualizarEmpleado.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarEmpleado.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarEmpleado.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarEmpleado(int CodigoEmpleado)
        {
            string QueryEliminarEmpleado = "Delete tbl_Empleados where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand CommandEliminarEmpleado = new SqlCommand(QueryEliminarEmpleado, cd_conexion.MtdAbrirConexion());
            CommandEliminarEmpleado.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandEliminarEmpleado.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

    }
}
