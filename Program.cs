using System;
using System.Collections.Generic;
using MiTienda;

namespace MiTienda
{
    class Program
    {
        static void Main()
        {
            Inventario inv = new Inventario();
            Presentacion gui = new Presentacion();
            
            inv.AgregarProducto(new ProductoFisico("Monitor 24'", 1200, 5));
            inv.AgregarProducto(new ProductoDigital("Licencia Windows 11", 150, "W269N-WFGWX-YVC9B"));
            inv.AgregarProducto(new ProductoFisico("Mouse Gamer", 80, 0)); 
            inv.AgregarProducto(new ProductoDigital("Suscripción GamePass", 70, "GP-998-XYZ"));

            List<Usuario> usuarios = new List<Usuario> {
                new Usuario("admin", "123", "Admin"),
                new Usuario("cliente", "456", "Cliente")
            };

            bool tiendaAbierta = true;

            while (tiendaAbierta)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("      SISTEMA DE TIENDA CONSOLA       ");
                Console.WriteLine("======================================");
                
                Examen.EjecutarPrueba();
                Console.WriteLine("--------------------------------------");

                Console.Write("Usuario: "); string uInput = Console.ReadLine() ?? "";
                Console.Write("Password: "); string pInput = Console.ReadLine() ?? "";

                Usuario? user = usuarios.Find(x => x.Nombre == uInput && x.Password == pInput);

                if (user != null)
                {
                    if (user.Rol == "Admin")
                        MenuAdmin(inv, gui, ref tiendaAbierta);
                    else
                        MenuCliente(inv, gui, ref tiendaAbierta);
                }
                else
                {
                    Console.WriteLine("\nCredenciales inválidas. Enter para reintentar...");
                    Console.ReadLine();
                }
            }
        }

        static void MenuAdmin(Inventario inv, Presentacion gui, ref bool abierta)
        {
            bool sesion = true;
            while (sesion)
            {
                Console.Clear();
                gui.MostrarMenuAdmin();
                string op = Console.ReadLine() ?? "";

                switch (op)
                {
                    case "1":
                        inv.ListarProductos();
                        Console.WriteLine("\nPresione Enter para continuar");
                        Console.ReadLine();
                        break;
                    case "9":
                        sesion = false;
                        break;
                    case "10":
                        sesion = false;
                        abierta = false;
                        break;
                }
            }
        }

        static void MenuCliente(Inventario inv, Presentacion gui, ref bool abierta)
        {
            Carrito car = new Carrito();
            Cliente clienteActivo = new Cliente("Jorge", 1200, true);
            bool sesion = true;

            while (sesion)
            {
                Console.Clear();
                Console.WriteLine($"BIENVENIDO, {clienteActivo.Nombre.ToUpper()}");
                gui.MostrarMenuCliente();
                string op = Console.ReadLine() ?? "";

                if (op == "1")
                {
                    inv.ListarProductos();
                    Console.WriteLine("\nPresione Enter para volver");
                    Console.ReadLine();
                }
                else if (op == "2")
                {
                    inv.ListarProductos();
                    Console.Write("\nSeleccione el número del producto para agregar al carrito: ");
                    if (int.TryParse(Console.ReadLine(), out int idx))
                    {
                        Producto? prod = inv.ObtenerProducto(idx - 1);
                        if (prod != null)
                        {
                            car.Agregar(prod);
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado");
                        }
                    }
                    Console.ReadLine();
                }
                else if (op == "3")
                {
                    bool comprado = car.MostrarResumenYConfirmar(clienteActivo);
                    if (comprado)
                    {
                        Console.WriteLine("\nCerrando sesión por seguridad tras la compra");
                        Console.ReadLine();
                        sesion = false;
                    }
                    else
                    {
                        Console.WriteLine("\nPresione Enter para seguir navegando");
                        Console.ReadLine();
                    }
                }
                else if (op == "4")
                {
                    sesion = false;
                    abierta = false;
                }
            }
        }
    }
}