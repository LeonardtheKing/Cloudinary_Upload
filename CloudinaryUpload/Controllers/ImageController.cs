using CloudinaryUpload.DTOs;
using CloudinaryUpload.Entity;
using CloudinaryUpload.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloudinaryUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController(IPhotoService photoService, IPhotoRepository photoRepository ) : ControllerBase
    {
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {

            var result = await photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            await photoRepository.AddPhotoAsync(photo);

            return Ok("successful");
        }


        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {        
            var photo = photoRepository.GetPhotoAsync(photoId);

            if (photo == null) return NotFound();
       
                var result = await photoService.DeletePhotoAsync(photo.Result!.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            

           await photoRepository.DeletePhotoAsync(photoId);

            return Ok("Photo deleted successfully");
        }
    }
}
