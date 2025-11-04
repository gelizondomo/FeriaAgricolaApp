using System;


namespace FeriaAgricolaApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public List<Direccion> Direcciones { get; set; } = new List<Direccion>();

        public Usuario(int id, string nombre, string email, string password, string telefono, List<Direccion> direcciones)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Password = password;
            Telefono = telefono;
            Direcciones = direcciones;
        }
    }
}
