using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? LastName { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public ICollection<Ad> Ads {get; set; }


        //public User(string id, string lastName, string firstName, string email, string telephone)
        //{
        //    Id = id;
        //    LastName = lastName;
        //    FirstName = firstName;
        //    Email = email;
        //    Telephone = telephone;
        //}
    }

}