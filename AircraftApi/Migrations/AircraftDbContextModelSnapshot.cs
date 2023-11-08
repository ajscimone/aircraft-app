﻿// <auto-generated />
using AircraftApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AircraftApi.Migrations
{
    [DbContext(typeof(AircraftDbContext))]
    partial class AircraftDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AircraftApi.Models.Domain.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AircraftModelId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TailNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AircraftModelId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("AircraftApi.Models.Domain.AircraftManufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AircraftManufacturers");
                });

            modelBuilder.Entity("AircraftApi.Models.Domain.AircraftModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AircraftManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AircraftManufacturerId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AircraftModels");
                });

            modelBuilder.Entity("AircraftApi.Models.Domain.Aircraft", b =>
                {
                    b.HasOne("AircraftApi.Models.Domain.AircraftModel", "AircraftModel")
                        .WithMany()
                        .HasForeignKey("AircraftModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AircraftModel");
                });

            modelBuilder.Entity("AircraftApi.Models.Domain.AircraftModel", b =>
                {
                    b.HasOne("AircraftApi.Models.Domain.AircraftManufacturer", "AircraftManufacturer")
                        .WithMany()
                        .HasForeignKey("AircraftManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AircraftManufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}