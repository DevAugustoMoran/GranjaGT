using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLinventarios
    {
        public DateTime MtdFechaActual()
        {
            return DateTime.Today;
        }

        public decimal MtdCalcularCostoTotal(decimal cantidadDisponible, decimal CostoUnitario)
        {
            return cantidadDisponible * CostoUnitario;
        }
    }
}
