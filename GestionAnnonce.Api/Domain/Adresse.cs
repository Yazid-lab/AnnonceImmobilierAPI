using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAnnonce.Api.Domain
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Rue { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Pays { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Adresse(int id, string rue, string ville, string codePostal, string pays, double latitude, double longitude)
        {
            Id = id; Rue = rue; Ville = ville; CodePostal = codePostal; Pays = pays; Latitude = latitude; Longitude = longitude;

        }
    }
}