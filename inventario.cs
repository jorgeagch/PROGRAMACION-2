using System;

namespace MiTienda
{
    public class Inventario
    {
        private Producto?[] productos = new Producto?[100];
        private int contador = 0;

        public void AgregarProducto(Producto p)
        {
            if (contador < 100) productos[contador++] = p;
        }

        public void ListarProductos()
        {
            Console.WriteLine("\n--- CATÁLOGO DE PRODUCTOS ---");
            for (int i = 0; i < contador; i++)
            {
                Console.Write($"{i + 1}. ");
                productos[i]?.MostrarDetalle();
            }
        }

        public Producto? ObtenerProducto(int indice)
        {
            if (indice >= 0 && indice < contador) return productos[indice];
            return null;
        }
    }
}