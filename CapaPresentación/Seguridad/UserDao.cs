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
                    command.CommandText = @"
                    Select
                    u.CodigoUsuario,
                    u.CodigoRol,
                    u.Nombre,
                    u.Estado,
                    u.FechaRegistro,
                    u.Contrasena,
                    r.NombreRol
                    from
                    tbl_Usuarios as u
                    Inner join
                    tbl_Roles as r on u.CodigoRol = r.CodigoRol
                    where
                    u.Nombre = @Nombre and u.Contrasena = @Contrasena";

                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Contrasena", Contrasena);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.CodigoUsuario = reader.GetInt32(reader.GetOrdinal("CodigoUsuario"));
                            UserCache.CodigoRol = reader.GetInt32(reader.GetOrdinal("CodigoRol"));
                            UserCache.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                            UserCache.Estado = reader.GetString(reader.GetOrdinal("Estado"));
                            UserCache.Contrasena = reader.GetString(reader.GetOrdinal("Contrasena"));
                            UserCache.FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                            UserCache.NombreRol = reader.GetString(reader.GetOrdinal("NombreRol"));
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
