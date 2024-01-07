using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Interfaces;
using ChikovMF.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.ChikovMF.Commands.UpdateProject;

public class UpdateProjectCommandHandler
    : IRequestHandler<UpdateProjectCommand, int>
{
    private readonly IChikovMFDbContext _context;

    public UpdateProjectCommandHandler(IChikovMFDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateProjectCommand request,
        CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .FirstOrDefaultAsync(project =>
                project.ProjectId == request.ProjectId,
                cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.ProjectId);
        }

        request.UpdateProject(project);

        await _context.SaveChangesAsync(cancellationToken);

        return project.ProjectId;
    }
}
