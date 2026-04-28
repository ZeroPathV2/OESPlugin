using IntelliCAD.ApplicationServices;
using Microsoft.Data.Sqlite;
using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Database.Loaders
{
    public class LoadSection
    {
        private bool _mode;
        public LoadSection(bool mode)
        {
            _mode = mode;
        }
        public List<string> GetSteelTypes()
        {
            return new List<string> { "UC", "UB", "LUNEQ", "HFRH", "HFCH",};
        }

        public List<string> GetSectionNames(string steelType)
        {
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            switch (steelType)
            {
                case "UC":
                    return SectionData.UC.Values.Select(s => s.DisplayName).ToList();

                case "UB":
                    return SectionData.UB.Values.Select(s => s.DisplayName).ToList();

                case "LUNEQ":
                    return SectionData.LUNEQ.Values.Select(s => s.DisplayName).ToList();

                case "HFRH":
                    return SectionData.HFRH.Values.Select(s => s.DisplayName).ToList();

                case "HFCH":
                    return SectionData.HFCH.Values.Select(s => s.DisplayName).ToList();

                default:
                    ed.WriteMessage($"\nUnknown steel type: {steelType}");
                    return null;
            }
        }

        public List<SteelModel> GetSections(string steelType)
        {
            if (_mode)
                return GetFromSqlite(steelType);
            
            else
                return GetFromDictionary(steelType);

        }

        private List<SteelModel> GetFromDictionary(string steelType)
        {
            switch(steelType)
            {
                case "UC":
                    return SectionData.UC.Values.Cast<SteelModel>().ToList();
                case "UB":
                    return SectionData.UB.Values.Cast<SteelModel>().ToList();
                case "LUNEQ":
                    return SectionData.LUNEQ.Values.Cast<SteelModel>().ToList();
                case "HFRH":
                    return SectionData.HFRH.Values.Cast<SteelModel>().ToList();
                case "HFCH":
                    return SectionData.HFCH.Values.Cast<SteelModel>().ToList();
                default:
                    return new List<SteelModel>();
            }
        }

        private List<SteelModel> GetFromSqlite(string steelType)
        {
            var results = new List<SteelModel>();

            using (var conn = new DbContext().CreateConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT * FROM Sections WHERE SteelType = $type";

                cmd.Parameters.AddWithValue("$type", steelType);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(Map(reader, steelType));
                    }
                }
            }
            return results;
        }


        private SteelModel Map(SqliteDataReader r, string steelType)
        {
            switch (steelType)
            {
                case "UC":
                case "UB":
                    return new IBeamModel
                    {
                        Id = r["Id"].ToString(),
                        DisplayName = r["DisplayName"].ToString(),

                        Depth = Convert.ToDouble(r["Depth"]),
                        Width = Convert.ToDouble(r["Width"]),
                        WebThickness = Convert.ToDouble(r["WebThickness"]),
                        FlangeThickness = Convert.ToDouble(r["FlangeThickness"]),
                        RootRadius = Convert.ToDouble(r["RootRadius"]),

                        MassPerMetre = Convert.ToDouble(r["MassPerMetre"]),
                        Area = Convert.ToDouble(r["Area"])
                    };

                case "LUNEQ":
                    return new UAModel
                    {
                        Id = r["Id"].ToString(),
                        DisplayName = r["DisplayName"].ToString(),

                        ThicknessDesignation = Convert.ToDouble(r["Thickness"]),
                        RadiusRoot = Convert.ToDouble(r["RadiusRoot"]),
                        RadiusToe = Convert.ToDouble(r["RadiusToe"]),

                        Leg1 = Convert.ToDouble(r["Leg1"]),
                        Leg2 = Convert.ToDouble(r["Leg2"]),

                        Area = Convert.ToDouble(r["Area"])
                    };

                case "HFRH":
                    return new RHModel
                    {
                        Id = r["Id"].ToString(),
                        DisplayName = r["DisplayName"].ToString(),

                        Height = Convert.ToDouble(r["Height"]),
                        Width = Convert.ToDouble(r["Width"]),
                        ThicknessDesignation = Convert.ToDouble(r["Thickness"]),

                        Area = Convert.ToDouble(r["Area"]),
                        MassPerMetre = Convert.ToDouble(r["MassPerMetre"])
                    };

                case "HFCH":
                    return new CHModel
                    {
                        Id = r["Id"].ToString(),
                        DisplayName = r["DisplayName"].ToString(),

                        OutsideDiameter = Convert.ToDouble(r["OutsideDiameter"]),
                        ThicknessDesignation = Convert.ToDouble(r["Thickness"]),

                        Area = Convert.ToDouble(r["Area"]),
                        MassPerMetre = Convert.ToDouble(r["MassPerMetre"])
                    };

                default:
                    return null;
            }
        }
    }
}

