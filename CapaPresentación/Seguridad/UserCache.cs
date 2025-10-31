using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Seguridad
{
    public  class UserCache
    {
        public static int CodigoUsuario { get; set; }
        public static int CodigoRol { get; set; }

        public static string NombreRol { get; set; }
        public static string Nombre { get; set; }
        public static DateTime FechaRegistro { get; set; }
        public static string Estado { get; set; }
        public static string Contrasena { get; set; }

    }
}
