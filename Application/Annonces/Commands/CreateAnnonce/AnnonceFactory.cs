using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;

namespace GestionAnnonce.Application.Annonces.Commands.CreateAnnonce
{
    public class AnnonceFactory
    {
        public Annonce Create(string titre,
            string description,
            decimal prix,
            int superficie,
            int nbPieces,
            DateTime datePublication,
            Adresse adresse,
            Utilisateur utilisateur)
        {
            var annonce = new Annonce
            {
                Description = description,
                Prix = prix,
                Superficie = superficie,
                NbPieces = nbPieces,
                DatePublication = datePublication,
                Adresse = adresse,
                Utilisateur = utilisateur
            };
            return annonce;

        }
    }
}
