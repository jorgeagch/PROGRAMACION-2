using System;
using System.Collections.Generic;

namespace MiTienda
{
    // Clase base abstracta
    public abstract class Comprobante
    {
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        public Comprobante(string num, double total)
        {
            Numero = num;
            Fecha = DateTime.Now;
            Total = total;
        }

        public abstract void ImprimirDetalle();
    }

    // Clase hija para facturación local
    public class Factura : Comprobante
    {
        public string Nit { get; set; }

        public Factura(string num, double total, string nit) : base(num, total)
        {
            Nit = nit;
        }

        public override void ImprimirDetalle()
        {
            Console.WriteLine("\n--- FACTURA REGISTRADA ---");
            Console.WriteLine($"NIT: {Nit}");
            Console.WriteLine($"Número: {Numero}");
            Console.WriteLine($"Fecha: {Fecha.ToShortDateString()}");
            Console.WriteLine($"Total: Bs. {Total}");
        }
    }

    public class Examen
    {
        private List<Comprobante> historial = new List<Comprobante>();

        public void RegistrarVenta(Comprobante c)
        {
            historial.Add(c);
        }

        public void MostrarReporte()
        {
            Console.WriteLine("\n=== HISTORIAL DE EXAMEN ===");
            foreach (var c in historial)
            {
                c.ImprimirDetalle();
            }
        }

        public static void EjecutarPrueba()
        {
            Examen prueba = new Examen();
            prueba.RegistrarVenta(new Factura("FAC-001", 550.0, "12345678"));
            prueba.MostrarReporte();
        }
    }
}