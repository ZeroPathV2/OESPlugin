using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Models
{
    public class UAModel : SteelModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public string SectionDesignation { get; set; }

        public double ThicknessDesignation { get; set; }
        public double RadiusRoot { get; set; }
        public double RadiusToe { get; set; }

        public double DimensionCY { get; set; }
        public double DimensionCZ { get; set; }

        public double MassPerMetre { get; set; }
        public double Area { get; set; }

        public double Leg1 { get; set; }
        public double Leg2 { get; set; }
    }
}
