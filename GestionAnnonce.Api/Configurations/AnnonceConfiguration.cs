using GestionAnnonce.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAnnonce.Api.Configurations
{
    public class AnnonceConfiguration : IEntityTypeConfiguration<Annonce>
    {
        public void Configure(EntityTypeBuilder<Annonce> builder)
        {
            builder.HasKey(annnonce => annnonce.Id);
            builder.Property(a => a.Prix).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(annonce => annonce.Id).ValueGeneratedOnAdd();
            builder.HasMany(annonce => annonce.Photos)
                .WithOne(photo => photo.Annonce)
                .HasForeignKey(photo => photo.AnnonceId);
            builder.HasOne(a => a.Utilisateur)
                .WithOne(u => u.Annonce)
                .HasForeignKey<Utilisateur>(u => u.AnnonceId);
            builder.OwnsOne(annonce => annonce.Adresse);
        }
    }
}
