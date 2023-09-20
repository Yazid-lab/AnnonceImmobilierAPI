using Domain.Entities;
using Firebase.Auth;
using Firebase.Storage;
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
        private static string ApiKey = "AIzaSyB-hMGvBxBHHx-D8SNl8h_mVEdQ2SPG0F0";
        private static string Bucket = "homeconnect-a82c7.appspot.com";
        private static string AuthEmail = "imageUploader@gmail.com";
        private static string AuthPassword = "im@ge_uploader_v1";

        public AdsController(IAdService adService)
        {
            _adService = adService ?? throw new ArgumentNullException(nameof(adService));
        }


        private async Task<string?> UploadImageToFirebase(Stream stream, string fileName)
        {
            // of course you can login using other method, not just email+password
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                    })
                .Child("images")
                .Child(fileName)
                .PutAsync(stream);
            
            try
            {
                string link = await task;
                return link;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while uploading image was thrown {0}",ex);
            }

            return null;
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
            return Ok(ad);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAd([FromBody] CreateAdDto ad)
        {
            var adDto = await _adService.AddAd(ad);
            return Ok(adDto);
        }

        [HttpPost("/image")]
        public async Task<ActionResult> UploadImage([FromForm] IFormFile image)
        {
            using (var stream = image.OpenReadStream())
            {
                var link = await UploadImageToFirebase(stream, image.FileName);
                return Ok(link);
            }

            return BadRequest();
        }
    }
}

