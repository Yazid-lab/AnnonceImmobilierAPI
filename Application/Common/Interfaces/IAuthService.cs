using GestionAnnonce.Application.Common.Models.Identity;

namespace GestionAnnonce.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task Logout();
        Task<ApplicationUserDto> GetUserInfoById(string id);

        Task<IEnumerable<ApplicationUserDto>> GetUsers();

        Task<string?> DeleteUser(string id);

        Task<bool> ConfirmEmail(string userId, string token);
    }
}
