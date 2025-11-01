using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDconexion
    {
        private SqlConnection db_conexion = new SqlConnection("Data Source=dbgranjagt.cr2wcaoq65ff.us-east-2.rds.amazonaws.com;Initial Catalog=dbGranjaGT;User ID=admin;Password=Pass$2024;Connect Timeout=30;Encrypt=True");

        public SqlConnection MtdAbrirConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
            {
                db_conexion.Open();
            }
            return db_conexion;
        }

        public SqlConnection MtdCerrarConexion()
        {
            if (db_conexion.State == ConnectionState.Open)
            {
                db_conexion.Close();
            }
            return db_conexion;
        }
    }
}
