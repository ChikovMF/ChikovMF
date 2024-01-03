using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChikovMF.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectList;

public class GetProjectListQueryHandler
    : IRequestHandler<GetProjectListQuery, ProjectListViewModel>
{
    private readonly IChikovMFDbContext _context;
    private readonly IMapper _mapper;

    public GetProjectListQueryHandler(IChikovMFDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProjectListViewModel> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
    {
        var projects = await _context.Projects.AsNoTracking()
            .Include(p => p.Tags)
            .Include(p => p.Images.Where(i => i.MainImage))
            .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProjectListViewModel() { Projects = projects };
    }
}
