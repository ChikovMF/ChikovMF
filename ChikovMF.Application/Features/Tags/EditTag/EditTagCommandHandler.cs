using ChikovMF.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Tags.EditTag;

public class EditTagCommandHandler : IRequestHandler<EditTagCommand, Guid>
{
    public async Task<Guid> Handle(EditTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(tag => tag.TagId == request.TagId);

        tag.Name = request.Tag.Name;

        int changes = await _context.SaveChangesAsync(cancellationToken);

        if (changes > 0)
        {
            return tag.TagId;
        }
        else
        {
            return Guid.Empty;
        }
    }

    private readonly IChikovMFContext _context;

    public EditTagCommandHandler(IChikovMFContext context)
    {
        _context = context;
    }
}
