using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChikovMF.Application.ChikovMF.Queries.GetProjectUpdate
{
    public class ProjectLinkUpdateSubModel
    {
        public int ProjectLinkId { get; set; }
        public string LinkName { get; set; } = null!;
        public string LinkUrl { get; set; } = null!;
    }
}
