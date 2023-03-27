using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAnnonce.Api.Domain
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; } = string.Empty;
        public Annonce? Annonce { get; set; }
        public int AnnonceId { get; set; }
        public Photo(int id, string url, string description, int annonceId)
        {
            Id = id;
            Url = url;
            Description = description;
            AnnonceId = annonceId;
        }
    }

}