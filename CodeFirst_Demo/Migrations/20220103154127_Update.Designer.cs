﻿// <auto-generated />
using System;
using CodeFirst_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirst_Demo.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20220103154127_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeFirst_Demo.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdFournisseur")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbrProduits")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFournisseur");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CodeFirst_Demo.Models.Fournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("CodeFirst_Demo.Models.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategorie")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategorie");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("CodeFirst_Demo.Models.Categorie", b =>
                {
                    b.HasOne("CodeFirst_Demo.Models.Fournisseur", "Fournisseur")
                        .WithMany("AllCategories")
                        .HasForeignKey("IdFournisseur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("CodeFirst_Demo.Models.Produit", b =>
                {
                    b.HasOne("CodeFirst_Demo.Models.Categorie", "Categorie")
                        .WithMany("AllProduits")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("CodeFirst_Demo.Models.Categorie", b =>
                {
                    b.Navigation("AllProduits");
                });

            modelBuilder.Entity("CodeFirst_Demo.Models.Fournisseur", b =>
                {
                    b.Navigation("AllCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
