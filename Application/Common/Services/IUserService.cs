using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
