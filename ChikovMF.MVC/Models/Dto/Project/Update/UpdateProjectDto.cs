using AutoMapper;
using ChikovMF.Application.ChikovMF.Commands.UpdateProject;
using ChikovMF.Application.ChikovMF.Queries.GetProjectUpdate;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Domain;
using System.ComponentModel.DataAnnotations;

namespace ChikovMF.MVC.Models.Dto.Project.Update;

public class UpdateProjectDto : IMapWith<UpdateProjectCommand>, IMapWith<ProjectUpdateViewModel>
{
    public int? ProjectId { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string ShortDescription { get; set; } = null!;
    public string? DetailedDescription { get; set; }

    public IList<UpdateProjectLinkDto>? ProjectLinks { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectUpdateViewModel, UpdateProjectDto>();
        profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>();
        profile.CreateMap<UpdateProjectLinkDto, ProjectLink>();
        profile.CreateMap<ProjectLinkUpdateSubModel, UpdateProjectLinkDto>();
    }
}
