using Domain.ValueObjects;
using System.Runtime.Serialization;

namespace Domain.Entities
{


    public enum AdType
    {
        Rent,
        Sell
    }
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Area { get; set; }
        public int NbRooms { get; set; }
        public DateTime DatePublication { get; set; }
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public Address? Address { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public bool IsPublished { get; set; } = true;
        public AdType AdType { get; set; }

        public Ad() { }
        public Ad(string title)
        {
            Title = title;
        }

    }


}
