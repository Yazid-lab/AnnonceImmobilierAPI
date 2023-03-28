using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Mappings
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoDto>();
        }
    }
}
