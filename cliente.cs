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
            else
            {
                EsVip = false;
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
            else if (!EsFrecuente)
            {
                Console.WriteLine("Cliente no frecuente: no hay descuentos de categoría.");
            }

            return totalCompra - descuento;
        }

        public double DescuentoAdicional(double totalActual)
        {
            if (totalActual > 500)
            {
                double adicional = totalActual * 0.05;
                Console.WriteLine("¡Bono! Se aplicó un 5% adicional por compra mayor a Bs. 500.");
                return totalActual - adicional;
            }
            return totalActual;
        }

        public void VerPromocionesDisponibles()
        {
            Console.WriteLine("\n--- PROMOCIONES DISPONIBLES ---");
            Console.WriteLine("1. Descuento VIP: 10% de rebaja si tus compras superan los Bs. 1000.");
            Console.WriteLine("2. Súper Compra: 5% extra si tu carrito actual supera los Bs. 500.");
            Console.WriteLine("3. Nuevos Clientes: ¡Registra tu primera compra para ser frecuente!");
        }
        public void AgregarTipoDescuento(string nombrePromo, double porcentaje)
        {
            Console.WriteLine($"Nueva promoción creada: {nombrePromo} con el {porcentaje * 100}%.");
        }
    }
}