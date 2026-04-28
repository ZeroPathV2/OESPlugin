using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Models
{
    public class IBeamModel : SteelModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public string SectionDesignation { get; set; }
        public string MassDesignation { get; set; }

        public double Depth { get; set; }
        public double Width { get; set; }
        public double WebThickness { get; set; }
        public double FlangeThickness { get; set; }
        public double RootRadius { get; set; }
        public double DepthBetweenFillets { get; set; }

        public double MassPerMetre { get; set; }
        public double Area { get; set; }

        public string Type { get; set; }

        
    }
}
