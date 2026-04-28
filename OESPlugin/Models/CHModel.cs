using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Models
{
    public class CHModel : SteelModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public double OutsideDiameter { get; set; }
        public double ThicknessDesignation { get; set; }

        public double MassPerMetre { get; set; }
        public double Area { get; set; }

        public double InsideDiameter => OutsideDiameter - 2 * ThicknessDesignation;
    }
}
