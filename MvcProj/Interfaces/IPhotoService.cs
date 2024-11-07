using CloudinaryDotNet.Actions;

namespace MvcProj.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string file);
    }
}
