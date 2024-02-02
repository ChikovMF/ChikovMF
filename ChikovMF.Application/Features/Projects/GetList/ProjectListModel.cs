using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.GetList;

public class ProjectListModel
{
    public ICollection<ProjectItemListModel>? Projects { get; set; }
}

public class ProjectItemListModel : IMapWith<Project>
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<string>? Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectItemListModel>()
            .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.TagLinks!.Select(tl => tl.Tag.Name)));
    }
}
