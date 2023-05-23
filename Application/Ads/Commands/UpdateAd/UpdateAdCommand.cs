using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Ads.Commands.UpdateAd
{
    public record UpdateAdCommand(int annonceid, Ad annonce) : IRequest<int>
    {
    }

    public class UpdateAnnonceHandler : IRequestHandler<UpdateAdCommand, int>
    {
        private readonly IAdRepository _annonceRepository;

        public UpdateAnnonceHandler(IAdManagementContext gestion, IMapper mapper, IAdRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<int> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.UpdateAdAsync(request.annonceid,request.annonce, cancellationToken);
        }
    }
}
