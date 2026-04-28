using IntelliCAD.ApplicationServices;
using OESPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace OESPlugin.Drawings
{
    public class CHDrawer
    {
        public void Draw(CHModel s, Point3d pt)
        {
            var db = Application.DocumentManager.MdiActiveDocument.Database;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                double R = s.OutsideDiameter / 2.0;
                double r = s.ThicknessDesignation;

                var outer = new Circle(pt, Vector3d.ZAxis, R);
                var inner = new Circle(pt, Vector3d.ZAxis, R - r);

                btr.AppendEntity(outer);
                tr.AddNewlyCreatedDBObject(outer, true);

                btr.AppendEntity(inner);
                tr.AddNewlyCreatedDBObject(inner, true);

                tr.Commit();
            }
        }

        public DBObjectCollection Build(CHModel s)
        {
            double R = s.OutsideDiameter / 2.0;
            double t = s.ThicknessDesignation;

            var col = new DBObjectCollection();

            var outer = new Circle(Point3d.Origin, Vector3d.ZAxis, R);
            var inner = new Circle(Point3d.Origin, Vector3d.ZAxis, R - t);

            col.Add(outer);
            col.Add(inner);

            return col;
        }
    }
}
