using System;
using System.Collections.Generic;
using MiTienda;

class Program
{
    static void Main()
    {
        Presentacion gui = new Presentacion();
        Inventario inv = new Inventario();
        Carrito car = new Carrito();
        GestionUsuarios gus = new GestionUsuarios();

        List<Usuario> usuarios = new List<Usuario> {
            new Usuario("jorge", "123", "Admin"),
            new Usuario("user", "456", "Cliente")
        };

        bool appCorriendo = true;
        while (appCorriendo)
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN TIENDA CONSOLA ===");
            Console.Write("Usuario: "); string uIn = Console.ReadLine() ?? "";
            Console.Write("Pass: "); string pIn = Console.ReadLine() ?? "";

            Usuario? user = usuarios.Find(x => x.Nombre == uIn && x.Password == pIn);

            if (user != null)
            {
                bool sesionActiva = true;
                while (sesionActiva)
                {
                    Console.Clear();
                    if (user.Rol == "Admin") {
                        gui.MostrarMenuAdmin();
                        string op = Console.ReadLine() ?? "";
                        switch (op) {
                            case "1": inv.ListarProductos(); break;
                            case "2": 
                                Console.Write("Nombre: "); string n = Console.ReadLine() ?? "";
                                Console.Write("Precio: "); double.TryParse(Console.ReadLine(), out double p);
                                inv.AgregarProducto(new Producto("0", n, p)); break;
                            case "3":
                                inv.ListarProductos();
                                Console.Write("Nro a actualizar: "); int.TryParse(Console.ReadLine(), out int iU);
                                Console.Write("Nuevo nombre: "); string nn = Console.ReadLine() ?? "";
                                Console.Write("Nuevo precio: "); double.TryParse(Console.ReadLine(), out double np);
                                inv.ActualizarProducto(iU-1, nn, np); break;
                            case "4":
                                inv.ListarProductos();
                                Console.Write("Nro a eliminar: "); int.TryParse(Console.ReadLine(), out int iE);
                                inv.EliminarProducto(iE-1); break;
                            case "5": gus.ListarUsuarios(usuarios); break;
                            case "6": gus.AgregarUsuario(usuarios); break;
                            case "7": gus.ActualizarUsuario(usuarios); break;
                            case "8": gus.EliminarUsuario(usuarios); break;
                            case "9": sesionActiva = false; break; // Cerrar sesión
                            case "10": sesionActiva = false; appCorriendo = false; break; // Cerrar Tienda
                        }
                    } else {
                        gui.MostrarMenuCliente();
                        string op = Console.ReadLine() ?? "";
                        switch (op) {
                            case "1": inv.ListarProductos(); break;
                            case "2":
                                inv.ListarProductos();
                                Console.Write("Nro producto para comprar: "); int.TryParse(Console.ReadLine(), out int sel);
                                Producto? prod = inv.ObtenerProducto(sel-1);
                                if (prod != null) car.RealizarCompra(prod); break;
                            case "3": car.MostrarResumen(); sesionActiva = false; break; // Cerrar sesión
                            case "4": sesionActiva = false; appCorriendo = false; break; // Cerrar Tienda
                        }
                    }
                    if (sesionActiva) { Console.WriteLine("\nPresione una tecla..."); Console.ReadKey(); }
                }
            }
            else {
                Console.WriteLine("Error. Presione una tecla..."); Console.ReadKey();
            }
        }
    }
}