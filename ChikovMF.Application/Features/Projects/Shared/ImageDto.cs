using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.Shared;

public class ImageDto : IMapWith<ProjectImage>
{
    public Guid ProjectImageId { get; set; }
    public string Src { get; set; } = null!;
    public string Alt { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectImage, ImageDto>();
    }
}
