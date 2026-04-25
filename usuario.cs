namespace MiTienda
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public Usuario(string nombre, string password, string rol)
        {
            Nombre = nombre;
            Password = password;
            Rol = rol;
        }
    }
}