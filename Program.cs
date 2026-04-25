using System;
using MiTienda;

namespace MiTienda
{
    class Program
    {
        static void Main()
        {
            Inventario inv = new Inventario();
            // Productos iniciales para probar
            inv.AgregarProducto(new Producto("P1", "Monitor", 1200));
            inv.AgregarProducto(new Producto("P2", "Mouse", 100));

            bool tiendaAbierta = true;

            while (tiendaAbierta)
            {
                Console.Clear();
                Console.WriteLine("=== LOGIN TIENDA ===");
                Console.Write("Usuario: "); string u = Console.ReadLine() ?? string.Empty;
                Console.Write("Password: "); string p = Console.ReadLine() ?? string.Empty;

                if (u == "admin" && p == "123") {
                    MenuAdmin(inv, ref tiendaAbierta);
                }
                else if (u == "cliente" && p == "456") {
                    MenuCliente(inv, ref tiendaAbierta);
                }
                else {
                    Console.WriteLine("Credenciales inválidas. Enter para reintentar...");
                    Console.ReadLine();
                }
            }
        }

        static void MenuAdmin(Inventario inv, ref bool abierta)
        {
            bool sesion = true;
            while (sesion) {
                Console.WriteLine("\n--- ADMIN --- \n1. Listar\n9. Cerrar Sesion\n10. Cerrar Tienda");
                string op = Console.ReadLine() ?? string.Empty;
                if (op == "1") inv.ListarProductos();
                else if (op == "9") sesion = false;
                else if (op == "10") { sesion = false; abierta = false; }
            }
        }

        static void MenuCliente(Inventario inv, ref bool abierta)
        {
            Carrito car = new Carrito();
            Cliente c = new Cliente("Jorge", 1200); // Ejemplo VIP
            bool sesion = true;

            while (sesion) {
                Console.WriteLine("\n--- CLIENTE --- \n1. Ver Productos\n2. Comprar\n3. Finalizar/Cerrar Sesion\n4. Salir");
                string op = Console.ReadLine() ?? string.Empty;
                if (op == "1") inv.ListarProductos();
                else if (op == "2") {
                    inv.ListarProductos();
                    Console.Write("Elija el número: ");
                    string? entrada = Console.ReadLine();
                    if (int.TryParse(entrada, out int idx)) {
                        idx -= 1;
                        Producto? prod = inv.ObtenerProducto(idx);
                        if (prod != null) {
                            car.agregaralcarrito(prod);
                            Console.WriteLine("Agregado.");
                        } else {
                            Console.WriteLine("Producto inválido.");
                        }
                    } else {
                        Console.WriteLine("Entrada inválida.");
                    }
                }
                else if (op == "3") {
                    double total = c.AplicarDescuento(car.mostrartotal());
                    Console.WriteLine($"Total final: Bs. {total}");
                    Console.WriteLine("Sesión cerrada. Presione Enter...");
                    Console.ReadLine();
                    sesion = false;
                }
                else if (op == "4") { sesion = false; abierta = false; }
            }
        }
    }
}