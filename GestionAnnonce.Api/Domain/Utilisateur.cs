using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAnnonce.Api.Domain
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public int? AnnonceId { get; set; }
        public Annonce Annonce { get; set; }


        public Utilisateur(int id,string nom, string prenom, string email, string telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
        }
    }

}