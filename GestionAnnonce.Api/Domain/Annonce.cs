﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAnnonce.Api.Domain
{
    public class Annonce
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int Superficie { get; set; }
        public int NbPieces { get; set; }
        public DateTime DatePublication { get; set; }
        public IList<Photo> Photos { get; set; } = new List<Photo>();
        public Adresse? Adresse { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        public Annonce(string titre)
        {
            Titre = titre;
        }

    }


}