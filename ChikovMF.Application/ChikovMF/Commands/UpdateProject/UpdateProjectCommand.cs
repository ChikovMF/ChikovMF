using ChikovMF.Domain;
using MediatR;

namespace ChikovMF.Application.ChikovMF.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest
{
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Tag>? Tags { get; set; }

    internal void UpdateProject(Project project)
    {
        project.Title = Title;
        project.Description = Description;
        project.Tags = Tags;
    }
}
