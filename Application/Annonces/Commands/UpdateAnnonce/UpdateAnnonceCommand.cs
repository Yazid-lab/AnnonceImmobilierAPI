using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Application.Annonces.Commands.UpdateAnnonce
{
    public record UpdateAnnonceCommand(int annonceid, UpdateAnnonceDto annonce) : IRequest<int>
    {
    }

    public class UpdateAnnonceHandler : IRequestHandler<UpdateAnnonceCommand, int>
    {
        private readonly IGestionAnnonceContext _context;
        private readonly IMapper _mapper;

        public UpdateAnnonceHandler(IGestionAnnonceContext gestion, IMapper mapper)
        {
            _context = gestion ?? throw new ArgumentNullException(nameof(gestion));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<int> Handle(UpdateAnnonceCommand request, CancellationToken cancellationToken)
        {
            var annonceExists =
                await _context.Annonces.AnyAsync(annonce => annonce.Id == request.annonceid, cancellationToken);
            if (!annonceExists) return -1;
            var annonceEntity = _mapper.Map<Annonce>(request.annonce);
            _context.Annonces.Update(annonceEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return annonceEntity.Id;

        }
    }
}
