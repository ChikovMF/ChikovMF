using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.ListFiles
{
    public class ListFileQueryHandler : IRequestHandler<ListFileQuery, ICollection<FileDto>>
    {
        public async Task<ICollection<FileDto>> Handle(ListFileQuery request, CancellationToken cancellationToken)
        {
            var files = await _fileManager.GetListFiles();
            return files;
        }

        private readonly IFileManager _fileManager;

        public ListFileQueryHandler(IFileManager fileManager) {
            _fileManager = fileManager;
        }
    }
}