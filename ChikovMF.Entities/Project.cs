namespace ChikovMF.Entities;

public class Project
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;

    public IList<ProjectTag>? TagLinks { get; set; }
    public IList<ProjectImage>? Images { get; set; }
}
