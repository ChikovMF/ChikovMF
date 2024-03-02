using ChikovMF.Application.Features.Tags.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Tags.EditTag;

public class EditTagQuery : IRequest<TagDto>
{
    public Guid TagId { get; set; }
}
