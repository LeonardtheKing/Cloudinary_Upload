using CloudinaryUpload.Entity;
using CloudinaryUpload.Interfaces;

namespace CloudinaryUpload.Data.Repository
{
    public class PhotoRepository(DataContext context):IPhotoRepository
    {
    

        // Add a new photo to the database
        public async Task<Photo> AddPhotoAsync(Photo photo)
        {
            context.Photos.Add(photo);
            await context.SaveChangesAsync(); // Save the changes to the database
            return photo;
        }

        // Delete a photo by Id from the database
        public async Task<bool> DeletePhotoAsync(int id)
        {
            var photo = await context.Photos.FindAsync(id);
            if (photo == null)
            {
                return false;
            }

            context.Photos.Remove(photo);
            await context.SaveChangesAsync(); // Save the changes to the database
            return true;
        }

        public async Task<Photo?> GetPhotoAsync(int id)
        {
            return await context.Photos.FindAsync(id);
        }
    }
}
