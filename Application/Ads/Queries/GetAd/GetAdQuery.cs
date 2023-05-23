using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Ads.Queries.GetAd
{
    public record GetAdQuery : IRequest<IEnumerable<Ad>>
    {
    }

    public class GetAdsHandler : IRequestHandler<GetAdQuery, IEnumerable<Ad>>
    {
        private readonly IAdRepository _annonceRepository;

        public GetAdsHandler(IAdRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<IEnumerable<Ad>> Handle(GetAdQuery request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.GetAdsAsync(cancellationToken);
        }
    }
}
