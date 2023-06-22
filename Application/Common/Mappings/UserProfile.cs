using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Models;
using GestionAnnonce.Application.Users.Commands.UpdateUser;

namespace GestionAnnonce.Application.Common.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
