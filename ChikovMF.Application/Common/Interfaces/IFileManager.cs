using ChikovMF.Application.Features.Files.Shared;

namespace ChikovMF.Application.Common.Interfaces;

public interface IFileManager
{
    Task<FileDto> SaveFile(Stream stream, string pathLocation, string fileName, CancellationToken cancellationToken);
    Task<bool> DeleteFile(string pathLocation, string fileName, CancellationToken cancellationToken);
    Task<FileDto> GetFile(string pathLocation, string fileName, CancellationToken cancellationToken);
    Task<ICollection<FileDto>> GetFiles(string pathLocation, CancellationToken cancellationToken);
    Task<bool> FileExists(string pathLocation, string fileName, CancellationToken cancellationToken);
}
