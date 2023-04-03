using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Application.Annonces.Queries.GetAnnonceById
{
    public record GetAnnonceByIdQuery(int Id) : IRequest<Annonce>
    {
    }

    public class GetAnnonceByIdHandler : IRequestHandler<GetAnnonceByIdQuery, Annonce>
    {
        private readonly IGestionAnnonceContext _context;
        private readonly IMapper _mapper;
        private readonly IAnnonceRepository _annonceRepository;

        public GetAnnonceByIdHandler(IGestionAnnonceContext context, IMapper mapper, IAnnonceRepository annonceRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<Annonce?> Handle(GetAnnonceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.GetAnnonceByIdAsync(request.Id,cancellationToken);
        }
    }
}
