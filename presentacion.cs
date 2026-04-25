using System;
namespace MiTienda
{
       public class Presentacion
    {
        public void MostrarTitulo(string texto)
        {
            Console.WriteLine("========================");
            Console.WriteLine($"   {texto.ToUpper()}   ");
            Console.WriteLine("========================");
        }
    }
}