using GestionAnnonce.Api.Domain;
using GestionAnnonce.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionAnnonce.Api.Controllers
{
    [Route("api/annonces")]
    [ApiController]
    public class AnnoncesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnnoncesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Annonce>>> GetAnnonces()
        {
            var annoncesList = await _mediator.Send(new GetAnnoncesQuery());
            return Ok(annoncesList);
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

            return Ok(annonce);
        }
    }
}

