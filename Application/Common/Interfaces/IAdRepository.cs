using Domain.Entities;

namespace GestionAnnonce.Application.Common.Interfaces
{
    public interface IAdRepository
    {
        Task<bool> AdExists(int id);
        Task<IEnumerable<Ad>> GetAdsAsync(CancellationToken cancellationToken);
        Task<Ad?> GetAdByIdAsync(int id, CancellationToken cancellationToken);

        Task AddAdAsync(Ad adEntity, CancellationToken cancellationToken);
        Task<int> DeleteAdAsync(int requestId, CancellationToken cancellationToken);
        Task<int> UpdateAdAsync(int requestAdId, Ad requestAd, CancellationToken cancellationToken);
    }
}
