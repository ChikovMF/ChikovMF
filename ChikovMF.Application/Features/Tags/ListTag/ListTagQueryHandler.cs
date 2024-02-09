using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChikovMF.Application.Features.Projects.GetListProject;
using ChikovMF.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Tags.ListTag;

public class ListTagQueryHandler : IRequestHandler<ListTagQuery, ListTagModel>
{
    public async Task<ListTagModel> Handle(ListTagQuery request, CancellationToken cancellationToken)
    {
        var tags = await _context.Tags.AsNoTracking()
            .ProjectTo<TagItemListModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ListTagModel() { Tags = tags };
    }

    private readonly IChikovMFContext _context;
    private readonly IMapper _mapper;

    public ListTagQueryHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
