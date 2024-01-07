using AutoMapper;
using ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;
using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Interfaces;
using ChikovMF.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectUpdate;

public class GetProjectUpdateQueryHandler : IRequestHandler<GetProjectUpdateQuery, ProjectUpdateViewModel>
{
    private readonly IChikovMFDbContext _context;
    private readonly IMapper _mapper;

    public GetProjectUpdateQueryHandler(IChikovMFDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProjectUpdateViewModel> Handle(GetProjectUpdateQuery request, 
        CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .FirstOrDefaultAsync(project => project.ProjectId == request.ProjectId,
                cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.ProjectId);
        }

        return _mapper.Map<ProjectUpdateViewModel>(project);
    }
}
