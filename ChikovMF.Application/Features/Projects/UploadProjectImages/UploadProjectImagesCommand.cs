using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChikovMF.Application.Features.Projects.UploadProjectSliderImage;

public class UploadProjectImagesCommand : IRequest<int>
{
    public IFormFileCollection FileCollection { get; set; } = null!;
    public Guid ProjectId { get; set; }
}
