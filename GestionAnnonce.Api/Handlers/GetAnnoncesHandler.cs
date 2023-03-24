using GestionAnnonce.Api.Domain;
using GestionAnnonce.Api.Queries;
using GestionAnnonce.Api.Services;
using MediatR;

namespace GestionAnnonce.Api.Handlers
{
    public class GetAnnoncesHandler : IRequestHandler<GetAnnoncesQuery,IEnumerable<Annonce>>
    {
        private readonly IAnnonceRepository _annonceRepository;

        public GetAnnoncesHandler(IAnnonceRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<IEnumerable<Annonce>> Handle(GetAnnoncesQuery request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.GetAnnoncesAsync();
        }
    }
}
