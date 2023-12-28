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
    }
}
