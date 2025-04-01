using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "GymId", "Capacity", "Location", "Name", "WorkingHours" },
                values: new object[] { 1, 50, "Central City", "Main Gym", "6 AM - 10 PM" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "EquipmentId", "Brand", "GymId", "Name" },
                values: new object[,]
                {
                    { 1, "FitBrand", 1, "Treadmill" },
                    { 2, "StrongCorp", 1, "Dumbbells" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "EquipmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "GymId",
                keyValue: 1);
        }
    }
}
