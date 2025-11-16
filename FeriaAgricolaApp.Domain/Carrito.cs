namespace FeriaAgricolaApp.Domain
{
    public class Carrito
    {
        public int UsuarioId { get; set; }
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();

        public decimal Total => Items.Sum(item => item.Subtotal);

        public Carrito(int usuarioId, List<CarritoItem> items)
        {
            UsuarioId = usuarioId;
            Items = items;
        }
    }
}
