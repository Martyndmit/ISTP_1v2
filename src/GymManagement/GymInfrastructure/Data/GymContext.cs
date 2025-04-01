using Microsoft.EntityFrameworkCore;
using GymDomain.Entities; // Простір імен з сутностями із GymDomain

namespace GymInfrastructure.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        // DbSet для сутностей
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        // За потреби додайте інші DbSet-и, наприклад, Trainers, Members тощо

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Заповнення даними для таблиці Gyms
            modelBuilder.Entity<Gym>().HasData(
                new Gym
                {
                    GymId = 1,
                    Name = "Main Gym",
                    Location = "Central City",
                    WorkingHours = "6 AM - 10 PM",
                    Capacity = 50
                }
            );

            // Заповнення даними для таблиці Equipment
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment
                {
                    EquipmentId = 1,
                    Name = "Treadmill",
                    Brand = "FitBrand",
                    GymId = 1
                },
                new Equipment
                {
                    EquipmentId = 2,
                    Name = "Dumbbells",
                    Brand = "StrongCorp",
                    GymId = 1
                }
            );
        }

    }
}
