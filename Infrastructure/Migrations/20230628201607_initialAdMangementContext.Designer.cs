﻿// <auto-generated />
using System;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AdManagementContext))]
    [Migration("20230628201607_initialAdMangementContext")]
    partial class initialAdMangementContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<int>("NbRooms")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Ads");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Area = 1,
                            DatePublication = new DateTime(2023, 6, 28, 21, 16, 6, 951, DateTimeKind.Local).AddTicks(3312),
                            Description = "desc1",
                            IsPublished = false,
                            NbRooms = 2,
                            Price = 111m,
                            Title = "Ad 1",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdId = 1,
                            Description = "description1",
                            Url = "url1"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ad", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithMany("Ads")
                        .HasForeignKey("UserId1");

                    b.OwnsOne("Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("AdId")
                                .HasColumnType("int");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Town")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AdId");

                            b1.ToTable("Ads");

                            b1.WithOwner()
                                .HasForeignKey("AdId");

                            b1.HasData(
                                new
                                {
                                    AdId = 1,
                                    Country = "tunisia",
                                    Latitude = 11.0,
                                    Longitude = 22.0,
                                    PostCode = "code",
                                    Street = "rue",
                                    Town = "tunis"
                                });
                        });

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.HasOne("Domain.Entities.Ad", "Ad")
                        .WithMany("Photos")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("Domain.Entities.Ad", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Ads");
                });
#pragma warning restore 612, 618
        }
    }
}
