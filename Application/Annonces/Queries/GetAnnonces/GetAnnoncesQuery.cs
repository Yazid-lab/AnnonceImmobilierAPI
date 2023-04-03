using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Application.Annonces.Queries.GetAnnonces
{
    public record GetAnnoncesQuery : IRequest<IEnumerable<Annonce>>
    {
    }

    public class GetAnnoncesHandler : IRequestHandler<GetAnnoncesQuery, IEnumerable<Annonce>>
    {
        private readonly IAnnonceRepository _annonceRepository;

        public GetAnnoncesHandler(IAnnonceRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<IEnumerable<Annonce>> Handle(GetAnnoncesQuery request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.GetAnnoncesAsync(cancellationToken);
        }
    }
}
