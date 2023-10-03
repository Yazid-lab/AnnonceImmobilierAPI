using Domain.Entities;
using GestionAnnonce.Application.Ads.Commands.UpdateAd;
using GestionAnnonce.Application.Common.Interfaces;
using Identity.DbContext;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories
{
    public class AdRepository : IAdRepository
    {

        private readonly AdManagementIdentityDbContext _context;

        public AdRepository(AdManagementIdentityDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AdExists(int id)
        {

            var entity = await _context.Ads.AsNoTracking().Where(annonce => annonce.Id == id)
                .FirstOrDefaultAsync();
            return entity != null;
        }

        public async Task<IEnumerable<Ad>> GetAdsAsync(CancellationToken cancellationToken)
        {
            return await _context.Ads.Include(ad => ad.Address).Include(a => a.Photos).ToListAsync(cancellationToken);
        }

        public async Task<Ad?> GetAdByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entityAd = await _context.Ads.Include(ad => ad.Photos)
                .FirstOrDefaultAsync(an => an.Id == id,
                    cancellationToken);
            return entityAd;
        }

        public async Task AddAdAsync(Ad adEntity, CancellationToken cancellationToken)
        {

            await _context.Ads.AddAsync(adEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAdAsync(int requestId, CancellationToken cancellationToken)
        {
            if (await AdExists(requestId) == false)
            {
                return -1;
            }

            await _context.Ads.Where(an => an.Id == requestId).ExecuteDeleteAsync(cancellationToken);
            return requestId;
        }

        public async Task<int> UpdateAdAsync(int requestAdId, Ad requestAd, CancellationToken cancellationToken)
        {
            if (await AdExists(requestAdId) == false)
            {
                return -1;
            }
            var savedAd = await GetAdByIdAsync(requestAdId, cancellationToken);
            _context.Entry(savedAd).State = EntityState.Detached;
            var numberOfRequestedPhotos = requestAd.Photos.Count;
            var numberOfSavedPhotos = savedAd!.Photos.Count;
            _context.Ads.Update(requestAd);
            if (numberOfRequestedPhotos < numberOfSavedPhotos)
            {
                var savedPhotosIds = savedAd.Photos.Select(p => p.Id).ToList();
                var photoIdsToRemove = savedPhotosIds.Except(requestAd.Photos.Select(p => p.Id)).ToList();
                var photosToRemove = _context.Photos
                    .Where(p => photoIdsToRemove.Contains(p.Id))
                    .ToList();
                _context.Photos.RemoveRange(photosToRemove);
                await _context.SaveChangesAsync(cancellationToken);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return requestAdId;
        }
    }
}
