using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChikovMF.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Projects.GetListProject;

public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListModel>
{
    public async Task<ProjectListModel> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
    {
        var projects = await _context.Projects.AsNoTracking()
            .Include(p => p.TagLinks)!
                .ThenInclude(tl => tl.Tag)
            .ProjectTo<ProjectItemListModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProjectListModel() { Projects = projects };
    }

    private readonly IChikovMFContext _context;
    private readonly IMapper _mapper;

    public GetProjectListQueryHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
