using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Application.Features.Projects.Shared;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Projects.EditProject;

public class EditProjectModel : IMapWith<Tag>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;

    public ICollection<LinkDto>? Links { get; set; }
    public ICollection<EditPtojectTagModel>? Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, EditProjectModel>()
            .ForMember(dest => dest.Tags, act => act.MapFrom(src => src.TagLinks));
    }
}

public class EditPtojectTagModel : IMapWith<ProjectTag>
{
    public int Order { get; set; }
    public Guid TagId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectTag, EditPtojectTagModel>();
    }
}
