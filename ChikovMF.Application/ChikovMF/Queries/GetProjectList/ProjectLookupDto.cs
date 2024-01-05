using AutoMapper;
using ChikovMF.Application.ChikovMF.Queries.GetProjectDetails;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<Project>
    {
        public int ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;

        public ICollection<Tag>? Tags { get; set; }
        public ICollection<ImageLink>? Images { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookupDto>();
        }
    }
}
