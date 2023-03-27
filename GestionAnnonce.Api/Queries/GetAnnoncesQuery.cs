using GestionAnnonce.Api.Domain.Entities;
using MediatR;

namespace GestionAnnonce.Api.Queries
{
    public class GetAnnoncesQuery : IRequest<IEnumerable<Annonce>>
    {
    }
}
