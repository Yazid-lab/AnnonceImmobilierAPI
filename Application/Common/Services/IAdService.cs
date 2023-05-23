using GestionAnnonce.Application.Ads.Commands.CreateAd;
using GestionAnnonce.Application.Ads.Commands.UpdateAd;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Services
{
    public interface IAdService
    {
        Task<bool> AdExists(int adId);
        Task<IEnumerable<AdDto>> GetAds();
        Task<AdDto?> GetAdById(int id);
        public Task<AdDto> AddAd(CreateAdDto ad);
        Task<int> DeleteAd(int adId);
        Task<int> UpdateAd(int adId, UpdateAdDto ad);
    }
}
