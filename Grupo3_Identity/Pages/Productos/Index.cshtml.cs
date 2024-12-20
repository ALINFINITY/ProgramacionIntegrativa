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
    public class IndexModel : PageModel
    {
        private readonly Grupo3_Identity.Indetity.MyIdentityDBContext _context;

        public IndexModel(Grupo3_Identity.Indetity.MyIdentityDBContext context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Producto = await _context.Producto.ToListAsync();
        }
    }
}
