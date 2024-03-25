using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.UpdateFile;

public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, FileDto>
{
    public async Task<FileDto> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = await _fileManager.DeleteFile(request.PathLocation, request.FileName, cancellationToken);
        if (!isSuccess)
        {
            throw new Exception($"Failed to delete file \"{request.FileName}\" at path \"{request.PathLocation}\".");
        }
        
        var fileDto = await _fileManager.SaveFile(request.FileStream, request.PathLocation, request.FileName, cancellationToken);

        return fileDto;
    }

    private readonly IFileManager _fileManager;
    public UpdateFileCommandHandler(IFileManager fileManager) => _fileManager = fileManager;
}