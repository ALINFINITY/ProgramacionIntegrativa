using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grupo3_Identity.Indetity;
using Grupo3_Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace Grupo3_Identity.Pages.Productos
{
    [Authorize] //Requiere iniciar sesion
    public class CreateModel : PageModel
    {
        private readonly Grupo3_Identity.Indetity.MyIdentityDBContext _context;

        public CreateModel(Grupo3_Identity.Indetity.MyIdentityDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Producto Producto { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Producto.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
