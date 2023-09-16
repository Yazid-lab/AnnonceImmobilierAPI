namespace GestionAnnonce.Application.Common.Models.Identity
{
    public class ApplicationUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
    }
}
