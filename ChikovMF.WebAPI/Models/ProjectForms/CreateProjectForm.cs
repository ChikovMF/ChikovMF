using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Application.Features.Projects.CreateProject;
using ChikovMF.Entities;

namespace ChikovMF.WebAPI.Models.ProjectForms;

public class CreateProjectForm : IMapWith<CreateProjectCommand>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;
    public ICollection<CreatePtojectTagForm>? Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProjectForm, CreateProjectCommand>()
            .ForMember(dest => dest.TagLinks, act => act.MapFrom(src => src.Tags)); ;
    }
}

public class CreatePtojectTagForm : IMapWith<ProjectTag>
{
    public int Order { get; set; }
    public Guid TagId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePtojectTagForm, ProjectTag>();
    }
}
