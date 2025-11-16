namespace FeriaAgricolaApp.Domain
{
    public class Compra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string DireccionEntrega { get; set; }
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public List<CarritoItem> Carrito { get; set; } = new List<CarritoItem>();
        public decimal Total { get; set; }
        public string Estado { get; set; } = "Pendiente";



        public void CalcularTotal()
        {
            Total = Carrito.Sum(i => i.Subtotal);
        }

        public override string ToString()
        {
            return $"{FechaCompra:dd/MM/yyyy} - Total ₡{Total:N2} - Estado: {Estado}";
        }
    }
}
