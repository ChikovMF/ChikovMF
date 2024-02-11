using MediatR;

namespace ChikovMF.Application.Features.Projects.DetailProject;

public class DetailProjectQuery : IRequest<DetailProjectModel>
{
    public Guid ProjectId { get; set; }
}
