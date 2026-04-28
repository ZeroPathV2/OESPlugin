using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESPlugin.Database.Loaders
{
    public interface SectionRepo
    {
        List<string> GetSteelTypes();
        List<string> GetSectionNames(string steelType);
        SteelModel GetSection(string steelType, string id);
    }
}
