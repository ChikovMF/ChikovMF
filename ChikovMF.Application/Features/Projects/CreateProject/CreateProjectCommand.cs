using ChikovMF.Entities;
using MediatR;

namespace ChikovMF.Application.Features.Projects.CreateProject;

public class CreateProjectCommand : IRequest<Guid>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;

    public ICollection<ProjectTag> TagLinks { get; set; } = null!;
}
