using System;

namespace MiTienda
{
    public abstract class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public abstract void MostrarDetalle();
        
        public abstract bool ValidarDisponibilidad();
    }

    public class ProductoFisico : Producto
    {
        public int Stock { get; set; }

        public ProductoFisico(string nombre, double precio, int stock) : base(nombre, precio)
        {
            Stock = stock;
        }

        public override void MostrarDetalle()
        {
            Console.WriteLine($"[Físico] {Nombre} - Precio: Bs. {Precio} - Stock: {Stock}");
        }

        public override bool ValidarDisponibilidad()
        {
            return Stock > 0;
        }
    }

    public class ProductoDigital : Producto
    {
        public string Licencia { get; set; }

        public ProductoDigital(string nombre, double precio, string licencia) : base(nombre, precio)
        {
            Licencia = licencia;
        }

        public override void MostrarDetalle()
        {
            Console.WriteLine($"[Digital] {Nombre} - Precio: Bs. {Precio} - Licencia: {Licencia}");
        }

        public override bool ValidarDisponibilidad()
        {
            return !string.IsNullOrEmpty(Licencia);
        }
    }
}