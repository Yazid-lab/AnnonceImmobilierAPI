using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace GestionAnnonce.Application.Annonces.Commands.CreateAnnonce
{
    public class CreateAnnonceModel
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int Superficie { get; set; }
        public int NbPieces { get; set; }
        public DateTime DatePublication { get; set; }
        public Adresse? Adresse { get; set; }
        public int UtilisateurId { get; set; }
    }
}
