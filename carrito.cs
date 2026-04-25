using System;
using System.Collections.Generic;

namespace MiTienda
{
    public class Carrito
    {
        private List<Producto> listaCompra = new List<Producto>();

        public void RealizarCompra(Producto p)
        {
            listaCompra.Add(p);
            Console.WriteLine($"Agregado al carrito: {p.getnombre()}");
        }

        public void MostrarResumen()
        {
            double total = 0;
            Console.WriteLine("\n--- RESUMEN FINAL DE COMPRA ---");
            foreach (var p in listaCompra)
            {
                Console.WriteLine($"- {p.getnombre()}: Bs. {p.getprecio()}");
                total += p.getprecio();
            }
            Console.WriteLine($"TOTAL A PAGAR: Bs. {total}");
        }
    }
}