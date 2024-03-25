using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.AddFile;

public class AddFileCommandHandler : IRequestHandler<AddFileCommand, FileDto>
{
    public async Task<FileDto> Handle(AddFileCommand request, CancellationToken cancellationToken)
    {
        var fileDto = await _fileManager.SaveFile(request.FileStream, request.PathLocation, request.FileName, cancellationToken);
        
        return fileDto;
    }
    
    private readonly IFileManager _fileManager;
    public AddFileCommandHandler(IFileManager fileManager) => _fileManager = fileManager;
}