using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Projects.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundEntityException(nameof(Project), request.ProjectId);
        }

        string pathLocation = Path.Combine(Directory.GetCurrentDirectory(), $"Images");

        foreach (var image in project.Images!)
        {
            string saveLocation = Path.Combine(pathLocation, image.FileName);
            if (File.Exists(saveLocation) && !string.IsNullOrWhiteSpace(image.FileName))
            {
                File.Delete(saveLocation);
            }
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private readonly IChikovMFContext _context;

    public DeleteProjectCommandHandler(IChikovMFContext context)
    {
        _context = context;
    }
}
