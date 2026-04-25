using System;

namespace MiTienda
{
    public class Inventario
    {
        private Producto?[] productos = new Producto?[100];
        private int contador = 0;

        public void ListarProductos()
        {
            Console.WriteLine("\n--- PRODUCTOS DISPONIBLES ---");
            if (contador == 0) Console.WriteLine("No hay productos.");
            for (int i = 0; i < contador; i++)
                Console.WriteLine($"{i + 1}. {productos[i]!.getnombre()} - Bs. {productos[i]!.getprecio()}");
        }

        public void AgregarProducto(Producto p)
        {
            if (contador < 100) { productos[contador++] = p; Console.WriteLine("Producto agregado."); }
        }

        public void ActualizarProducto(int i, string n, double p)
        {
            if (i >= 0 && i < contador) {
                productos[i] = new Producto(i.ToString(), n, p);
                Console.WriteLine("Producto actualizado.");
            }
        }

        public void EliminarProducto(int i)
        {
            if (i >= 0 && i < contador) {
                for (int j = i; j < contador - 1; j++) productos[j] = productos[j + 1];
                contador--; Console.WriteLine("Producto eliminado.");
            }
        }

        public Producto? ObtenerProducto(int i) => (i >= 0 && i < contador) ? productos[i] : null;
    }
}