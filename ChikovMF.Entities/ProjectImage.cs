namespace ChikovMF.Entities;

public class ProjectImage
{
    public Guid ProjectImageId { get; set; }
    public Guid ProjectId { get; set; }
    public ImageType ImageType { get; set; }
    public string Src { get; set; } = null!;
    public string Alt { get; set; } = null!;
    public string FileName { get; set; } = null!;

    public Project Project { get; set; } = null!;
}

public enum ImageType
{
    Card,
    Slide
}
