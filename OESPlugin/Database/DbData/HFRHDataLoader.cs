using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Database.DbData
{
    public static class HFRHDataLoader
    {
        public static Dictionary<string, RHModel> Load()
        {
            return new Dictionary<string, RHModel>
            {
                ["50x30x3.2"] = new RHModel
                {
                    Id = "50x30x3.2",
                    DisplayName = "50x30x3.2 RHS",

                    Height = 50,
                    Width = 30,
                    ThicknessDesignation = 3.2,

                    MassPerMetre = 3.61,
                    Area = 4.6
                },

                ["50x30x3.6"] = new RHModel
                {
                    Id = "50x30x3.6",
                    DisplayName = "50x30x3.6 RHS",

                    Height = 50,
                    Width = 30,
                    ThicknessDesignation = 3.6,

                    MassPerMetre = 4.01,
                    Area = 5.1
                },

                ["50x30x4.0"] = new RHModel
                {
                    Id = "50x30x4.0",
                    DisplayName = "50x30x4.0 RHS",

                    Height = 50,
                    Width = 30,
                    ThicknessDesignation = 4.0,

                    MassPerMetre = 4.39,
                    Area = 5.59
                },

                ["50x30x5.0"] = new RHModel
                {
                    Id = "50x30x5.0",
                    DisplayName = "50x30x5.0 RHS",

                    Height = 50,
                    Width = 30,
                    ThicknessDesignation = 5.0,

                    MassPerMetre = 5.28,
                    Area = 6.73
                },

                ["50x30x6.3"] = new RHModel
                {
                    Id = "50x30x6.3",
                    DisplayName = "50x30x6.3 RHS",

                    Height = 50,
                    Width = 30,
                    ThicknessDesignation = 6.3,

                    MassPerMetre = 6.33,
                    Area = 8.07
                }
            };
        }
    }
}
