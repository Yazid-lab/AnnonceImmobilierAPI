using GestionAnnonce.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestionAnnonce.Api.DbContexts
{
    public class GestionAnnonceContext : DbContext
    {
        public DbSet<Annonce> Annonces { get; set; } = null!;
        //public DbSet<Adresse> Adresses { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; } = null!;


        public GestionAnnonceContext(DbContextOptions<GestionAnnonceContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Photo>().HasData(new Photo(1, "yazid.com", "yazid photo", 1));
            ////modelBuilder.Entity<Adresse>().HasData(new Adresse(1, "rue1", "ville1", "code1", "pays1", 23, 22));
            //modelBuilder.Entity<Utilisateur>()
            //    .HasData(new Utilisateur("bougrine", "yazid", "yazid@email.com", "123421431234"));
            //modelBuilder.Entity<Annonce>().HasData(new Annonce("annonce1")
            //{
            //    Adresse = new Adresse(1, "rue1", "ville1", "code1", "pays1", 23, 22),
            //    Description = "description",
            //    DatePublication = DateTime.Now,
            //    NbPieces = 2,
            //    Prix = 22,
            //    UtilisateurId = 1,

            //});
            base.OnModelCreating(modelBuilder);
        }
    }
}
