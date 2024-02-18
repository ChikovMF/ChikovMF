using AutoMapper;
using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Tags.EditTag;

public class EditTagQueryHandler : IRequestHandler<EditTagQuery, EditTagModel>
{
    public async Task<EditTagModel> Handle(EditTagQuery request, CancellationToken cancellationToken)
    {
        var tag = await _context.Tags.AsNoTracking()
            .FirstOrDefaultAsync(tag => tag.TagId == request.TagId, cancellationToken);

        if (tag == null)
        {
            throw new NotFoundEntityException(nameof(Tag), request.TagId);
        }

        var tagModel = _mapper.Map<EditTagModel>(tag);

        return tagModel;
    }

    private readonly IChikovMFContext _context;
    private readonly IMapper _mapper;

    public EditTagQueryHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
