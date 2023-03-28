using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Application.Common.Interfaces
{
    public interface IGestionAnnonceContext 
    {
         DbSet<Annonce> Annonces { get; }
         DbSet<Photo> Photos { get; }
         DbSet<Utilisateur> Utilisateurs { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
