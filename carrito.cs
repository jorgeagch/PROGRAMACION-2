namespace MiTienda
{
    public class Carrito
    {
        private Producto[] productos = new Producto[100];
        private int cantidad = 0;

        public void agregaralcarrito(Producto prod)
        {
            if (cantidad < 100)
            {
                productos[cantidad] = prod;
                cantidad++;
            }
        }

        public double mostrartotal()
        {
            double suma = 0;
            for (int i = 0; i < cantidad; i++)
            {
                suma += productos[i].getprecio();
            }
            return suma;
        }

        public int cantidaddeproductos() => cantidad;
    }
}