using ChikovMF.Domain;
using MediatR;

namespace ChikovMF.Application.ChikovMF.Commands.CreateProject;

public class CreateProjectCommand : IRequest<int>
{
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Tag>? Tags { get; set; }
}
