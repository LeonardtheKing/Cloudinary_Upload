using CloudinaryUpload.Entity;

namespace CloudinaryUpload.Interfaces;

public interface IPhotoRepository
{
    Task<Photo> AddPhotoAsync(Photo photo);
    Task<bool> DeletePhotoAsync(int id);
    Task<Photo?> GetPhotoAsync(int id);
}

