using Domain.Entities;

namespace Infrastructure.Services.Repositories
{
    public interface IAnnonceRepository
    {
        Task<IEnumerable<Annonce>> GetAnnoncesAsync();
        Task<Annonce?> GetAnnonceByIdAsync(int id);

    }
}
