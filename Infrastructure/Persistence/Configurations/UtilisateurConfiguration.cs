using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UtilisateurConfiguration : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Prenom).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Nom).IsRequired().HasMaxLength(50);
            //builder.HasOne(u => u.Annonces)
            //    .WithOne(a => a.Utilisateur)
            //    .HasForeignKey<Annonces>(a => a.UtilisateurId);
            builder.HasMany<Annonce>(u => u.Annonces)
                .WithOne(a => a.Utilisateur)
                .HasForeignKey(a => a.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
