using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Database.DbData
{
    public static class HFCHDataLoader
    {
        public static Dictionary<string, CHModel> Load()
        {
            return new Dictionary<string, CHModel>
            {
                ["42.4x3.2"] = new CHModel
                {
                    Id = "42.4x3.2",
                    DisplayName = "42.4x3.2 CHS",

                    OutsideDiameter = 42.4,
                    ThicknessDesignation = 3.2,

                    MassPerMetre = 3.09,
                    Area = 3.94
                },

                ["42.4x3.6"] = new CHModel
                {
                    Id = "42.4x3.6",
                    DisplayName = "42.4x3.6 CHS",

                    OutsideDiameter = 42.4,
                    ThicknessDesignation = 3.6,

                    MassPerMetre = 3.44,
                    Area = 4.39
                },

                ["42.4x4.0"] = new CHModel
                {
                    Id = "42.4x4.0",
                    DisplayName = "42.4x4.0 CHS",

                    OutsideDiameter = 42.4,
                    ThicknessDesignation = 4.0,

                    MassPerMetre = 3.79,
                    Area = 4.83
                },

                ["42.4x5.0"] = new CHModel
                {
                    Id = "42.4x5.0",
                    DisplayName = "42.4x5.0 CHS",

                    OutsideDiameter = 42.4,
                    ThicknessDesignation = 5.0,

                    MassPerMetre = 4.61,
                    Area = 5.87
                },

                ["48.3x3.2"] = new CHModel
                {
                    Id = "48.3x3.2",
                    DisplayName = "48.3x3.2 CHS",

                    OutsideDiameter = 48.3,
                    ThicknessDesignation = 3.2,

                    MassPerMetre = 3.56,
                    Area = 4.53
                }
            };
        }
    }
}
