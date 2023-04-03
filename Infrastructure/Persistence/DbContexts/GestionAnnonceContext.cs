using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using GestionAnnonce.Application.Common.Interfaces;

namespace Infrastructure.Persistence.DbContexts
{
    public class GestionAnnonceContext : DbContext, IGestionAnnonceContext
    {
        public DbSet<Annonce> Annonces => Set<Annonce>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<Utilisateur> Utilisateurs => Set<Utilisateur>();


        public GestionAnnonceContext(DbContextOptions<GestionAnnonceContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnnonceConfiguration());
            modelBuilder.ApplyConfiguration(new UtilisateurConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());

            modelBuilder.Entity<Photo>()
                .HasData(
                    new Photo(1, "url1", "description1", 1)
                );
            modelBuilder.Entity<Utilisateur>()
                .HasData(
                    new Utilisateur(1, "nom1", "prenom1", "email1", "tel1"));
            //modelBuilder.Entity<Annonces>()
            //    .HasData(new Annonces("annonce1")
            //    {
            //        Id = 1,
            //        Description = "desc1",
            //        Prix = 111,
            //        Superficie = 1,
            //        NbPieces = 2,
            //        DatePublication = DateTime.Now,
            //        UtilisateurId = 1,
            //    });
            //modelBuilder.Entity<Annonces>().OwnsOne(annonce => annonce.Adresse).HasData(new
            //{
            //    AnnonceId = 1,
            //    CodePostal = "code",
            //    Latitude = (double)11,
            //    Longitude = (double)22,
            //    Pays = "tunisia",
            //    Rue = "rue",
            //    Ville = "tunis"
            //});
            modelBuilder.Entity<Annonce>(a =>
            {
                a.HasData(new
                {
                    Id = 1,
                    Titre = "annonce 1",
                    Description = "desc1",
                    Prix = (decimal)111,
                    Superficie = 1,
                    NbPieces = 2,
                    DatePublication = DateTime.Now,
                    UtilisateurId = 1,
                });
                a.OwnsOne(annonce => annonce.Adresse).HasData(new
                {

                    AnnonceId = 1,
                    CodePostal = "code",
                    Latitude = (double)11,
                    Longitude = (double)22,
                    Pays = "tunisia",
                    Rue = "rue",
                    Ville = "tunis"
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
