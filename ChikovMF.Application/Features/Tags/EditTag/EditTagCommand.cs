using ChikovMF.Application.Features.Tags.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Tags.EditTag;

public class EditTagCommand : IRequest<Guid>
{
    public Guid TagId { get; set; }
    public TagDto Tag { get; set; } = null!;
}
