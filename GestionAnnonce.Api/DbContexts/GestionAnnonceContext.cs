using System.Reflection;
using GestionAnnonce.Api.Configurations;
using GestionAnnonce.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestionAnnonce.Api.DbContexts
{
    public class GestionAnnonceContext : DbContext
    {
        public DbSet<Annonce> Annonces { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; } = null!;


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
            //modelBuilder.Entity<Annonce>()
            //    .HasData(new Annonce("annonce1")
            //    {
            //        Id = 1,
            //        Description = "desc1",
            //        Prix = 111,
            //        Superficie = 1,
            //        NbPieces = 2,
            //        DatePublication = DateTime.Now,
            //        UtilisateurId = 1,
            //    });
            //modelBuilder.Entity<Annonce>().OwnsOne(annonce => annonce.Adresse).HasData(new
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
                a.HasData(new Annonce
                {
                    Id = 1,
                    Titre = "annonce 1",
                    Description = "desc1",
                    Prix = 111,
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
    }
}
