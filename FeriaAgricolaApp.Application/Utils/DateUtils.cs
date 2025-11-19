using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaAgricolaApp.Application.Utils
{
    public static class DateUtils
    {
        public static string FormatearFecha(DateTime fecha) => fecha.ToString("dd/MM/yyyy");
        public static bool EsRangoValido(DateTime inicio, DateTime fin) => inicio <= fin;
    }
}

