using ChikovMF.Application.Interfaces;
using ChikovMF.Domain;
using MediatR;

namespace ChikovMF.Application.ChikovMF.Commands.CreateProject;

public class CreateProjectCommandHandler
    : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IChikovMFDbContext _context;

    public CreateProjectCommandHandler(IChikovMFDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProjectCommand request, 
        CancellationToken cancellationToken)
    {
        var project = new Project()
        {
            ProjectId = request.ProjectId,
            Title = request.Title,
            ShortDescription = request.Description,
            Tags = request.Tags,
        };

        await _context.Projects.AddAsync(project, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return project.ProjectId;
    }
}
