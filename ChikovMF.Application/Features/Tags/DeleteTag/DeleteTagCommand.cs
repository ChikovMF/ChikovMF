using MediatR;

namespace ChikovMF.Application.Features.Tags.DeleteTag;

public class DeleteTagCommand : IRequest
{
    public Guid TagId { get; set; }
}
