using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Models
{
    public class RHModel : SteelModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }
        public double ThicknessDesignation { get; set; }

        public double MassPerMetre { get; set; }
        public double Area { get; set; }

        
    }
}
