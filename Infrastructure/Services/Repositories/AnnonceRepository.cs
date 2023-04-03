using Azure.Core;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories
{
    public class AnnonceRepository : IAnnonceRepository
    {

        private readonly GestionAnnonceContext _context;

        public AnnonceRepository(GestionAnnonceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AnnonceExists(int id)
        {

            var entity = await _context.Annonces.AsNoTracking().Where(annonce => annonce.Id == id)
                .FirstOrDefaultAsync();
            return entity != null;
        }

        public async Task<IEnumerable<Annonce>> GetAnnoncesAsync(CancellationToken cancellationToken)
        {
            return await _context.Annonces.Include(a => a.Photos).ToListAsync(cancellationToken);
        }

        public async Task<Annonce?> GetAnnonceByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entityAnnonce = await _context.Annonces.Include(annonce => annonce.Photos)
                .FirstOrDefaultAsync(an => an.Id == id,
                    cancellationToken);
            return entityAnnonce;
        }

        public async Task AddAnnonceAsync(Annonce annonceEntity, CancellationToken cancellationToken)
        {

            await _context.Annonces.AddAsync(annonceEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAnnonceAsync(int requestId, CancellationToken cancellationToken)
        {
            if (await AnnonceExists(requestId) == false)
            {
                return -1;
            }

            await _context.Annonces.Where(an => an.Id == requestId).ExecuteDeleteAsync(cancellationToken);
            return requestId;
        }

        public async Task<int> UpdateAnnonceAsync(int requestAnnonceid, Annonce requestAnnonce, CancellationToken cancellationToken)
        {
            if (await AnnonceExists(requestAnnonceid) == false)
            {
                return -1;
            }
            _context.Annonces.Update(requestAnnonce);
            await _context.SaveChangesAsync(cancellationToken);
            return requestAnnonceid;
        }
    }
}
