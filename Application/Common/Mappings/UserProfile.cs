using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
