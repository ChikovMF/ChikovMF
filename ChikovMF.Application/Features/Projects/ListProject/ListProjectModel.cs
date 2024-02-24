using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Application.Features.Projects.Shared;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.GetListProject;

public class ListProjectModel
{
    public ICollection<ProjectItemListModel>? Projects { get; set; }
}

public class ProjectItemListModel : IMapWith<Project>
{
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ImageDto? Image { get; set; }
    public ICollection<string>? Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectItemListModel>()
            .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Images!.FirstOrDefault(i => i.ImageType == ImageType.Card)))
            .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.TagLinks!.OrderBy(t => t.Order).Select(tl => tl.Tag.Name)));
    }
}
