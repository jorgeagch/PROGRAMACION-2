using System;

namespace MiTienda
{
    public class Presentacion
    {
        public void MostrarMenuAdmin()
        {
            Console.WriteLine("\n--- MENÚ ADMINISTRADOR ---");
            Console.WriteLine("1. Listar productos\n2. Agregar producto\n3. Actualizar producto\n4. Eliminar producto");
            Console.WriteLine("5. Listar usuarios\n6. Agregar usuario\n7. Actualizar usuario\n8. Eliminar usuario");
            Console.WriteLine("9. Cerrar Sesión\n10. Salir");
            Console.Write("Seleccione una opción: ");
        }

        public void MostrarMenuCliente()
        {
            Console.WriteLine("\n--- MENÚ CLIENTE ---");
            Console.WriteLine("1. Ver productos disponibles\n2. Realizar una compra\n3. Cerrar Sesión\n4. Salir");
            Console.Write("Seleccione una opción: ");
        }
    }
}