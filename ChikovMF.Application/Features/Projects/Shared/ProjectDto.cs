using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.Shared;

public class ProjectDto : IMapWith<Project>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;
    public ICollection<ProjectTagDto>? Tags { get; set; }
    public ICollection<ProjectLinkDto>? Links { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectDto, Project>()
            .ForMember(dest => dest.TagLinks, act => act.MapFrom(src => src.Tags));
            
        profile.CreateMap<Project, ProjectDto>()
            .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.TagLinks));
    }
}

public class ProjectTagDto : IMapWith<ProjectTag>
{
    public int Order { get; set; }
    public Guid TagId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectTagDto, ProjectTag>();
        profile.CreateMap<ProjectTag, ProjectTagDto>();
    }
}

public class ProjectLinkDto : IMapWith<ProjectLink>
{
    public string Name { get; set; } = null!;
    public Uri Url { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectLinkDto, ProjectLink>();
        profile.CreateMap<ProjectLink, ProjectLinkDto>();
    }
}
