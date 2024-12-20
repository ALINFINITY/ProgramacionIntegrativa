using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Grupo3_Identity.Models;
namespace Grupo3_Identity.Indetity
{
    public class MyIdentityDBContext : IdentityDbContext<Usuario,IdentityRole,String>
    {

        public MyIdentityDBContext(DbContextOptions<MyIdentityDBContext> options) 
            :base(options) 
        { 
        }
        public DbSet<Grupo3_Identity.Models.Producto> Producto { get; set; } = default!;

    }
}
