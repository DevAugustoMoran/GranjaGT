using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLventasDetalle
    {
        public DateTime MtdFechaActual()
        {
            return DateTime.Today;
        }

        public decimal MtdCalcularTotal(decimal Cantidad, decimal PrecioUnitario)
        {
            return Cantidad * PrecioUnitario;
        }

        public decimal MtdCalcularTotalVenta(decimal Total, decimal Descuento, decimal Impuesto)
        {
            return Total - Descuento + Impuesto;
        }
    }
}
