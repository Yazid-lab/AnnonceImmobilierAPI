using GestionAnnonce.Api.Domain.Entities;
using GestionAnnonce.Api.Queries;
using GestionAnnonce.Api.Services;
using MediatR;

namespace GestionAnnonce.Api.Handlers
{
    public class GetAnnonceByIdHandler : IRequestHandler<GetAnnonceByIdQuery,Annonce>
    {
        private readonly IAnnonceRepository _annonceRepository;

        public GetAnnonceByIdHandler(IAnnonceRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }

        public async Task<Annonce> Handle(GetAnnonceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.GetAnnonceByIdAsync(request.Id) ;
        }
    }
}
