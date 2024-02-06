using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.CreateProject;

public class CreateProjectModel : IMapWith<Project>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;
    public ICollection<CreatePtojectTagModel>? Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProjectModel, Project>()
            .ForMember(dest => dest.TagLinks, act => act.MapFrom(src => src.Tags));
    }
}

public class CreatePtojectTagModel : IMapWith<ProjectTag>
{
    public int Order { get; set; }
    public Guid TagId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePtojectTagModel, ProjectTag>();
    }
}
