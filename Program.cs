using System;
using MiTienda;

namespace MiTienda
{
    class Program
    {
        static void Main()
        {
            Examen.EjecutarPrueba();
            Console.WriteLine("\nPresione Enter para ir a la tienda...");
            Console.ReadLine();

            Inventario inv = new Inventario();
            inv.AgregarProducto(new Producto("P1", "Monitor", 1200));
            inv.AgregarProducto(new Producto("P2", "Mouse", 100));

            bool tiendaAbierta = true;

            while (tiendaAbierta)
            {
                Console.Clear();
                Console.WriteLine("=== LOGIN TIENDA ===");
                Console.Write("Usuario: "); string u = Console.ReadLine() ?? "";
                Console.Write("Password: "); string p = Console.ReadLine() ?? "";

                if (u == "admin" && p == "123") MenuAdmin(inv, ref tiendaAbierta);
                else if (u == "cliente" && p == "456") MenuCliente(inv, ref tiendaAbierta);
                else {
                    Console.WriteLine("Credenciales inválidas.");
                    Console.ReadLine();
                }
            }
        }

        static void MenuAdmin(Inventario inv, ref bool abierta)
        {
            bool sesion = true;
            while (sesion) {
                Console.WriteLine("\n--- ADMIN --- \n1. Listar\n9. Cerrar Sesion\n10. Salir");
                string op = Console.ReadLine() ?? "";
                if (op == "1") inv.ListarProductos();
                else if (op == "9") sesion = false;
                else if (op == "10") { sesion = false; abierta = false; }
            }
        }

        static void MenuCliente(Inventario inv, ref bool abierta)
        {
            Carrito car = new Carrito();
            Cliente c = new Cliente("Jorge", 1200, true); 
            bool sesion = true;

            while (sesion) {
                Console.WriteLine("\n--- CLIENTE --- \n1. Ver Productos\n2. Comprar\n3. Finalizar\n4. Salir");
                string op = Console.ReadLine() ?? "";
                if (op == "1") inv.ListarProductos();
                else if (op == "2") {
                    inv.ListarProductos();
                    Console.Write("Elija el número: ");
                    if (int.TryParse(Console.ReadLine(), out int idx)) {
                        Producto? prod = inv.ObtenerProducto(idx - 1);
                        if (prod != null) car.RealizarCompra(prod);
                    }
                }
                else if (op == "3") {
                    car.MostrarResumen();
                    double totalFinal = c.AplicarDescuento(car.ObtenerTotalAcumulado());
                    Console.WriteLine($"TOTAL FINAL: Bs. {totalFinal}");
                    Console.ReadLine();
                    sesion = false;
                }
                else if (op == "4") { sesion = false; abierta = false; }
            }
        }
    }
}