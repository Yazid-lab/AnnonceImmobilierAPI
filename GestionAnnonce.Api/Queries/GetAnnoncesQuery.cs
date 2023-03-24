using GestionAnnonce.Api.Domain;
using MediatR;

namespace GestionAnnonce.Api.Queries
{
    public class GetAnnoncesQuery : IRequest<IEnumerable<Annonce>>
    {
    }
}
