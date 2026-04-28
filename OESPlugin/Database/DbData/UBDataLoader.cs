using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Database.DbData
{
    public static class UBDataLoader
    {
        public static Dictionary<string, IBeamModel> Load()
        {
            return new Dictionary<string, IBeamModel>
            {
                ["1016x305x584"] = new IBeamModel
                {
                    Id = "1016x305x584",
                    DisplayName = "1016x305x584 UB",
                    SectionDesignation = "1016x305",
                    MassDesignation = "584",
                    Type = "UB",

                    Depth = 1056,
                    Width = 314,
                    WebThickness = 36,
                    FlangeThickness = 64,
                    RootRadius = 30,
                    DepthBetweenFillets = 868.1,

                    MassPerMetre = 584,
                    Area = 744
                },

                ["1016x305x494"] = new IBeamModel
                {
                    Id = "1016x305x494",
                    DisplayName = "1016x305x494 UB",
                    SectionDesignation = "1016x305",
                    MassDesignation = "494",
                    Type = "UB",

                    Depth = 1036,
                    Width = 309,
                    WebThickness = 31,
                    FlangeThickness = 54,
                    RootRadius = 30,
                    DepthBetweenFillets = 868.1,

                    MassPerMetre = 494,
                    Area = 629
                },

                ["1016x305x438"] = new IBeamModel
                {
                    Id = "1016x305x438",
                    DisplayName = "1016x305x438 UB",
                    SectionDesignation = "1016x305",
                    MassDesignation = "438",
                    Type = "UB",

                    Depth = 1026,
                    Width = 305,
                    WebThickness = 26.9,
                    FlangeThickness = 49,
                    RootRadius = 30,
                    DepthBetweenFillets = 868.1,

                    MassPerMetre = 438,
                    Area = 556
                },

                ["1016x305x415"] = new IBeamModel
                {
                    Id = "1016x305x415",
                    DisplayName = "1016x305x415 UB",
                    SectionDesignation = "1016x305",
                    MassDesignation = "415",
                    Type = "UB",

                    Depth = 1020,
                    Width = 304,
                    WebThickness = 26,
                    FlangeThickness = 46,
                    RootRadius = 30,
                    DepthBetweenFillets = 868.1,

                    MassPerMetre = 415,
                    Area = 529
                },

                ["1016x305x393"] = new IBeamModel
                {
                    Id = "1016x305x393",
                    DisplayName = "1016x305x393 UB",
                    SectionDesignation = "1016x305",
                    MassDesignation = "393",
                    Type = "UB",

                    Depth = 1016,
                    Width = 303,
                    WebThickness = 24.4,
                    FlangeThickness = 43.9,
                    RootRadius = 30,
                    DepthBetweenFillets = 868.1,

                    MassPerMetre = 392.7,
                    Area = 500
                }
            };
        }
    } 
}
