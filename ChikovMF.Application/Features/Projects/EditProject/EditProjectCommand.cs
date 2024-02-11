using MediatR;

namespace ChikovMF.Application.Features.Projects.EditProject;

public class EditProjectCommand : IRequest<Guid>
{
    public Guid ProjectId { get; set; }
    public EditProjectModel Project { get; set; } = null!;
}
