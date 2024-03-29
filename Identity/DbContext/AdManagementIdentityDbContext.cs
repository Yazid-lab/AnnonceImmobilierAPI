﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Identity.DbContext
{
    public class AdManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<Photo> Photos => Set<Photo>();
        public AdManagementIdentityDbContext(DbContextOptions<AdManagementIdentityDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ad>().Property(ad => ad.AdType).HasConversion<string>();
            builder.Entity<Photo>()
                .HasData(
                    new Photo(1, "url1", "description1", 1)
                );
            builder.Entity<Ad>(a =>
            {
                a.HasData(new
                {
                    Id = 1,
                    Title = "Ad 1",
                    Description = "desc1",
                    Price = (decimal)111,
                    Area = 1,
                    NbRooms = 2,
                    DatePublication = DateTime.Now,
                    ApplicationUserId = "1",
                    IsPublished = false,
                    AdType = AdType.Rent
                });
                a.OwnsOne(annonce => annonce.Address).HasData(new
                {

                    AdId = 1,
                    PostCode = "code",
                    Latitude = (double)11,
                    Longitude = (double)22,
                    Country = "tunisia",
                    Street = "rue",
                    Town = "tunis"
                });
            });
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AdManagementIdentityDbContext).Assembly);
        }

    }
}
