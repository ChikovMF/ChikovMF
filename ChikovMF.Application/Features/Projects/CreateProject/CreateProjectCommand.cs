using ChikovMF.Entities;
using MediatR;

namespace ChikovMF.Application.Features.Projects.CreateProject;

public class CreateProjectCommand : IRequest<Guid>
{
    public CreateProjectModel Project { get; set; } = null!;
}
