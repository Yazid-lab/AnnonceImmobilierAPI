﻿using Domain.Entities;
using Domain.ValueObjects;

namespace GestionAnnonce.Application.Common.Models
{
    public class AdDto
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
        public bool IsPublished { get; set; }

        public AdType AdType { get; set; }
    }
}
