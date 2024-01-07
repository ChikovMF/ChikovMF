using ChikovMF.Domain;
using MediatR;

namespace ChikovMF.Application.ChikovMF.Commands.CreateProject;

public class CreateProjectCommand : IRequest<int>
{
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string DetailedDescription { get; set; } = null!;

    public Project CreateProject()
    {
        return new Project()
        {
            Title = Title,
            ShortDescription = ShortDescription,
            DetailedDescription = DetailedDescription,
        };
    }
}
