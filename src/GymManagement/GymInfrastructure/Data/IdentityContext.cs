using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymManagementMVC.Models; // Простір імен вашого User

namespace GymManagementMVC.Data
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            // Якщо бажаєте автоматично створювати БД, можна використати Database.EnsureCreated();
        }
    }
}

