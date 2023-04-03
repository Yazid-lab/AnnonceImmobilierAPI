
using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Annonces.Commands.CreateAnnonce;
using GestionAnnonce.Application.Annonces.Commands.DeleteAnnonce;
using GestionAnnonce.Application.Annonces.Commands.UpdateAnnonce;
using GestionAnnonce.Application.Annonces.Queries.GetAnnonceById;
using GestionAnnonce.Application.Annonces.Queries.GetAnnonces;
using GestionAnnonce.Application.Common.Interfaces;
using GestionAnnonce.Application.Common.Models;
using MediatR;

namespace GestionAnnonce.Application.Common.Services
{

    public class AnnonceService : IAnnonceService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IAnnonceRepository _annonceRepository;

        public AnnonceService(IMediator mediator, IMapper mapper,IAnnonceRepository annonceRepository)
        {
            if (mediator == null) throw new ArgumentNullException(nameof(mediator));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }

        public Task<bool> AnnonceExists(int annonceId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnnonceDto>> GetAnnonces()
        {
            var annonceEntities = await _mediator.Send(new GetAnnoncesQuery());
            return _mapper.Map<IEnumerable<AnnonceDto>>(annonceEntities);
        }

        public async Task<AnnonceDto?> GetAnnonceById(int id)
        {
            var annonceEntity = await _mediator.Send(new GetAnnonceByIdQuery(id));
            return _mapper.Map<AnnonceDto>(annonceEntity);
        }

        public async Task<int> AddAnnonce(CreateAnnonceDto annonce)
        {
            var annonceEntity = _mapper.Map<Annonce>(annonce);
            return await _mediator.Send(new CreateAnnonceCommand(annonceEntity));
        }

        public async Task<int> DeleteAnnonce(int annonceId)
        {
            return await _mediator.Send(new DeleteAnnonceCommand(annonceId));
        }

        public async Task<int> UpdateAnnonce(int annonceId, UpdateAnnonceDto annonce)
        {
            var annonceEntity = _mapper.Map<Annonce>(annonce);
            return await _mediator.Send(new UpdateAnnonceCommand(annonceId, annonceEntity));
        }
    }
}
