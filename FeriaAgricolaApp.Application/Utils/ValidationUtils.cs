using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FeriaBox.Application.Helpers
{
    public static class ValidationUtils
    {
        public static bool EmailValido(string email) => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        public static bool TelefonoValido(string telefono) => Regex.IsMatch(telefono, @"^[0-9]{8,12}$");
        public static bool PasswordSegura(string password) =>
            password.Length >= 6 && System.Linq.Enumerable.Any(password, char.IsUpper) && System.Linq.Enumerable.Any(password, char.IsDigit);
    }
}
