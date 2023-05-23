
using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Ads.Commands.CreateAd;
using GestionAnnonce.Application.Ads.Commands.DeleteAd;
using GestionAnnonce.Application.Ads.Commands.UpdateAd;
using GestionAnnonce.Application.Ads.Queries.GetAd;
using GestionAnnonce.Application.Ads.Queries.GetAdById;
using GestionAnnonce.Application.Common.Models;
using MediatR;

namespace GestionAnnonce.Application.Common.Services
{

    public class AdService : IAdService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdService(IMediator mediator, IMapper mapper)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<bool> AdExists(int adId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AdDto>> GetAds()
        {
            var annonceEntities = await _mediator.Send(new GetAdQuery());
            return _mapper.Map<IEnumerable<AdDto>>(annonceEntities);
        }

        public async Task<AdDto?> GetAdById(int id)
        {
            var annonceEntity = await _mediator.Send(new GetAdByIdQuery(id));
            return _mapper.Map<AdDto>(annonceEntity);
        }

        public async Task<AdDto> AddAd(CreateAdDto ad)
        {
            var annonceEntity = _mapper.Map<Ad>(ad);
            return await _mediator.Send(new CreateAdCommand(annonceEntity));
        }

        public async Task<int> DeleteAd(int adId)
        {
            return await _mediator.Send(new DeleteAnnonceCommand(adId));
        }

        public async Task<int> UpdateAd(int adId, UpdateAdDto ad)
        {
            var annonceEntity = _mapper.Map<Ad>(ad);
            return await _mediator.Send(new UpdateAdCommand(adId, annonceEntity));
        }
    }
}
