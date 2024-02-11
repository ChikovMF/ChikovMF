namespace ChikovMF.Entities;

public class Tag
{
    public Guid TagId { get; set; }
    public string Name { get; set; } = null!;

    public IList<ProjectTag>? ProjectLinks { get; set; }
}
