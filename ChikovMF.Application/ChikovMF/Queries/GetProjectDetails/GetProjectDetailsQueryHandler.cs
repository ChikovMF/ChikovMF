using AutoMapper;
using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Interfaces;
using ChikovMF.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;

public class GetProjectDetailsQueryHandler
    : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsViewModel>
{
    private readonly IChikovMFDbContext _context;
    private readonly IMapper _mapper;

    public GetProjectDetailsQueryHandler(IChikovMFDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProjectDetailsViewModel> Handle(GetProjectDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var project = await _context.Projects.AsNoTracking()
            .Include(p => p.Tags)
            .Include(p => p.Images)
            .FirstOrDefaultAsync(project => project.ProjectId == request.ProjectId,
                cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.ProjectId);
        }

        return _mapper.Map<ProjectDetailsViewModel>(project);
    }
}
