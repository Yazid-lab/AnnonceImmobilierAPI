using GestionAnnonce.Api.Domain;

namespace GestionAnnonce.Api.Services
{
    public interface IAnnonceRepository
    {
        Task<IEnumerable<Annonce>> GetAnnoncesAsync();
        Task<Annonce?> GetAnnonceByIdAsync(int id);

    }
}
