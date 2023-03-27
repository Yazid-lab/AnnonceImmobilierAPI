using GestionAnnonce.Api.Domain.Entities;
using MediatR;

namespace GestionAnnonce.Api.Queries
{
    public class GetAnnonceByIdQuery : IRequest<Annonce>
    {
        public int Id { get; set; }
    }
}
