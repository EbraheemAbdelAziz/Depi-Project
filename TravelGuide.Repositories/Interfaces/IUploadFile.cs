using Microsoft.AspNetCore.Http;

namespace TravelGuide.Repositories.Interfaces
{
    public interface IUploadFile
    {
        Task<string> UploadFileAsync(string filePath, IFormFile file);
    }
}
