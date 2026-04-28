using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OESPlugin.Database.DbData;
using OESPlugin.Models;

namespace OESPlugin.Database
{
    public static class SectionData
    {
        public static Dictionary<string, IBeamModel> UC { get; private set; }
        public static Dictionary<string, IBeamModel> UB { get; private set; }
        public static Dictionary<string, UAModel> LUNEQ { get; private set; }
        public static Dictionary<string, RHModel> HFRH { get; private set; }
        public static Dictionary<string, CHModel> HFCH { get; private set; }

        static SectionData()
        {
            UC = DbData.UCDataLoader.Load();
            UB = DbData.UBDataLoader.Load();
            LUNEQ = DbData.LUNEQDataLoader.Load();
            HFRH = DbData.HFRHDataLoader.Load();
            HFCH = DbData.HFCHDataLoader.Load();
        }
    }
}
