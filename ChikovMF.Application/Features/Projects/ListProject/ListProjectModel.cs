using AutoMapper;
using ChikovMF.Application.Common.Mappings;
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
    public Image? Image { get; set; }
    public ICollection<string>? Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectItemListModel>()
            .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Images!.FirstOrDefault(i => i.ImageType == ImageType.Card)))
            .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.TagLinks!.Select(tl => tl.Tag.Name)));
    }
}

public class Image : IMapWith<ProjectImage>
{
    public string Src { get; set; } = null!;
    public string Alt { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectImage, Image>();
    }
}
