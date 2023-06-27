using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using GestionAnnonce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbContexts
{
    public class AdManagementContext : IdentityDbContext<User>, IAdManagementContext
    {
        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<User> Users => Set<User>();


        public AdManagementContext(DbContextOptions<AdManagementContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());

            modelBuilder.Entity<Photo>()
                .HasData(
                    new Photo(1, "url1", "description1", 1)
                );
            modelBuilder.Entity<User>()
                .HasData(
                    new User("1", "lastName", "firstName", "email1", "tel1"));
            //modelBuilder.Entity<Ads>()
            //    .HasData(new Ads("annonce1")
            //    {
            //        Id = 1,
            //        Description = "desc1",
            //        Price = 111,
            //        Area = 1,
            //        NbRooms = 2,
            //        DatePublication = DateTime.Now,
            //        UserId = 1,
            //    });
            //modelBuilder.Entity<Ads>().OwnsOne(Ad => Ad.Address).HasData(new
            //{
            //    AdId = 1,
            //    PostCode = "code",
            //    Latitude = (double)11,
            //    Longitude = (double)22,
            //    Country = "tunisia",
            //    Street = "rue",
            //    Town = "tunis"
            //});
            modelBuilder.Entity<Ad>(a =>
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
                    UserId = 1,
                    IsPublished = false,
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

            base.OnModelCreating(modelBuilder);
        }

        // TODO: If domain events are needed, Override this method and add some event dispatching using MediatR
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
