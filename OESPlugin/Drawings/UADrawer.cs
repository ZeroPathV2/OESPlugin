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
    public class UADrawer
    {
        public void Draw(UAModel s, Point3d pt, double angle = 0)
        {
            var db = Application.DocumentManager.MdiActiveDocument.Database;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                var pl = BuildPolyline(s);

                pl.TransformBy(Matrix3d.Rotation(angle, Vector3d.ZAxis, Point3d.Origin));
                pl.TransformBy(Matrix3d.Displacement(pt.GetAsVector()));

                btr.AppendEntity(pl);
                tr.AddNewlyCreatedDBObject(pl, true);

                tr.Commit();
            }
        }

        public Polyline BuildPolyline(UAModel s)
        {
            var parts = s.SectionDesignation.Split('x');

            double A = double.Parse(parts[0]);
            double B = double.Parse(parts[1]);
            double t = s.ThicknessDesignation;

            double rr = s.RadiusRoot;
            double rt = s.RadiusToe;

            double b = -0.4142;

            var pl = new Polyline();
            int i = 0;

            // top left
            pl.AddVertexAt(i++, new Point2d(0, A), 0, 0, 0);

            
            pl.AddVertexAt(i++, new Point2d(B , A), 0, 0, 0);

            
            pl.AddVertexAt(i++, new Point2d(B , 0), b, 0, 0);

            
            pl.AddVertexAt(i++, new Point2d(B - t, rt), 0, 0, 0);

            
            pl.AddVertexAt(i++, new Point2d(B - t, A - t - rr), -b, 0, 0);

            
            pl.AddVertexAt(i++, new Point2d(B - t - rr, A - t), 0, 0, 0);

            
            pl.AddVertexAt(i++, new Point2d(rt, A - t), b, 0, 0);

            pl.Closed = true;

            return pl;
        }
    }
}
