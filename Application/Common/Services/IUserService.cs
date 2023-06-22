using Domain.Entities;
using GestionAnnonce.Application.Common.Models;
using GestionAnnonce.Application.Users.Commands.UpdateUser;

namespace GestionAnnonce.Application.Common.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<int> UpdateUser(int userId, UpdateUserDto user);
        Task<int> DeleteUser(int userId);
    }
}
