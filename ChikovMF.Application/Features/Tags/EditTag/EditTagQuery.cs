using MediatR;

namespace ChikovMF.Application.Features.Tags.EditTag;

public class EditTagQuery : IRequest<EditTagModel>
{
    public Guid TagId { get; set; }
}
