namespace GestionAnnonce.Application.Common.Models
{
    public class UserDto
    {
        public int Id { get; set; }
         public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
    }
}
