using MediatR;

namespace ChikovMF.Application.ChikovMF.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public int ProjectId { get; set; }
}
