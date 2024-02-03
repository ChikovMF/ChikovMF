using MediatR;

namespace ChikovMF.Application.Features.Projects.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
    }
}
