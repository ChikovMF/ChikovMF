using MediatR;

namespace ChikovMF.Application.Features.Projects.EditProject;

public class EditProjectQuery : IRequest<EditProjectModel>
{
    public Guid ProjectId { get; set; }
}
