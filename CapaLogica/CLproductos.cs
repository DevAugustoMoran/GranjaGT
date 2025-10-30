using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLproductos
    {
        public DateTime MtdFechaActual()
        {
            return DateTime.Today;
        }

        public DateTime MtdCalcularVencimiento(DateTime fechaIngreso, DateTime fechaVencimiento)
        {
            if (fechaVencimiento < fechaIngreso)
            {
                throw new ArgumentException("La fecha de vencimiento no puede ser anterior a la fecha de ingreso.");
                fechaVencimiento = fechaIngreso;

            }

            return fechaVencimiento;
        }

    }
}
