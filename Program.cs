using System;
using System.Collections.Generic;
using MiTienda;

class Program
{
    static void Main()
    {
        Presentacion gui = new Presentacion();
        Inventario inventario = new Inventario();
        Carrito carrito = new Carrito();

        // Lista de usuarios inicial
        List<Usuario> usuarios = new List<Usuario> {
            new Usuario("jorge", "123", "Admin"),
            new Usuario("user", "456", "Cliente")
        };

        bool appCorriendo = true;
        while (appCorriendo)
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN TIENDA CONSOLA ===");
            Console.Write("Usuario: ");
            string userIn = Console.ReadLine() ?? "";
            Console.Write("Contraseña: ");
            string passIn = Console.ReadLine() ?? "";

            Usuario? userLogueado = usuarios.Find(u => u.Nombre == userIn && u.Password == passIn);

            if (userLogueado != null)
            {
                MenuLogica(userLogueado, gui, inventario, carrito, usuarios, ref appCorriendo);
            }
            else
            {
                Console.WriteLine("Credenciales incorrectas. Presione una tecla...");
                Console.ReadKey();
            }
        }
    }

    static void MenuLogica(Usuario user, Presentacion gui, Inventario inv, Carrito car, List<Usuario> listaU, ref bool appCorriendo)
    {
        bool sesionActiva = true;
        while (sesionActiva)
        {
            Console.Clear();
            if (user.Rol == "Admin")
            {
                gui.MostrarMenuAdmin();
                string op = Console.ReadLine() ?? "";
                switch (op)
                {
                    case "1": inv.ListarProductos(); break;
                    case "2":
                        Console.Write("Nombre: "); string n = Console.ReadLine() ?? "";
                        Console.Write("Precio: "); double.TryParse(Console.ReadLine(), out double p);
                        inv.AgregarProducto(new Producto("0", n, p));
                        break;
                    case "3": // Actualizar
                        inv.ListarProductos();
                        Console.Write("Nro a actualizar: "); int.TryParse(Console.ReadLine(), out int iU);
                        Console.Write("Nuevo Nombre: "); string nn = Console.ReadLine() ?? "";
                        Console.Write("Nuevo Precio: "); double.TryParse(Console.ReadLine(), out double np);
                        inv.ActualizarProducto(iU - 1, nn, np);
                        break;
                    case "4":
                        inv.ListarProductos();
                        Console.Write("Nro a eliminar: "); int.TryParse(Console.ReadLine(), out int iE);
                        inv.EliminarProducto(iE - 1);
                        break;
                    case "5": // Listar Usuarios
                        Console.WriteLine("\n--- USUARIOS ---");
                        listaU.ForEach(u => Console.WriteLine($"- {u.Nombre} [{u.Rol}]"));
                        break;
                    case "6": // Agregar Usuario
                        Console.Write("Nombre: "); string un = Console.ReadLine() ?? "";
                        Console.Write("Pass: "); string up = Console.ReadLine() ?? "";
                        Console.Write("Rol (Admin/Cliente): "); string ur = Console.ReadLine() ?? "";
                        listaU.Add(new Usuario(un, up, ur));
                        break;
                    case "9": sesionActiva = false; break;
                    case "10": sesionActiva = false; appCorriendo = false; break;
                }
            }
            else // Cliente
            {
                gui.MostrarMenuCliente();
                string op = Console.ReadLine() ?? "";
                switch (op)
                {
                    case "1": inv.ListarProductos(); break;
                    case "2":
                        inv.ListarProductos();
                        Console.Write("Nro producto: "); int.TryParse(Console.ReadLine(), out int sel);
                        Producto? p = inv.ObtenerProducto(sel - 1);
                        if (p != null) car.RealizarCompra(p);
                        break;
                    case "3": car.MostrarResumen(); sesionActiva = false; break;
                    case "4": sesionActiva = false; appCorriendo = false; break;
                }
            }
            if (sesionActiva) { Console.WriteLine("\nPresione una tecla..."); Console.ReadKey(); }
        }
    }
}