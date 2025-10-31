using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDanimales
    {
        CDconexion cd_conexion = new CDconexion();

        public DataTable MtdConsultarAnimales()
        {
            string QueryConsultarAnimales = "Select * from tbl_Animales";
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(QueryConsultarAnimales, cd_conexion.MtdAbrirConexion());
            DataTable dt_Animales = new DataTable();
            sqlAdapter.Fill(dt_Animales);
            cd_conexion.MtdCerrarConexion();
            return dt_Animales;
        }

        public void MtdAgregarAnimal(string TipoAnimal, string Raza, DateTime FechaNacimiento, Decimal Precio, string Descripcion, string Estado, string UsuarioAuditoria, string FechaAuditoria)
        {
            string QueryAgregarAnimal = "Insert into tbl_Animales(TipoAnimal, Raza, FechaNacimiento, Precio, Descripcion, Estado, UsuarioAuditoria, FechaAuditoria) values (@TipoAnimal, @Raza, @FechaNacimiento, @Precio, @Descripcion, @Estado, @UsuarioAuditoria, @FechaAuditoria)";
            SqlCommand CommandAgregarAnimal = new SqlCommand(QueryAgregarAnimal, cd_conexion.MtdAbrirConexion());
            CommandAgregarAnimal.Parameters.AddWithValue("@TipoAnimal", TipoAnimal);
            CommandAgregarAnimal.Parameters.AddWithValue("@Raza", Raza);
            CommandAgregarAnimal.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            CommandAgregarAnimal.Parameters.AddWithValue("@Precio", Precio);
            CommandAgregarAnimal.Parameters.AddWithValue("@Descripcion", Descripcion);
            CommandAgregarAnimal.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarAnimal.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandAgregarAnimal.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandAgregarAnimal.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarAnimal(int CodigoAnimal, string TipoAnimal, string Raza, DateTime FechaNacimiento, Decimal Precio, string Descripcion, string Estado, string UsuarioAuditoria, string FechaAuditoria)
        {
            string QueryActualizarAnimal = "Update tbl_Animales set TipoAnimal = @TipoAnimal, Raza = @Raza, FechaNacimiento = @FechaNacimiento, Precio = @Precio, Descripcion = @Descripcion, Estado = @Estado, UsuarioAuditoria = @UsuarioAuditoria, FechaAuditoria = @FechaAuditoria where CodigoAnimal = @CodigoAnimal";
            SqlCommand CommandActualizarAnimal = new SqlCommand(QueryActualizarAnimal, cd_conexion.MtdAbrirConexion());
            CommandActualizarAnimal.Parameters.AddWithValue("@CodigoAnimal", CodigoAnimal);
            CommandActualizarAnimal.Parameters.AddWithValue("@TipoAnimal", TipoAnimal);
            CommandActualizarAnimal.Parameters.AddWithValue("@Raza", Raza);
            CommandActualizarAnimal.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            CommandActualizarAnimal.Parameters.AddWithValue("@Precio", Precio);
            CommandActualizarAnimal.Parameters.AddWithValue("@Descripcion", Descripcion);
            CommandActualizarAnimal.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarAnimal.Parameters.AddWithValue("@UsuarioAuditoria", UsuarioAuditoria);
            CommandActualizarAnimal.Parameters.AddWithValue("@FechaAuditoria", FechaAuditoria);
            CommandActualizarAnimal.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarAnimal(int CodigoAnimal)
        {
            string QueryEliminarAnimal = "Delete from tbl_Animales where CodigoAnimal = @CodigoAnimal";
            SqlCommand CommandEliminarAnimal = new SqlCommand(QueryEliminarAnimal, cd_conexion.MtdAbrirConexion());
            CommandEliminarAnimal.Parameters.AddWithValue("@CodigoAnimal", CodigoAnimal);
            CommandEliminarAnimal.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public bool MtdConsultarVentasDetalle(int CodigoAnimal)
        {
            string QueryConsultarVentasDetalle = "SELECT 1 FROM tbl_VentasDetalle WHERE CodigoAnimal = @CodigoAnimal";
            SqlCommand CommandEliminarAnimal = new SqlCommand(QueryConsultarVentasDetalle, cd_conexion.MtdAbrirConexion());
            CommandEliminarAnimal.Parameters.AddWithValue("@CodigoAnimal", CodigoAnimal);
            cd_conexion.MtdAbrirConexion();
            object result = CommandEliminarAnimal.ExecuteScalar(); // devuelve 1 o null
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
