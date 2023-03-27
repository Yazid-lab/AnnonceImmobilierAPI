using AutoMapper;
using GestionAnnonce.Api.Domain.Entities;
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
