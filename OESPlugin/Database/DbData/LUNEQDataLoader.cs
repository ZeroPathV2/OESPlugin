using OESPlugin.Models;
using System;
using System.Collections.Generic;

namespace OESPlugin.Database.DbData
{
    public static class LUNEQDataLoader
    {
        public static Dictionary<string, UAModel> Load()
        {
            return new Dictionary<string, UAModel>
            {
                ["200x150x18"] = new UAModel
                {
                    Id = "200x150x18",
                    DisplayName = "200x150x18 LUNEQ",

                    SectionDesignation = "200x150",
                    ThicknessDesignation = 18,

                    MassPerMetre = 47.1,
                    RadiusRoot = 15,
                    RadiusToe = 7.5,
                    DimensionCY = 6.33,
                    DimensionCZ = 3.85,
                    Area = 60.1
                },

                ["200x150x15"] = new UAModel
                {
                    Id = "200x150x15",
                    DisplayName = "200x150x15 LUNEQ",

                    SectionDesignation = "200x150",
                    ThicknessDesignation = 15,

                    MassPerMetre = 39.6,
                    RadiusRoot = 15,
                    RadiusToe = 7.5,
                    DimensionCY = 6.21,
                    DimensionCZ = 3.73,
                    Area = 50.5
                },

                ["200x150x12"] = new UAModel
                {
                    Id = "200x150x12",
                    DisplayName = "200x150x12 LUNEQ",

                    SectionDesignation = "200x150",
                    ThicknessDesignation = 12,

                    MassPerMetre = 32.0,
                    RadiusRoot = 15,
                    RadiusToe = 7.5,
                    DimensionCY = 6.08,
                    DimensionCZ = 3.61,
                    Area = 40.8
                },

                ["200x100x15"] = new UAModel
                {
                    Id = "200x100x15",
                    DisplayName = "200x100x15 LUNEQ",

                    SectionDesignation = "200x100",
                    ThicknessDesignation = 15,

                    MassPerMetre = 33.8,
                    RadiusRoot = 15,
                    RadiusToe = 7.5,
                    DimensionCY = 7.16,
                    DimensionCZ = 2.22,
                    Area = 43.0
                },

                ["200x100x12"] = new UAModel
                {
                    Id = "200x100x12",
                    DisplayName = "200x100x12 LUNEQ",

                    SectionDesignation = "200x100",
                    ThicknessDesignation = 12,

                    MassPerMetre = 27.3,
                    RadiusRoot = 15,
                    RadiusToe = 7.5,
                    DimensionCY = 7.03,
                    DimensionCZ = 2.10,
                    Area = 34.8
                }
            };
        }
    }
}