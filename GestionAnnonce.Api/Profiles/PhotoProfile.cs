using AutoMapper;
using GestionAnnonce.Api.Domain;
using GestionAnnonce.Api.Models;

namespace GestionAnnonce.Api.Profiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoDto>();
        }
    }
}
