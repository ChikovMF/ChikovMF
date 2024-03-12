using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.DeleteFile
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
    {
        public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            await _fileManager.DeleteFile(request.FileName);
        }

        private readonly IFileManager _fileManager;
        public DeleteFileCommandHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }
    }
}