using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Annonces.Commands.CreateAnnonce
{
    public record CreateAnnonceCommand(CreateAnnonceDto annonce) : IRequest<int>
    {
    }
    public class CreateAnnonceHandler : IRequestHandler<CreateAnnonceCommand, int>
    {
        private readonly IGestionAnnonceContext _context;
        private readonly IMapper _mapper;

        public CreateAnnonceHandler(IGestionAnnonceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<int> Handle(CreateAnnonceCommand request, CancellationToken cancellationToken)
        {
            var annonceEntity = _mapper.Map<Annonce>(request.annonce);
            await _context.Annonces.AddAsync(annonceEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return request.annonce.Id;
        }
    }
}
