using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Application.Features.Files.Shared;
using Microsoft.AspNetCore.Http;

namespace ChikovMF.WebAPI.Common;

public class StaticFileManager : IFileManager
{
    public async Task<bool> DeleteFile(string pathLocation, string fileName, CancellationToken cancellationToken)
    {
        if (await FileExists(pathLocation, fileName, cancellationToken))
        {
            string filePathLocation = Path.Combine(Directory.GetCurrentDirectory(), pathLocation, fileName);
            File.Delete(filePathLocation);
            return true;
        }
        else
        {
            return false;
        }
    }

    public Task<bool> FileExists(string pathLocation, string fileName, CancellationToken cancellationToken)
    {
        string filePathLocation = Path.Combine(Directory.GetCurrentDirectory(), pathLocation, fileName);
        var exists = File.Exists(filePathLocation);
        return Task.FromResult(exists);
    }

    public Task<FileDto> GetFile(string pathLocation, string fileName, CancellationToken cancellationToken)
    {
        string filePathLocation = Path.Combine(Directory.GetCurrentDirectory(), pathLocation, fileName);
        var fileInfo = new FileInfo(filePathLocation);
        var file = new FileDto
        {
            Name = fileInfo.Name,
            Path = $"{pathLocation}/{fileInfo.Name}"
        };
        return Task.FromResult(file);
    }

    public Task<ICollection<FileDto>> GetFiles(string pathLocation, CancellationToken cancellationToken)
    {
        string folderPathLocation = Path.Combine(Directory.GetCurrentDirectory(), pathLocation);
        var filesPath = Directory.GetFiles(pathLocation);
        var files = new List<FileDto>(filesPath.Length);
        foreach (var filePath in filesPath)
        {
            var fileInfo = new FileInfo(filePath);
            var file = new FileDto
            {
                Name = fileInfo.Name,
                Path = $"{pathLocation}/{fileInfo.Name}",
            };
            files.Add(file);
        }
        return Task.FromResult<ICollection<FileDto>>(files.ToArray());
    }

    public async Task<FileDto> SaveFile(Stream stream, string pathLocation, string fileName, CancellationToken cancellationToken)
    {
        string newFileName = string.Empty;
        do
        {
            newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
        }
        while (await FileExists(pathLocation, newFileName, cancellationToken));

        string filePathLocation = Path.Combine(Directory.GetCurrentDirectory(), pathLocation, newFileName);

        using (Stream fileStream = new FileStream(filePathLocation, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream);
        }

        return new FileDto
        {
            Name = newFileName,
            Path = $"{pathLocation}/{newFileName}"
        };
    }
}
