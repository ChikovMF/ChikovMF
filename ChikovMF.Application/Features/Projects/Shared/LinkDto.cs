using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.Shared;

public class LinkDto : IMapWith<ProjectLink>
{
    public string Name { get; set; } = null!;
    public Uri Url { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LinkDto, ProjectLink>();
        profile.CreateMap<ProjectLink, LinkDto>();
    }
}
