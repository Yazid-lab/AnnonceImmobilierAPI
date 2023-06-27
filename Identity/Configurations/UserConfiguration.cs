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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = "1",
                    LastName = "Bougrine",
                    FirstName = "Yazid",
                    Email = "email@gmail.com",
                    NormalizedEmail = "EMAIL@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "password"),
                    EmailConfirmed = true

                },
                new User
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
