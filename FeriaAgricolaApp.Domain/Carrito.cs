namespace FeriaAgricolaApp.Domain
{
    public class Carrito
    {
        public int UsuarioId { get; set; }
        public List<CarritoItem> Items { get; set; }

        public decimal CalcularTotal()
        {
            return Items.Sum(static i => i.Subtotal);
        }

        public void AgregarItem(CarritoItem item)
        {
            var existente = Items.FirstOrDefault(i => i.ProductoId == item.ProductoId);
            switch (existente)
            {
                case null:
                    Items.Add(item);
                    break;
                default:
                    existente.Cantidad += item.Cantidad;
                    break;
            }
        }

        public void EliminarItem(int productoId)
        {
            Items.RemoveAll(i => i.ProductoId == productoId);
        }

        public void Vaciar()
        {
            Items.Clear();
        }
    }
}
