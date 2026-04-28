using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Database.Loaders
{
    public class LoadIBeam
    {
        public List<IBeamModel> DBLoadIBeams(string table)
        {
            var list = new List<IBeamModel>();
            var context = new DbContext();

            using (var conn = context.CreateConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM {table}";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new IBeamModel
                        {
                            SectionDesignation = reader["SectionDesignation"].ToString(),
                            MassDesignation = reader["MassDesignation"].ToString(),

                            Depth = Convert.ToDouble(reader["DepthOfSection_mm"]),
                            Width = Convert.ToDouble(reader["WidthOfSection_mm"]),
                            WebThickness = Convert.ToDouble(reader["WebThickness_mm"]),
                            FlangeThickness = Convert.ToDouble(reader["FlangeThickness_mm"]),
                            RootRadius = Convert.ToDouble(reader["RootRadius_mm"]),
                            DepthBetweenFillets = Convert.ToDouble(reader["DepthBetweenFillets_mm"])


                        });
                    }
                }
            }

            return list;
        }

        public IBeamModel GetIBeam(string steelType, string displayName)
        {
            Dictionary<string, IBeamModel> dictionary = null;
            if (dictionary == null) return null;

            switch (steelType)
            {
                case "UC":
                    dictionary = SectionData.UC;
                    break;
                case "UB":
                    dictionary = SectionData.UB;
                    break;

                default:
                    return null;
            }
            return dictionary.Values.FirstOrDefault(x => x.DisplayName == displayName);
        }
    }
}
