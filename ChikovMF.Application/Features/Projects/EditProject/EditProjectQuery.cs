using ChikovMF.Application.Features.Projects.Shared;
using MediatR;

namespace ChikovMF.Application.Features.Projects.EditProject;

public class EditProjectQuery : IRequest<ProjectDto>
{
    public Guid ProjectId { get; set; }
}
