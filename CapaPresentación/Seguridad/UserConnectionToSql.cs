using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaPresentacion.Seguridad
{
    public abstract class UserConnectionToSql
    {
        private readonly string connectionString;
        public UserConnectionToSql()
        {
            connectionString = "Data Source=dbgranjagt.cr2wcaoq65ff.us-east-2.rds.amazonaws.com;Initial Catalog=dbGranjaGT;User ID=admin;Password=Pass$2024;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
