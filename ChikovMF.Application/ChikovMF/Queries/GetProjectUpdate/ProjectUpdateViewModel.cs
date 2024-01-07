using AutoMapper;
using ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Domain;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectUpdate;

public class ProjectUpdateViewModel : IMapWith<Project>
{
    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string? DetailedDescription { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectUpdateViewModel>();
    }
}
