using Domain.ValueObjects;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Ads.Commands.UpdateAd
{
    public class UpdateAdDto
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
        public int UserId { get; set; }

    }
}
