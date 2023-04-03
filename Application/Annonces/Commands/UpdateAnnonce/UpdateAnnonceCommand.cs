using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Annonces.Commands.UpdateAnnonce
{
    public record UpdateAnnonceCommand(int annonceid, Annonce annonce) : IRequest<int>
    {
    }

    public class UpdateAnnonceHandler : IRequestHandler<UpdateAnnonceCommand, int>
    {
        private readonly IAnnonceRepository _annonceRepository;

        public UpdateAnnonceHandler(IGestionAnnonceContext gestion, IMapper mapper, IAnnonceRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<int> Handle(UpdateAnnonceCommand request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.UpdateAnnonceAsync(request.annonceid,request.annonce, cancellationToken);
        }
    }
}
