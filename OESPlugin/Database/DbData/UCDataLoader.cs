using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Database.DbData
{
    public static class UCDataLoader
    {
        public static Dictionary<string, IBeamModel> Load()
        {
            return new Dictionary<string, IBeamModel>
            {

                ["356x406x1299"] = new IBeamModel
                {
                    Id = "356x406x1299",
                    DisplayName = "356x406x1299 UC",
                    SectionDesignation = "356x406",
                    MassDesignation = "1299",
                    Type = "UC",

                    Depth = 600,
                    Width = 476,
                    WebThickness = 100,
                    FlangeThickness = 140,
                    RootRadius = 15.4,
                    DepthBetweenFillets = 290,

                    MassPerMetre = 1299,
                    Area = 1655
                },

                ["356x406x1202"] = new IBeamModel
                {
                    Id = "356x406x1202",
                    DisplayName = "356x406x1202 UC",
                    SectionDesignation = "356x406",
                    MassDesignation = "1202",
                    Type = "UC",

                    Depth = 580,
                    Width = 471,
                    WebThickness = 95,
                    FlangeThickness = 130,
                    RootRadius = 15.4,
                    DepthBetweenFillets = 290,

                    MassPerMetre = 1202,
                    Area = 1531
                },

                ["356x406x1086"] = new IBeamModel
                {
                    Id = "356x406x1086",
                    DisplayName = "356x406x1086 UC",
                    SectionDesignation = "356x406",
                    MassDesignation = "1086",
                    Type = "UC",

                    Depth = 569,
                    Width = 454,
                    WebThickness = 78,
                    FlangeThickness = 125,
                    RootRadius = 15,
                    DepthBetweenFillets = 290,

                    MassPerMetre = 1086,
                    Area = 1386
                },

                ["356x406x990"] = new IBeamModel
                {
                    Id = "356x406x990",
                    DisplayName = "356x406x990 UC",
                    SectionDesignation = "356x406",
                    MassDesignation = "990",
                    Type = "UC",

                    Depth = 550,
                    Width = 448,
                    WebThickness = 71.9,
                    FlangeThickness = 115,
                    RootRadius = 15,
                    DepthBetweenFillets = 290,

                    MassPerMetre = 990,
                    Area = 1262
                },

                ["356x406x900"] = new IBeamModel
                {
                    Id = "356x406x900",
                    DisplayName = "356x406x900 UC",
                    SectionDesignation = "356x406",
                    MassDesignation = "900",
                    Type = "UC",

                    Depth = 531,
                    Width = 442,
                    WebThickness = 65.9,
                    FlangeThickness = 106,
                    RootRadius = 15,
                    DepthBetweenFillets = 290,

                    MassPerMetre = 900,
                    Area = 1149
                }
            };
        }
    }
}
