namespace ChikovMF.MVC.Models.Dto.Project.Update
{
    public class UpdateProjectLinkDto
    {
        public int ProjectLinkId { get; set; }
        public string LinkName { get; set; } = null!;
        public string LinkUrl { get; set; } = null!;
    }
}
