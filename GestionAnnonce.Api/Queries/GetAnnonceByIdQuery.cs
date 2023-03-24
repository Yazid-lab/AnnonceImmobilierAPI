using GestionAnnonce.Api.Domain;
using MediatR;

namespace GestionAnnonce.Api.Queries
{
    public class GetAnnonceByIdQuery : IRequest<Annonce>
    {
        public int Id { get; set; }
    }
}
