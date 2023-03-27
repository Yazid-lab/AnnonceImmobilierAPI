using GestionAnnonce.Api.Domain.ValueObjects;

namespace GestionAnnonce.Api.Models
{
    public class AnnonceDto
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int Superficie { get; set; }
        public int NbPieces { get; set; }
        public DateTime DatePublication { get; set; }
        public ICollection<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
        public Adresse Adresse { get; set; }
        public int UtilisateurId { get; set; }
    }
}
