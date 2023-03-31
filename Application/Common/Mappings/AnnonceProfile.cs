using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Annonces.Commands.CreateAnnonce;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Mappings
{
    public class AnnonceProfile : Profile
    {
        public AnnonceProfile()
        {
            CreateMap<Annonce, AnnonceDto>();
            CreateMap<CreateAnnonceDto, Annonce>();
            CreateMap<IEnumerable<Annonce>, AnnonceDto>();
        }
    }
}
