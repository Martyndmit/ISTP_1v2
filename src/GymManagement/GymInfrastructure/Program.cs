using Microsoft.EntityFrameworkCore;
using GymManagementMVC.Data;
using GymManagementMVC.Models;
using Microsoft.AspNetCore.Identity;
using GymInfrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Реєструємо контекст даних для основного застосунку (наприклад, GymContext) – вже має бути
builder.Services.AddDbContext<GymContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Додаємо Identity з використанням IdentityContext
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Підключаємо middleware автентифікації та авторизації
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ініціалізація ролей та адміністратора (реалізуйте клас RoleInitializer згідно з прикладом)
/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleInitializer.InitializeAsync(userManager, roleManager);
}*/

app.Run();
