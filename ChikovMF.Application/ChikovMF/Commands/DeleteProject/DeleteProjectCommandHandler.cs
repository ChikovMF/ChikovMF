using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Interfaces;
using ChikovMF.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.ChikovMF.Commands.DeleteProject;

public class DeleteProjectCommandHandler
    : IRequestHandler<DeleteProjectCommand>
{
    private readonly IChikovMFDbContext _context;

    public DeleteProjectCommandHandler(IChikovMFDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .FindAsync(new object[] { request.ProjectId },
            cancellationToken);

        if (project == null)
        {
            throw new NotFoundException(nameof(Project), request.ProjectId);
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
