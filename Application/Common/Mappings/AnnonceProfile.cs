using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Mappings
{
    public class AnnonceProfile : Profile
    {
        public AnnonceProfile()
        {
            CreateMap<Annonce, AnnonceDto>();
            CreateMap<IEnumerable<Annonce>, AnnonceDto>();
        }
    }
}
