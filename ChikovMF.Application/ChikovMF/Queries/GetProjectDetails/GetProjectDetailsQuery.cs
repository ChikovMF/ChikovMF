using MediatR;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;

public class GetProjectDetailsQuery : IRequest<ProjectDetailsViewModel>
{
    public int ProjectId { get; set; }
}
