namespace Grupo3_Identity.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float  Precio { get; set; }
        public string Tipo { get; set; }
        public string Color { get; set; }
        public string Origen {  get; set; }
        public bool Disponible { get; set; }

    }
}
