namespace RestApi.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Decimal Precio { get; set;}
        public int Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
