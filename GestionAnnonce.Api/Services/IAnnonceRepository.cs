using GestionAnnonce.Api.Domain.Entities;

namespace GestionAnnonce.Api.Services
{
    public interface IAnnonceRepository
    {
        Task<IEnumerable<Annonce>> GetAnnoncesAsync();
        Task<Annonce?> GetAnnonceByIdAsync(int id);

    }
}
