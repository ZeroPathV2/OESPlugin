using IntelliCAD.ApplicationServices;
using IntelliCAD.EditorInput;
using OESPlugin.Database.Loaders;
using OESPlugin.Drawings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.DatabaseServices;
using Teigha.Geometry;
using Teigha.Runtime;

namespace OESPlugin.Commands
{
   public static class RunClass
    {
        public static void Run(bool mode)
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            var loader = new LoadSection(mode);

            var options = new PromptKeywordOptions("\nSelect steel type:");
            options.Keywords.Add("UC");
            options.Keywords.Add("UB");
            options.Keywords.Add("LUNEQ");
            options.Keywords.Add("HFCH");
            options.Keywords.Add("HFRH");
            options.AllowNone = false;

            var typeRes = ed.GetKeywords(options);
            if (typeRes.Status != PromptStatus.OK)
                return;

            var steelType = typeRes.StringResult;

            // gets sizes of steelType
            var models = loader.GetSections(steelType);
            if (models == null || models.Count == 0)
            {
                ed.WriteMessage("\n No sections found.");
                return;
            }

            ed.WriteMessage("\nAvailable sections:");
            for (int i = 0; i < models.Count; i++)
            {
                ed.WriteMessage($"\n[{i}] {models[i].DisplayName}");
            }

            var intRes = ed.GetInteger("\nEnter section number:");
            if (intRes.Status != PromptStatus.OK)
                return;

            int index = intRes.Value;
            if (index < 0 || index >= models.Count)
            {
                ed.WriteMessage("\nInvalid selection.");
                return;
            }

            var selectedModel = models[index];

            var entities = Drawer.BuildEntity(steelType, selectedModel);
            if (entities == null)
            {
                ed.WriteMessage("\nFailed to create entity.");
                return;
            }

            var jig = new SteelJig(entities);

            var res = ed.Drag(jig);

            if (res.Status != PromptStatus.OK)
                return;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);


                foreach (Entity ent in entities)
                {
                    ent.TransformBy(
                    Matrix3d.Rotation(jig.Angle, Vector3d.ZAxis, Point3d.Origin) *
                    Matrix3d.Displacement(jig.Position.GetAsVector()));

                    btr.AppendEntity(ent);
                    tr.AddNewlyCreatedDBObject(ent, true);
                }
                

                tr.Commit();
            }
        }
    }
}