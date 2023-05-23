using Domain.Entities;
using GestionAnnonce.Application.Ads.Commands.CreateAd;
using GestionAnnonce.Application.Ads.Commands.UpdateAd;
using GestionAnnonce.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionAnnonce.Api.Controllers
{
    [Route("api/ads")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdService _adService;

        public AdsController(IAdService adService)
        {
            _adService = adService ?? throw new ArgumentNullException(nameof(adService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAds()
        {
            var ads =await _adService.GetAds();
            return Ok(ads);
        }

        [HttpGet("{adId:int}")]
        public async Task<ActionResult<Ad>> GetAdById(int adId)
        {
            var adDto = await _adService.GetAdById(adId);
        
            if (adDto == null)
            {
                return NotFound();
            }

            return Ok(adDto);
        }

        [HttpDelete("{adId:int}")]
        public async Task<ActionResult> DeleteAd(int adId)
        {
            var id = await _adService.DeleteAd(adId);
            if (id < 0)
            {
                return NotFound(); 
            }
            return Ok(id);
        }

        [HttpPut("{adId:int}")]
        public async Task<ActionResult<int>> UpdateAd(int adId, UpdateAdDto ad)
        {
            var id = await _adService.UpdateAd(adId, ad);
            if (id < 0) return NotFound();
            return Ok(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAd([FromBody] CreateAdDto ad)
        {
            var adDto = await _adService.AddAd(ad);
            return Ok(adDto);
        }
    }
}

