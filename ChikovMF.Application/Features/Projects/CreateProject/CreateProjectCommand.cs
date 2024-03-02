using ChikovMF.Application.Features.Projects.Shared;
using ChikovMF.Entities;
using MediatR;

namespace ChikovMF.Application.Features.Projects.CreateProject;

public class CreateProjectCommand : IRequest<Guid>
{
    public ProjectDto Project { get; set; } = null!;
}
