namespace MiTienda
{
    public class Producto
    {
        private string codigo;
        private string nombre;
        private double precio;

        public Producto(string codigo, string nombre, double precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
        }

        public double getprecio() => precio;
        public string getnombre() => nombre;
    }
}