using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaPresentacion.Seguridad
{
    public class UserDao : UserConnectionToSql
    {
        public bool Login(string Nombre, string Contrasena)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from tbl_Usuarios where Nombre = @Nombre and Contrasena = @Contrasena";
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Contrasena", Contrasena);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.CodigoUsuario = reader.GetInt32(0);
                            UserCache.CodigoRol = reader.GetInt32(1);
                            UserCache.Nombre = reader.GetString(2);
                            UserCache.FechaRegistro = reader.GetString(3);
                            UserCache.Estado = reader.GetString(4);
                            UserCache.Contrasena = reader.GetString(7);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

    }
}
