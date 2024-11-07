using CloudinaryDotNet.Actions;
using CloudinaryUpload.Entity;

namespace CloudinaryUpload.Interfaces;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);
   
}
