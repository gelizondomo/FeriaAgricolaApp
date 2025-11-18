using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaBox.Application.Helpers
{
    public static class DateUtils
    {
        public static string FormatearFecha(DateTime fecha) => fecha.ToString("dd/MM/yyyy");
        public static bool EsRangoValido(DateTime inicio, DateTime fin) => inicio <= fin;
    }
}

