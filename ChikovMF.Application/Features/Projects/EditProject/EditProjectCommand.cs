using ChikovMF.Application.Features.Projects.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Projects.EditProject;

public class EditProjectCommand : IRequest<Guid>
{
    public Guid ProjectId { get; set; }
    public ProjectDto Project { get; set; } = null!;
}
