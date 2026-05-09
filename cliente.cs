using System;

namespace MiTienda
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public double GastoTotalAcumulado { get; set; }
        public bool EsVip { get; set; }
        public bool EsFrecuente { get; set; }

        public Cliente(string nombre, double gastoPrevio, bool frecuente)
        {
            Nombre = nombre;
            GastoTotalAcumulado = gastoPrevio;
            EsFrecuente = frecuente;
            IdentificarCliente(); 
        }

        public void IdentificarCliente()
        {
            if (GastoTotalAcumulado > 1000)
            {
                EsVip = true;
                EsFrecuente = true; 
            }
        }

        public double AplicarDescuento(double totalCompra)
        {
            double descuento = 0;
            if (EsVip)
            {
                descuento = totalCompra * 0.10;
                Console.WriteLine("Se aplicó un 10% de descuento por ser Cliente VIP.");
            }
            
            double totalConDescuento = totalCompra - descuento;

            if (totalConDescuento > 500)
            {
                double adicional = totalConDescuento * 0.05;
                Console.WriteLine("¡Bono! Se aplicó un 5% adicional por compra mayor a Bs. 500.");
                totalConDescuento -= adicional;
            }

            return totalConDescuento;
        }
    }
}