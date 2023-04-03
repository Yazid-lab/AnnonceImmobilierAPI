using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Annonces.Commands.DeleteAnnonce
{
    public record DeleteAnnonceCommand(int Id) : IRequest<int>;
    public class DeleteAnnonceHandler : IRequestHandler<DeleteAnnonceCommand, int>
    {
        private readonly IAnnonceRepository _annonceRepository;

        public DeleteAnnonceHandler(IGestionAnnonceContext context, IAnnonceRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<int> Handle(DeleteAnnonceCommand request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.DeleteAnnonceAsync(request.Id, cancellationToken);
        }
    }
}
