using GestionAnnonce.Api.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionAnnonce.Api.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {

            builder.HasKey(photo => photo.Id);
            builder.Property(photo => photo.Id).ValueGeneratedOnAdd();
        }
    }
}
