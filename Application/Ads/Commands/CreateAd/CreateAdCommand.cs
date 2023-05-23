using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using GestionAnnonce.Application.Common.Models;
using MediatR;

namespace GestionAnnonce.Application.Ads.Commands.CreateAd
{
    public record CreateAdCommand(Ad Ad) : IRequest<AdDto>;

    public class CreateAdHandler : IRequestHandler<CreateAdCommand, AdDto>
    {
        private readonly IMapper _mapper;
        private readonly IAdRepository _adRepository;

        public CreateAdHandler( IMapper mapper, IAdRepository adRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _adRepository = adRepository ?? throw new ArgumentNullException(nameof(adRepository));
        }
        public async Task<AdDto> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var adEntity = _mapper.Map<Ad>(request.Ad);
            await _adRepository.AddAdAsync(adEntity, cancellationToken);
            var adDto = _mapper.Map<AdDto>(adEntity);
            return adDto;
        }
    }
}
