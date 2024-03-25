using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.ListFiles
{
    public class ListFileQuery : IRequest<ICollection<FileDto>>
    {
        public string PathLocation { get; set; } = default!;
    }
}