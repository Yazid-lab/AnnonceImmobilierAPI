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
        private readonly IGestionAnnonceContext _context;
        private readonly IMapper _mapper;

        public GetAnnoncesHandler(IGestionAnnonceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<Annonce>> Handle(GetAnnoncesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Annonces.Include(annonce => annonce.Photos).ToListAsync(cancellationToken);
        }
    }
}
