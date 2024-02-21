using AutoMapper;
using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Projects.DetailProject;

public class DetailProjectQueryHandler : IRequestHandler<DetailProjectQuery, DetailProjectModel>
{
    public async Task<DetailProjectModel> Handle(DetailProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.AsNoTracking()
            .Include(p => p.Images)
            .Include(p => p.Links)
            .Include(p => p.TagLinks)!
                .ThenInclude(tl => tl.Tag)
            .FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundEntityException(nameof(Project), request.ProjectId);
        }

        var projectModel = _mapper.Map<DetailProjectModel>(project);

        return projectModel;
    }

    private readonly IChikovMFContext _context;
    private readonly IMapper _mapper;

    public DetailProjectQueryHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
