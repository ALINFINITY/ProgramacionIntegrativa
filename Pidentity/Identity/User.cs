using Microsoft.AspNetCore.Identity;
namespace Pidentity.Identity
{
    public class User: IdentityUser
    {
        public string nombre { get; set}
        public string apellido;
        public string telefono;
        public string direccion;
        public string password;

    }
}
