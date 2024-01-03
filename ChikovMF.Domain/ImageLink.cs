using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChikovMF.Domain
{
    public class ImageLink
    {
        public int ImageLinkId { get; set; }
        public string Link { get; set; } = null!;
        public bool MainImage { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
