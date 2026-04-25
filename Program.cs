using System;
using MiTienda;
partial class Program
{
    static void Main()
    {
        // Instanciamos las clases
        Inventario inv = new Inventario();
        Carrito car = new Carrito();
        Presentacion gui = new Presentacion(); 
        // Creamos productos
        Producto p1 = new Producto("TEC01", "Teclado", 150.50);
        Producto p2 = new Producto("MOU01", "Mouse", 80.00);

        // Llenamos inventario
        inv.agregarproducto(p1);
        inv.agregarproducto(p2);

        // Proceso de compra
        gui.MostrarTitulo("Inventario");
        Console.WriteLine("Productos en stock: " + inv.stockdeproductos());

        car.agregaralcarrito(p1);
        car.agregaralcarrito(p2);

        gui.MostrarTitulo("Tu Carrito");
        Console.WriteLine("Cantidad: " + car.cantidaddeproductos());
        Console.WriteLine("Total: Bs. " + car.mostrartotal());

        Console.ReadLine();
    }
}