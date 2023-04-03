using Domain.Entities;

namespace GestionAnnonce.Application.Common.Interfaces
{
    public interface IAnnonceRepository
    {
        Task<bool> AnnonceExists(int id);
        Task<IEnumerable<Annonce>> GetAnnoncesAsync(CancellationToken cancellationToken);
        Task<Annonce?> GetAnnonceByIdAsync(int id, CancellationToken cancellationToken);

        Task AddAnnonceAsync(Annonce annonceEntity, CancellationToken cancellationToken);
        Task<int> DeleteAnnonceAsync(int requestId, CancellationToken cancellationToken);
        Task<int> UpdateAnnonceAsync(int requestAnnonceid, Annonce requestAnnonce, CancellationToken cancellationToken);
    }
}
