using Microsoft.AspNetCore.Http;

namespace ChikovMF.Application.Features.Files.Shared
{
    public interface IFileManager
    {
        Task<ICollection<FileDto>> GetListFiles();
        Task DeleteFile(string fileName);
        Task<FileDto> AddOrUpdateFile(IFormFile file, string oldFileName);
    }
}