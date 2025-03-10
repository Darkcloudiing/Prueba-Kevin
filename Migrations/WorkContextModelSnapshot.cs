﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Prueba_Kevin.Migrations
{
    [DbContext(typeof(WorkContext))]
    partial class WorkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prueba_Kevin.Models.AccountTypes", b =>
                {
                    b.Property<int>("idTypeAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTypeAccount"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("InterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OverdraftLimit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idTypeAccount");

                    b.ToTable("TipoDeCuentas");
                });

            modelBuilder.Entity("Prueba_Kevin.Models.Accounts", b =>
                {
                    b.Property<int>("idAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAccount"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("idClient")
                        .HasColumnType("int");

                    b.Property<int>("idTypeAccount")
                        .HasColumnType("int");

                    b.Property<bool>("swActive")
                        .HasColumnType("bit");

                    b.HasKey("idAccount");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Prueba_Kevin.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
