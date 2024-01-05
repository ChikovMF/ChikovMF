namespace ChikovMF.Domain;

public class Project
{
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string DetailedDescription { get; set; } = null!;

    public ICollection<Tag>? Tags { get; set; }
    public ICollection<ImageLink>? ImageLinks { get; set; }
    public ICollection<ProjectLink>? ProjectLinks { get; set; }
}
