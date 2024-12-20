using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Grupo3_Identity.Indetity;
    

namespace Grupo3_Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<Usuario> _userManager;

        [BindProperty]
        public RegisterDTO Register { get; set; }
        public string ReturnURL { get; set; }

        public RegisterModel(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(Register.Password != Register.ConfirmarP)
            {
                throw new Exception("Las contraselas no coincide");
            }

            var nusuario = new Usuario();

            nusuario.UserName = Register.Nombre;
            nusuario.Nombre = Register.Nombre;
            nusuario.Apellido = Register.Apellido;
            nusuario.Email = Register.Email;
            nusuario.Telefono = Register.Telefono;
            nusuario.Direccion = Register.Direccion;
            nusuario.Password = Register.Password;

            var res = await _userManager.CreateAsync(nusuario,Register.Password);

            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                {
                    Console.WriteLine("Error individual: "+error.Description);
                }
            }
            if(ReturnURL == null)
            {
                ReturnURL = "/";
            }

            return LocalRedirect(ReturnURL);
        }
    }
}
