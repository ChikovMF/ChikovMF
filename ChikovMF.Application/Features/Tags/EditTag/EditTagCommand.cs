using MediatR;

namespace ChikovMF.Application.Features.Tags.EditTag;

public class EditTagCommand : IRequest<Guid>
{
    public Guid TagId { get; set; }
    public EditTagModel Tag { get; set; } = null!;
}
