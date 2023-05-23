using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories
{
    public class AdRepository : IAdRepository
    {

        private readonly AdManagementContext _context;

        public AdRepository(AdManagementContext context)
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
            return await _context.Ads.Include(ad =>ad.Address).Include(a => a.Photos).ToListAsync(cancellationToken);
        }

        public async Task<Ad?> GetAdByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entityAnnonce = await _context.Ads.Include(annonce => annonce.Photos)
                .FirstOrDefaultAsync(an => an.Id == id,
                    cancellationToken);
            return entityAnnonce;
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
            _context.Ads.Update(requestAd);
            await _context.SaveChangesAsync(cancellationToken);
            return requestAdId;
        }
    }
}
