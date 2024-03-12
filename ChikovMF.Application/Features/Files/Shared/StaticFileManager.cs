using Microsoft.AspNetCore.Http;

namespace ChikovMF.Application.Features.Files.Shared
{
    public class StaticFileManager : IFileManager
    {
        const string FOLDER_NAME = "Files";

        public async Task<FileDto> AddOrUpdateFile(IFormFile file, string oldFileName = "")
        {
            string pathLocation = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
            string fileName = string.Empty;
            string filePathLocation = string.Empty;

            if (!string.IsNullOrWhiteSpace(oldFileName))
            {
                filePathLocation = Path.Combine(pathLocation, oldFileName);
                fileName = oldFileName;
                File.Delete(filePathLocation);
            }
            else
            {
                do
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePathLocation = Path.Combine(pathLocation, fileName);
                }
                while (File.Exists(filePathLocation));
            }

            using (Stream fileStream = new FileStream(filePathLocation, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return new FileDto {
                Name = fileName,
                Path = $"{FOLDER_NAME}/{fileName}"
            };
        }

        public Task DeleteFile(string fileName)
        {
            string filePathLocation = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME, fileName);
            if (File.Exists(filePathLocation))
            {
                File.Delete(filePathLocation);
            }
            else 
            {
                throw new FileNotFoundException($"File '{fileName}' is not found.");
            }
            return Task.CompletedTask;
        }

        public Task<ICollection<FileDto>> GetListFiles()
        {
            string pathLocation = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
            var filesPath = Directory.GetFiles(pathLocation);
            var files = new List<FileDto>(filesPath.Length);
            foreach (var filePath in filesPath)
            {
                var fileInfo = new FileInfo(filePath);
                var file = new FileDto
                {
                    Name = fileInfo.Name,
                    Path = $"{FOLDER_NAME}/{fileInfo.Name}",
                };
                files.Add(file);
            }
            return Task.FromResult<ICollection<FileDto>>(files.ToArray());
        }
    }
}
