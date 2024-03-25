using ChikovMF.Application.Features.Files.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Files.UpdateFile;

public class UpdateFileCommand : IRequest<FileDto>
{
    public Stream FileStream { get; set; } = default!;
    public string PathLocation { get; set; } = default!;
    public string FileName { get; set; } = default!;
}
