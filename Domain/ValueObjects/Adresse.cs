using Microsoft.EntityFrameworkCore;

namespace Domain.ValueObjects
{
    [Owned]
    public class Adresse
    {
        public string Rue { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Pays { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Adresse(string rue, string ville, string codePostal, string pays, double latitude, double longitude)
        {
            Rue = rue; Ville = ville; CodePostal = codePostal; Pays = pays; Latitude = latitude; Longitude = longitude;

        }
    }
}