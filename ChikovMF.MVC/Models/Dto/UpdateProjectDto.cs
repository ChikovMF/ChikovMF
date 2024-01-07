using AutoMapper;
using ChikovMF.Application.ChikovMF.Commands.UpdateProject;
using ChikovMF.Application.ChikovMF.Queries.GetProjectUpdate;
using ChikovMF.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace ChikovMF.MVC.Models.Dto;

public class UpdateProjectDto : IMapWith<UpdateProjectCommand>, IMapWith<ProjectUpdateViewModel>
{
    public int ProjectId { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string ShortDescription { get; set; } = null!;
    public string? DetailedDescription { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectUpdateViewModel, UpdateProjectDto>();
        profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>();
    }
}
