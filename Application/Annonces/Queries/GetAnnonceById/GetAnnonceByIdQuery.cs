using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Application.Annonces.Queries.GetAnnonceById
{
    public record GetAnnonceByIdQuery : IRequest<Annonce>
    {
        public int Id { get; set; }
    }

    public class GetAnnonceByIdHandler : IRequestHandler<GetAnnonceByIdQuery, Annonce>
    {
        private readonly IGestionAnnonceContext _context;
        private readonly IMapper _mapper;

        public GetAnnonceByIdHandler(IGestionAnnonceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Annonce?> Handle(GetAnnonceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Annonces
                .Where(annonce => annonce.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
