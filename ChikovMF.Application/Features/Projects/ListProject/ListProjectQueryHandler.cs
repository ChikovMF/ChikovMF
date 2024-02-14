using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChikovMF.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Projects.GetListProject;

public class ListProjectQueryHandler : IRequestHandler<ListProjectQuery, ListProjectModel>
{
    public async Task<ListProjectModel> Handle(ListProjectQuery request, CancellationToken cancellationToken)
    {
        var projects = await _context.Projects.AsNoTracking()
            .Include(p => p.Images)
            .Include(p => p.TagLinks)!
                .ThenInclude(tl => tl.Tag)
            .ProjectTo<ProjectItemListModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ListProjectModel() { Projects = projects };
    }

    private readonly IChikovMFContext _context;
    private readonly IMapper _mapper;

    public ListProjectQueryHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
