using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLpagosEmpleados
    {
        public DateTime MtdFechaActual()
        {
            return DateTime.Today;
        }

        public decimal MtdCalcularSalarioFinal(decimal salario, decimal horasExtra, decimal bonos, decimal descuentos)
        {
            decimal salarioFinal = salario + (horasExtra * 20)  + bonos - descuentos;
            return salarioFinal;
        }

    }
}
