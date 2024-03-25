using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.AddFile;

public class AddFileCommand : IRequest<FileDto>
{
    public Stream FileStream { get; set; } = default!;
    public string FileName { get; set; } = default!;
    public string PathLocation { get; set; } = default!;
}
