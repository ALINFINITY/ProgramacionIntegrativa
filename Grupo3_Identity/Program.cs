using Grupo3_Identity.Indetity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


//Cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyIdentityDBContext>(o => o.UseSqlServer(connectionString));

//Identity
builder.Services.AddIdentity<Usuario, IdentityRole>(
        options =>
        {
            //Contraseña 
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 4; //Contraseña de minimo 4 digitos

            //Email
            options.User.RequireUniqueEmail = false;

            //Confirmacion email
            options.SignIn.RequireConfirmedEmail = false;

            //Lockout
            options.Lockout.AllowedForNewUsers = true; //Se aplica a usuarios nuevos
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //Bloqueo de 5 minutos
            options.Lockout.MaxFailedAccessAttempts = 5; //Numero maximo de intentos fallidos de iicio de sesion
        }
    ).
    AddDefaultTokenProviders().
    AddEntityFrameworkStores<MyIdentityDBContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
