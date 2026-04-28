using IntelliCAD.ApplicationServices;
using IntelliCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Runtime;
using SQLitePCL;

using OESPlugin.Database.Loaders;
using OESPlugin.Drawings;
using OESPlugin.Models;

namespace OESPlugin.Commands
{
    public class DrawSteelClass
    {
        [CommandMethod("DRAWSTEEL")]
        public void DrawSteel()
        {
            RunClass.Run(false);
        }

        [CommandMethod("DBSTEEL")]
        public void DbDrawSteel()
        {
            RunClass.Run(true);
        }

    }
}
