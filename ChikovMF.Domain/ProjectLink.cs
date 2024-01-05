using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChikovMF.Domain
{
    public class ProjectLink
    {
        public int ProjectLinkId { get; set; }
        public string LinkName { get; set; } = null!;
        public string LinkUrl { get; set; } = null!;


        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
