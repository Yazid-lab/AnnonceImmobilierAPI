using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Ads.Queries.GetAdById
{
    public record GetAdByIdQuery(int Id) : IRequest<Ad>;

    public class GetAdByIdHandler : IRequestHandler<GetAdByIdQuery, Ad>
    {
        private readonly IAdRepository _adRepository;

        public GetAdByIdHandler( IAdRepository adRepository)
        {
            _adRepository = adRepository ?? throw new ArgumentNullException(nameof(adRepository));
        }
        public async Task<Ad> Handle(GetAdByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _adRepository.GetAdByIdAsync(request.Id,cancellationToken))!;
        }
    }
}
