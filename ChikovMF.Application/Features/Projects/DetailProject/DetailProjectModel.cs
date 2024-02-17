using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Application.Features.Projects.Shared;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.DetailProject;

public class DetailProjectModel : IMapWith<Project>
{
    public string Name { get; set; } = null!;
    public string Content { get; set; } = null!;

    public ICollection<string>? Tags { get; set; }
    public ICollection<ImageDto>? Images { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, DetailProjectModel>()
            .ForMember(dest => dest.Images, act => act.MapFrom(src => src.Images!.Where(i => i.ImageType == ImageType.Slide)))
            .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.TagLinks!.Select(tl => tl.Tag.Name)));
    }
}
