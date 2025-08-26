using System;

namespace Ejercicio1
{
    /// <summary>
    /// Representa una línea de venta formada por un producto y una cantidad.
    /// </summary>
    public class ItemVenta
    {
        public ItemVenta(Producto producto, int cantidad)
        {
            Producto = producto ?? throw new ArgumentNullException(nameof(producto));
            Cantidad = cantidad;
        }

        /// <summary>Producto seleccionado para la venta.</summary>
        public Producto Producto { get; }

        /// <summary>Cantidad del producto.</summary>
        public int Cantidad { get; }

        /// <summary>Subtotal calculado para este ítem.</summary>
        public decimal Subtotal => Producto.Precio * Cantidad;
    }
}
