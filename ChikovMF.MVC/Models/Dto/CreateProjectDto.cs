using AutoMapper;
using ChikovMF.Application.ChikovMF.Commands.CreateProject;
using ChikovMF.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace ChikovMF.MVC.Models.Dto
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand>
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string ShortDescription { get; set; } = null!;
        public string? DetailedDescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>();
        }
    }
}
