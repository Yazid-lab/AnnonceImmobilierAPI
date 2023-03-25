using AutoMapper;
using GestionAnnonce.Api.Domain;
using GestionAnnonce.Api.Models;

namespace GestionAnnonce.Api.Profiles
{
    public class AnnonceProfile : Profile
    {
        public AnnonceProfile()
        {
            CreateMap<Annonce, AnnonceDto>();
        }
    }
}
