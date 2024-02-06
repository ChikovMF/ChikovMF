using MediatR;

namespace ChikovMF.Application.Features.Tags.CreateTag;

public class CreateTagCommand : IRequest<Guid>
{
    public CreateTagModel Tag { get; set; } = null!;
}
