using System;
using System.Collections.Generic;

namespace MiTienda
{
    public class Carrito
    {
        private List<Producto> listaCompra = new List<Producto>();

        public void Agregar(Producto p)
        {
            if (p.ValidarDisponibilidad())
            {
                listaCompra.Add(p);
                Console.WriteLine($"Agregado al carrito: {p.Nombre}");
            }
            else
            {
                Console.WriteLine($"No se pudo agregar: {p.Nombre}. (Sin stock o sin licencia válida)");
            }
        }

        public double ObtenerSubtotal()
        {
            double total = 0;
            foreach (var p in listaCompra)
            {
                total += p.Precio;
            }
            return total;
        }

        public bool MostrarResumenYConfirmar(Cliente cliente)
        {
            if (listaCompra.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return false;
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("           RESUMEN DE TU COMPRA         ");
            Console.WriteLine("========================================");

            foreach (var p in listaCompra)
            {
                p.MostrarDetalle();
            }

            double subtotal = ObtenerSubtotal();
            double totalFinal = cliente.AplicarDescuento(subtotal);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"SUBTOTAL:         Bs. {subtotal:N2}");
            Console.WriteLine($"TOTAL A PAGAR:    Bs. {totalFinal:N2}");
            Console.WriteLine("----------------------------------------");

            Console.Write("¿Desea confirmar la compra? (S/N): ");
            string respuesta = Console.ReadLine()?.ToUpper() ?? "N";

            if (respuesta == "S")
            {
                Console.WriteLine("\nGracias por su compra");
                listaCompra.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("\nCompra cancelada. Los productos siguen en el carrito.");
                return false;
            }
        }
    }
}