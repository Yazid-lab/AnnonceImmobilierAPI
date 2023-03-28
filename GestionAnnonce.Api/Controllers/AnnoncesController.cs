using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Annonces.Queries.GetAnnonceById;
using GestionAnnonce.Application.Annonces.Queries.GetAnnonces;
using GestionAnnonce.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionAnnonce.Api.Controllers
{
    [Route("api/annonces")]
    [ApiController]
    public class AnnoncesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AnnoncesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Annonce>>> GetAnnonces()
        {
            var annoncesList = await _mediator.Send(new GetAnnoncesQuery());
            return Ok(_mapper.Map<IEnumerable<AnnonceDto>>(annoncesList));
        }

        [HttpGet("{annonceId:int}")]
        public async Task<ActionResult<Annonce>> GetAnnonceById(int annonceId)
        {
            var annonce = await _mediator.Send(new GetAnnonceByIdQuery()
            {
                Id = annonceId
            });
            if (annonce == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AnnonceDto>(annonce));
        }
    }
}

