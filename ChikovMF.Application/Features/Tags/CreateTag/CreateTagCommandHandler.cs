using AutoMapper;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;

namespace ChikovMF.Application.Features.Tags.CreateTag;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Guid>
{
    public async Task<Guid> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        Tag tag = _mapper.Map<Tag>(request.Tag);

        _context.Tags.Add(tag);

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
    private readonly IMapper _mapper;

    public CreateTagCommandHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
