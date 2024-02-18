using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Tags.DeleteTag;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
{
    public async Task Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _context.Tags
                .FirstOrDefaultAsync(p => p.TagId == request.TagId, cancellationToken);

        if (tag == null)
        {
            throw new NotFoundEntityException(nameof(Project), request.TagId);
        }

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private readonly IChikovMFContext _context;

    public DeleteTagCommandHandler(IChikovMFContext context)
    {
        _context = context;
    }
}
