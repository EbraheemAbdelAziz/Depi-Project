using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Repositories.Implementation
{
    public class UploadFile : IUploadFile
    {
        private IHostingEnvironment _environment;

        public UploadFile(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> UploadFileAsync(string filePath, IFormFile file)
        {
            string UniqueFileName = string.Empty;
            string UploadFolder = _environment.WebRootPath + filePath;
            if (!Directory.Exists(UploadFolder))
            {
                Directory.CreateDirectory(UploadFolder);
            }

            UniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string FileName = Path.Combine(UploadFolder, UniqueFileName);

            using (var stream = new FileStream(FileName, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Dispose();
            }
            return filePath + UniqueFileName;
        }
    }
}
