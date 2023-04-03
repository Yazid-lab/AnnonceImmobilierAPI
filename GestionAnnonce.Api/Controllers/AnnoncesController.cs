using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Annonces.Commands.CreateAnnonce;
using GestionAnnonce.Application.Annonces.Commands.DeleteAnnonce;
using GestionAnnonce.Application.Annonces.Commands.UpdateAnnonce;
using GestionAnnonce.Application.Common.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionAnnonce.Api.Controllers
{
    [Route("api/annonces")]
    [ApiController]
    public class AnnoncesController : ControllerBase
    {
        private readonly IAnnonceService _annonceService;

        public AnnoncesController(IAnnonceService annonceService)
        {
            _annonceService = annonceService ?? throw new ArgumentNullException(nameof(annonceService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Annonce>>> GetAnnonces()
        {
            var annoncesList =await _annonceService.GetAnnonces();
            return Ok(annoncesList);
        }

        [HttpGet("{annonceId:int}")]
        public async Task<ActionResult<Annonce>> GetAnnonceById(int annonceId)
        {
            var annonce = await _annonceService.GetAnnonceById(annonceId);
        
            if (annonce == null)
            {
                return NotFound();
            }

            return Ok(annonce);
        }

        [HttpDelete("{annonceId:int}")]
        public async Task<ActionResult> DeleteAnnonce(int annonceId)
        {
            var id = await _annonceService.DeleteAnnonce(annonceId);
            if (id < 0)
            {
                return NotFound(); 
            }
            return Ok(id);
        }

        [HttpPut("{annonceId:int}")]
        public async Task<ActionResult<int>> UpdateAnnonce(int annonceId, UpdateAnnonceDto annonce)
        {
            var id = await _annonceService.UpdateAnnonce(annonceId, annonce);
            if (id < 0) return NotFound();
            return Ok(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAnnonce([FromBody] CreateAnnonceDto annonce)
        {
            var id = await _annonceService.AddAnnonce(annonce);
            return Ok(id);
        }
    }
}

