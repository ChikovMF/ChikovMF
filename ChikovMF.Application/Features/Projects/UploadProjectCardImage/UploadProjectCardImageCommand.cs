using MediatR;

namespace ChikovMF.Application.Features.Projects.UploadProjectCardImage;

public class UploadProjectCardImageCommand : IRequest<string>
{
    public Stream? ImageStream { get; set; } = null!;
    public Guid ProjectId { get; set; }
}
