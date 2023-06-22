using Domain.ValueObjects;

namespace Domain.Entities
{
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
        public int UserId { get; set; }
        public User? User { get; set; }
        public bool IsPublished { get; set; } = true;

        public Ad() { }
        public Ad(string title)
        {
            Title = title;
        }

    }


}
