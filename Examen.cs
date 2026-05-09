using System;
using System.Collections.Generic;

namespace MiTienda
{
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

    public class Factura : Comprobante
    {
        public string Nit { get; set; }

        public Factura(string num, double total, string nit) : base(num, total)
        {
            Nit = nit;
        }

        public override void ImprimirDetalle()
        {
            Console.WriteLine($"\n--- FACTURA: {Numero} ---");
            Console.WriteLine($"NIT: {Nit} | Total: Bs. {Total}");
        }
    }

    public class Examen
    {
        public static void EjecutarPrueba()
        {
            Console.WriteLine("=== INICIANDO PRUEBA DE EXAMEN ===");
            Factura f = new Factura("F-001", 550.0, "1234567");
            f.ImprimirDetalle();
        }
    }
}