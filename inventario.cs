namespace MiTienda
{
    public class Inventario
    {
        private Producto[] stock = new Producto[100];
        private int contador = 0;

        public void agregarproducto(Producto p)
        {
            if (contador < 100) stock[contador++] = p;
        }

        public int stockdeproductos() => contador;
    }
}