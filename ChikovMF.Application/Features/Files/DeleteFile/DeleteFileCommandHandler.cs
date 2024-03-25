using ChikovMF.Application.Common.Interfaces;
using MediatR;

namespace ChikovMF.Application.Features.Files.DeleteFile
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, bool>
    {
        public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            if (!await _fileManager.FileExists(request.PathLocation, request.FileName, cancellationToken))
            {
                return false;
            }
            
            return await _fileManager.DeleteFile(request.PathLocation, request.FileName, cancellationToken);
        }

        private readonly IFileManager _fileManager;
        public DeleteFileCommandHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }
    }
}