using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAnnonce.Application.Users.Commands.UpdateUser
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
    }
}
