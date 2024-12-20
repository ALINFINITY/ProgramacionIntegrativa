using Grupo3_Identity.Indetity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grupo3_Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public LoginModel( SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public LoginDTO Login {  get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Valido que exista el usuario 
            
            var user = await _userManager.FindByEmailAsync(Login.Email);
            if (user == null)
            {
                throw new Exception("No existe el usuario");
            }

            //Valido el inicio de sesion
            var res = await _signInManager.PasswordSignInAsync(user, Login.Password, true, true);
            
            if (!res.Succeeded)
            {
                throw new Exception("Error al iniciar sesión");
            }
            return LocalRedirect("/");
        }
    }
}
