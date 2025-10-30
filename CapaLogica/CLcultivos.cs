using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CLcultivos
    {
        public DateTime MtdFechaActual()
        {
            return DateTime.Today;
        }


        public DateTime MtdFechaCosecha(DateTime fechaSiembra, DateTime fechaCosecha)
        {
            if (fechaCosecha < fechaSiembra)
            {
                throw new ArgumentException("La fecha de cosecha no puede ser anterior a la fecha de siembra.");
                fechaCosecha = fechaSiembra;
            }

            return fechaCosecha;
        }
    }
}
