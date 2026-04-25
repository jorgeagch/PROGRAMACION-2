using System;

namespace MiTienda
{
    public class Inventario
    {
        private Producto[] productos = new Producto[100];
        private int contador = 0;

        public void AgregarProducto(Producto p)
        {
            if (contador < 100) {
                productos[contador++] = p;
            }
        }

        public void ListarProductos()
        {
            Console.WriteLine("\n--- PRODUCTOS DISPONIBLES ---");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i + 1}. {productos[i].Nombre} - Bs. {productos[i].Precio}");
            }
        }

        public int stockdeproductos() => contador;
        public Producto? ObtenerProducto(int index) => (index >= 0 && index < contador) ? productos[index] : null;
    }
}