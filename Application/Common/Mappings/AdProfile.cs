using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Ads.Commands.CreateAd;
using GestionAnnonce.Application.Ads.Commands.UpdateAd;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Mappings
{
    public class AdProfile : Profile
    {
        public AdProfile()
        {
            CreateMap<Ad, AdDto>();
            CreateMap<CreateAdDto, Ad>();
            CreateMap<UpdateAdDto, Ad>();
            //CreateMap<IEnumerable<Ad>, AdDto>();

        }
    }
}
