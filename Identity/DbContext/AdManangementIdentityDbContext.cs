using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DbContext
{
    public class AdManangementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AdManangementIdentityDbContext(DbContextOptions<AdManangementIdentityDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AdManangementIdentityDbContext).Assembly);
        }

    }
}
