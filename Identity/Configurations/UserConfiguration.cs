using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "1",
                    LastName = "Bougrine",
                    FirstName = "Yazid",
                    Email = "email@gmail.com",
                    NormalizedEmail = "EMAIL@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "password"),
                    EmailConfirmed = true

                },
                new ApplicationUser
                {
                    Id = "2",
                    LastName = "Doe",
                    FirstName = "John",
                    Email = "john@doe.com",
                    NormalizedEmail = "JOHN@DOE.COM",
                    PasswordHash = hasher.HashPassword(null, "johndoe"),
                    EmailConfirmed = true,
                });
        }
    }
}
