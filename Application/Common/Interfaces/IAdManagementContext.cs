using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Application.Common.Interfaces
{
    public interface IAdManagementContext 
    {
         DbSet<Ad> Ads { get; }
         DbSet<Photo> Photos { get; }
         DbSet<User> Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
