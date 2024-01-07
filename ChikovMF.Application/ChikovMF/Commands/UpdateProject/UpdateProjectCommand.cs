using ChikovMF.Domain;
using MediatR;

namespace ChikovMF.Application.ChikovMF.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<int>
{
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string DetailedDescription { get; set; } = null!;

    public void UpdateProject(Project project)
    {
        project.Title = Title;
        project.ShortDescription = ShortDescription;
        project.DetailedDescription = DetailedDescription;
    }
}
