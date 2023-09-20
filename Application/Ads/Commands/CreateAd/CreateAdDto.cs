using Domain.ValueObjects;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Ads.Commands.CreateAd
{
    public class CreateAdDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Area { get; set; }
        public int NbRooms { get; set; }
        public DateTime DatePublication { get; set; }
        public ICollection<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
        public Address? Address { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
