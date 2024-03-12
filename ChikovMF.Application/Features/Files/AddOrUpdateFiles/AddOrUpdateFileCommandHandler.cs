using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.AddOrUpdateFile
{
    public class AddOrUpdateFileCommandHandler : IRequestHandler<AddOrUpdateFileCommand, FileDto>
    {
        public async Task<FileDto> Handle(AddOrUpdateFileCommand request, CancellationToken cancellationToken)
        {
            var fileDto = await _fileManager.AddOrUpdateFile(request.File, request.OldNameFile);

            return fileDto;
        }

        private readonly IFileManager _fileManager;
        public AddOrUpdateFileCommandHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }
    }
}