using AutoMapper;
using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Application.Features.Projects.DetailProject;
using ChikovMF.Application.Features.Projects.Shared;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Projects.EditProject;

public class EditProjectQueryHandler : IRequestHandler<EditProjectQuery, ProjectDto>
{
    public async Task<ProjectDto> Handle(EditProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.AsNoTracking()
           .Include(p => p.Links)
           .Include(p => p.TagLinks!.OrderBy(tl => tl.Order))
           .FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundEntityException(nameof(Project), request.ProjectId);
        }

        var projectModel = _mapper.Map<ProjectDto>(project);

        return projectModel;
    }

    private readonly IChikovMFContext _context;
    private readonly IMapper _mapper;

    public EditProjectQueryHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
