using System;
using System.Collections.Generic;

namespace MiTienda
{
    public class GestionUsuarios
    {
        public void ListarUsuarios(List<Usuario> lista)
        {
            Console.WriteLine("\n--- LISTA DE USUARIOS ---");
            foreach (var u in lista) Console.WriteLine($"- {u.Nombre} [{u.Rol}]");
        }

        public void AgregarUsuario(List<Usuario> lista)
        {
            Console.Write("Nombre: "); string n = Console.ReadLine() ?? "";
            Console.Write("Pass: "); string p = Console.ReadLine() ?? "";
            Console.Write("Rol (Admin/Cliente): "); string r = Console.ReadLine() ?? "";
            lista.Add(new Usuario(n, p, r));
            Console.WriteLine("Usuario registrado.");
        }

        public void ActualizarUsuario(List<Usuario> lista)
        {
            Console.Write("Nombre del usuario a editar: "); string busca = Console.ReadLine() ?? "";
            Usuario? u = lista.Find(x => x.Nombre == busca);
            if (u != null) {
                Console.Write("Nuevo Pass: "); u.Password = Console.ReadLine() ?? "";
                Console.Write("Nuevo Rol: "); u.Rol = Console.ReadLine() ?? "";
                Console.WriteLine("Usuario actualizado.");
            }
        }

        public void EliminarUsuario(List<Usuario> lista)
        {
            Console.Write("Nombre a eliminar: "); string busca = Console.ReadLine() ?? "";
            lista.RemoveAll(x => x.Nombre == busca);
            Console.WriteLine("Usuario eliminado.");
        }
    }
}