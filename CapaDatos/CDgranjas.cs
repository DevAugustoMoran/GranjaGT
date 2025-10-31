using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDgranjas
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarGranjas()
        {
            string QueryConsultarGranjas = "Select * from tbl_Granjas";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarGranjas, cd_conexion.MtdAbrirConexion());
            DataTable dt_Granjas = new DataTable();
            sqlAdapter.Fill(dt_Granjas);
            cd_conexion.MtdCerrarConexion();
            return dt_Granjas;
        }

        public void MtdAgregarGranja(string Nombre, string Direccion, string Telefono, string Correo, string EstadoGranja, string UsuarioAuditoria, string FechaAuditoria)
        {
            string QueryAgregarGranja = "Insert into tbl_Granjas(Nombre, Direccion, Telefono, Correo, EstadoGranja, UsuarioAuditoria, FechaAuditoria) values (@Nombre, @Direccion, @Telefono, @Correo, @EstadoGranja, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarGranja = new SqlCommand(QueryAgregarGranja, cd_conexion.MtdAbrirConexion());
            CommandAgregarGranja.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarGranja.Parameters.AddWithValue("@Direccion", Direccion);
            CommandAgregarGranja.Parameters.AddWithValue("@Telefono", Telefono);
            CommandAgregarGranja.Parameters.AddWithValue("@Correo", Correo);
            CommandAgregarGranja.Parameters.AddWithValue("@EstadoGranja", EstadoGranja);
            CommandAgregarGranja.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarGranja.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarGranja.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarGranja(int CodigoGranja, string Nombre, string Direccion, string Telefono, string Correo, string EstadoGranja, string UsuarioAuditoria, string FechaAuditoria)
        {
            string QueryActualizarGranja = "Update tbl_Granjas set Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Correo = @Correo, EstadoGranja = @EstadoGranja, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoGranja = @CodigoGranja";
            SqlCommand CommandActualizarGranja = new SqlCommand(QueryActualizarGranja, cd_conexion.MtdAbrirConexion());
            CommandActualizarGranja.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandActualizarGranja.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarGranja.Parameters.AddWithValue("@Direccion", Direccion);
            CommandActualizarGranja.Parameters.AddWithValue("@Telefono", Telefono);
            CommandActualizarGranja.Parameters.AddWithValue("@Correo", Correo);
            CommandActualizarGranja.Parameters.AddWithValue("@EstadoGranja", EstadoGranja);
            CommandActualizarGranja.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarGranja.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarGranja.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarGranja(int CodigoGranja)
        {
            string QueryEliminarGranja = "Delete from tbl_Granjas where CodigoGranja = @CodigoGranja";
            SqlCommand CommandEliminarGranja = new SqlCommand(QueryEliminarGranja, cd_conexion.MtdAbrirConexion());
            CommandEliminarGranja.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            CommandEliminarGranja.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public bool MtdConsultarEmpleados(int CodigoGranja)
        {
            string QueryConsultarEmpleado = "SELECT 1 FROM tbl_Empleados WHERE CodigoGranja = @CodigoGranja";
            SqlCommand CommandEliminarGranja = new SqlCommand(QueryConsultarEmpleado, cd_conexion.MtdAbrirConexion());
            CommandEliminarGranja.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarGranja.ExecuteScalar(); // devuelve 1 o null
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

        public bool MtdConsultarInventarios(int CodigoGranja)
        {
            string QueryConsultarInventario = "SELECT 1 FROM tbl_Inventarios WHERE CodigoGranja = @CodigoGranja";
            SqlCommand CommandEliminarGranja = new SqlCommand(QueryConsultarInventario, cd_conexion.MtdAbrirConexion());
            CommandEliminarGranja.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarGranja.ExecuteScalar(); // devuelve 1 o null
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

        public bool MtdConsultarVenta(int CodigoGranja)
        {
            string QueryConsultarVenta = "SELECT 1 FROM tbl_Ventas WHERE CodigoGranja = @CodigoGranja";
            SqlCommand CommandEliminarGranja = new SqlCommand(QueryConsultarVenta, cd_conexion.MtdAbrirConexion());
            CommandEliminarGranja.Parameters.AddWithValue("@CodigoGranja", CodigoGranja);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarGranja.ExecuteScalar(); // devuelve 1 o null
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
