using Microsoft.AspNetCore.Identity;

namespace Grupo3_Identity.Indetity
{
    public class Usuario : IdentityUser
    {
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  string Telefono { get; set; }
        public  string Direccion { get; set; }
        public  string Password { get; set; }

    }
}
