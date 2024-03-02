using ChikovMF.Application.Features.Tags.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Tags.CreateTag;

public class CreateTagCommand : IRequest<Guid>
{
    public TagDto Tag { get; set; } = null!;
}
