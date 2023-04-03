using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionAnnonce.Application.Annonces.Commands.CreateAnnonce;
using GestionAnnonce.Application.Annonces.Commands.UpdateAnnonce;
using GestionAnnonce.Application.Common.Models;

namespace GestionAnnonce.Application.Common.Services
{
    public interface IAnnonceService
    {
        Task<bool> AnnonceExists(int annonceId);
        Task<IEnumerable<AnnonceDto>> GetAnnonces();
        Task<AnnonceDto?> GetAnnonceById(int id);
        public Task<int> AddAnnonce(CreateAnnonceDto annonce);
        Task<int> DeleteAnnonce(int annonceId);
        Task<int> UpdateAnnonce(int annonceId, UpdateAnnonceDto annonce);
    }
}
