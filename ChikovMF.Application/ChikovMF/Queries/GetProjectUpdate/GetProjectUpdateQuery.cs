using MediatR;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectUpdate;

public class GetProjectUpdateQuery : IRequest<ProjectUpdateViewModel>
{
    public int ProjectId { get; set; }
}
