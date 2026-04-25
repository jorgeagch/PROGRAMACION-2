using System;

namespace MiTienda
{
    public class Inventario
    {
        private Producto?[] productos = new Producto?[100];
        private int contador = 0;

        public void ListarProductos()
        {
            Console.WriteLine("\n--- INVENTARIO ---");
            if (contador == 0) Console.WriteLine("Vacío.");
            for (int i = 0; i < contador; i++)
                Console.WriteLine($"{i + 1}. {productos[i]!.getnombre()} - Bs. {productos[i]!.getprecio()}");
        }

        public void AgregarProducto(Producto p) {
            if (contador < 100) { productos[contador++] = p; Console.WriteLine("Agregado."); }
        }

        public void ActualizarProducto(int i, string nuevoNombre, double nuevoPrecio) {
            if (i >= 0 && i < contador) {
                productos[i] = new Producto(i.ToString(), nuevoNombre, nuevoPrecio);
                Console.WriteLine("Producto actualizado.");
            }
        }

        public void EliminarProducto(int i) {
            if (i >= 0 && i < contador) {
                for (int j = i; j < contador - 1; j++) productos[j] = productos[j + 1];
                contador--; Console.WriteLine("Eliminado.");
            }
        }

        public Producto? ObtenerProducto(int i) => (i >= 0 && i < contador) ? productos[i] : null;
    }
}