using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Annonces.Commands.CreateAnnonce
{
    public record CreateAnnonceCommand(Annonce annonce) : IRequest<int>
    {
    }
    public class CreateAnnonceHandler : IRequestHandler<CreateAnnonceCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAnnonceRepository _annonceRepository;

        public CreateAnnonceHandler(IGestionAnnonceContext context, IMapper mapper, IAnnonceRepository annonceRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<int> Handle(CreateAnnonceCommand request, CancellationToken cancellationToken)
        {
            var annonceEntity = _mapper.Map<Annonce>(request.annonce);
            await _annonceRepository.AddAnnonceAsync(annonceEntity, cancellationToken);
            return request.annonce.Id;
        }
    }
}
