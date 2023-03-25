using GestionAnnonce.Api.DbContexts;
using GestionAnnonce.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Api.Services
{
    public class AnnonceRepository : IAnnonceRepository
    {

        private readonly GestionAnnonceContext _context;

        public AnnonceRepository(GestionAnnonceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Annonce>> GetAnnoncesAsync()
        {
            return await _context.Annonces.ToListAsync();
        }

        public async Task<Annonce?> GetAnnonceByIdAsync(int id)
        {
            return await _context.Annonces.Include(annonce => annonce.Photos).Where(annonce => annonce.Id == id).FirstOrDefaultAsync();
        }
    }
}
