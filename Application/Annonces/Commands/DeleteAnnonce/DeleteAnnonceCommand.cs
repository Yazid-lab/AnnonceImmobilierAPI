using GestionAnnonce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestionAnnonce.Application.Annonces.Commands.DeleteAnnonce
{
    public record DeleteAnnonceCommand(int Id) : IRequest<int>;
    public class DeleteAnnonceHandler : IRequestHandler<DeleteAnnonceCommand,int>
    {
        private readonly IGestionAnnonceContext _context;

        public DeleteAnnonceHandler(IGestionAnnonceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> Handle(DeleteAnnonceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Annonces.Where(annonce => annonce.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            _context.Annonces.Remove(entity);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
