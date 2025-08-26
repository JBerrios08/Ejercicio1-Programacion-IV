namespace Ejercicio1
{
    /// <summary>
    /// Representa un producto disponible para la venta.
    /// </summary>
    public class Producto
    {
        /// <summary>Identificador del producto.</summary>
        public int Id { get; set; }

        /// <summary>Nombre legible del producto.</summary>
        public string Nombre { get; set; }

        /// <summary>Precio unitario del producto.</summary>
        public decimal Precio { get; set; }
    }
}
