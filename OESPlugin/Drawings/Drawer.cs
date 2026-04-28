using IntelliCAD.ApplicationServices;
using OESPlugin.Models;
using OESPlugin.Models.Drawings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace OESPlugin.Drawings
{
    public static class Drawer
    {
        public static DBObjectCollection BuildEntity(string type, SteelModel model)
        {
            switch (type)
            {
                case "UB":
                case "UC":
                    return Wrap(new IBeamDrawer().BuildPolyline(model as IBeamModel));

                case "LUNEQ":
                    return Wrap(new UADrawer().BuildPolyline(model as UAModel));

                case "HFCH":
                    return new CHDrawer().Build(model as CHModel);

                case "HFRH":
                    return new RHSDrawer().Build(model as RHModel);

                default:
                    return null;
            }
        }

        private static DBObjectCollection Wrap(Entity e)
        {
            var col = new DBObjectCollection();
            col.Add(e);
            return col;
        }
    }
}
