﻿// <auto-generated />
using System;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(GestionAnnonceContext))]
    partial class GestionAnnonceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Annonce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbPieces")
                        .HasColumnType("int");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Superficie")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId")
                        .IsUnique();

                    b.ToTable("Annonces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DatePublication = new DateTime(2023, 3, 30, 16, 44, 53, 623, DateTimeKind.Local).AddTicks(2144),
                            Description = "desc1",
                            NbPieces = 2,
                            Prix = 111m,
                            Superficie = 1,
                            Titre = "annonce 1",
                            UtilisateurId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnnonceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnnonceId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnnonceId = 1,
                            Description = "description1",
                            Url = "url1"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "email1",
                            Nom = "nom1",
                            Prenom = "prenom1",
                            Telephone = "tel1"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Annonce", b =>
                {
                    b.HasOne("Domain.Entities.Utilisateur", "Utilisateur")
                        .WithOne("Annonce")
                        .HasForeignKey("Domain.Entities.Annonce", "UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Adresse", "Adresse", b1 =>
                        {
                            b1.Property<int>("AnnonceId")
                                .HasColumnType("int");

                            b1.Property<string>("CodePostal")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.Property<string>("Pays")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Rue")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Ville")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnnonceId");

                            b1.ToTable("Annonces");

                            b1.WithOwner()
                                .HasForeignKey("AnnonceId");

                            b1.HasData(
                                new
                                {
                                    AnnonceId = 1,
                                    CodePostal = "code",
                                    Latitude = 11.0,
                                    Longitude = 22.0,
                                    Pays = "tunisia",
                                    Rue = "rue",
                                    Ville = "tunis"
                                });
                        });

                    b.Navigation("Adresse");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.HasOne("Domain.Entities.Annonce", "Annonce")
                        .WithMany("Photos")
                        .HasForeignKey("AnnonceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Annonce");
                });

            modelBuilder.Entity("Domain.Entities.Annonce", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Domain.Entities.Utilisateur", b =>
                {
                    b.Navigation("Annonce");
                });
#pragma warning restore 612, 618
        }
    }
}
