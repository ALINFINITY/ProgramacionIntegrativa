using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grupo3_Identity.Indetity;
using Grupo3_Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace Grupo3_Identity.Pages.Productos
{
    [Authorize] //Requiere iniciar sesion
    public class DetailsModel : PageModel
    {
        private readonly Grupo3_Identity.Indetity.MyIdentityDBContext _context;

        public DetailsModel(Grupo3_Identity.Indetity.MyIdentityDBContext context)
        {
            _context = context;
        }

        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                Producto = producto;
            }
            return Page();
        }
    }
}
