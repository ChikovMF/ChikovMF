namespace ChikovMF.Domain;

public class Project
{
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string DetailedDescription { get; set; } = null!;

    public ICollection<Tag>? Tags { get; set; }
    public ICollection<ImageLink>? Images { get; set; }
}
