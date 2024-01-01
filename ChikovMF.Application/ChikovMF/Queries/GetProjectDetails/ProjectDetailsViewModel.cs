using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Domain;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectDetails
{
    public class ProjectDetailsViewModel : IMapWith<Project>
    {
        public int ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Tag>? Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsViewModel>();
        }
    }
}