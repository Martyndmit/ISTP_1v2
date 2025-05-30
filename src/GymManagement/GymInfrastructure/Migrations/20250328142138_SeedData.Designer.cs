﻿// <auto-generated />
using GymInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymInfrastructure.Migrations
{
    [DbContext(typeof(GymContext))]
    [Migration("20250328142138_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymDomain.Entities.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentId");

                    b.HasIndex("GymId");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            EquipmentId = 1,
                            Brand = "FitBrand",
                            GymId = 1,
                            Name = "Treadmill"
                        },
                        new
                        {
                            EquipmentId = 2,
                            Brand = "StrongCorp",
                            GymId = 1,
                            Name = "Dumbbells"
                        });
                });

            modelBuilder.Entity("GymDomain.Entities.Gym", b =>
                {
                    b.Property<int>("GymId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GymId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GymId");

                    b.ToTable("Gyms");

                    b.HasData(
                        new
                        {
                            GymId = 1,
                            Capacity = 50,
                            Location = "Central City",
                            Name = "Main Gym",
                            WorkingHours = "6 AM - 10 PM"
                        });
                });

            modelBuilder.Entity("GymDomain.Entities.Equipment", b =>
                {
                    b.HasOne("GymDomain.Entities.Gym", "Gym")
                        .WithMany("Equipment")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("GymDomain.Entities.Gym", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
