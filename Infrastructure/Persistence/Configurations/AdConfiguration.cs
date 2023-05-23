using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(annnonce => annnonce.Id);
            builder.Property(a => a.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(annonce => annonce.Id).ValueGeneratedOnAdd();
            builder.HasMany(annonce => annonce.Photos)
                .WithOne(photo => photo.Ad)
                .HasForeignKey(photo => photo.AdId);
            //builder.HasOne(a => a.User)
            //    .WithOne(u => u.Ads)
            //    .HasForeignKey<User>(u => u.Id);
            builder.OwnsOne(annonce => annonce.Address);
        }
    }
}
