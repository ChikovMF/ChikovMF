namespace ChikovMF.Entities;

public class ProjectLink
{
    public Guid ProjectLinkId { get; set; }
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
    public Uri Url { get; set; } = null!;

    public Project Project { get; set; } = null!;
}
