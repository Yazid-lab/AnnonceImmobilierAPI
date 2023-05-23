using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Ads.Commands.DeleteAd
{
    public record DeleteAnnonceCommand(int Id) : IRequest<int>;
    public class DeleteAnnonceHandler : IRequestHandler<DeleteAnnonceCommand, int>
    {
        private readonly IAdRepository _annonceRepository;

        public DeleteAnnonceHandler(IAdManagementContext context, IAdRepository annonceRepository)
        {
            _annonceRepository = annonceRepository ?? throw new ArgumentNullException(nameof(annonceRepository));
        }
        public async Task<int> Handle(DeleteAnnonceCommand request, CancellationToken cancellationToken)
        {
            return await _annonceRepository.DeleteAdAsync(request.Id, cancellationToken);
        }
    }
}
