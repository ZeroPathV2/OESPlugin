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
    public class RHSDrawer
    {
        public void Draw(RHModel steel, Point3d pt, double angle = 0)
        {
            var db = Application.DocumentManager.MdiActiveDocument.Database;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                var outer = BuildOuter(steel);
                var inner = BuildInner(steel);

                Transform(outer, pt, angle);
                Transform(inner, pt, angle);

                btr.AppendEntity(outer);
                tr.AddNewlyCreatedDBObject(outer, true);

                btr.AppendEntity(inner);
                tr.AddNewlyCreatedDBObject(inner, true);

                tr.Commit();
            }
        }

        private void Transform(Entity e, Point3d pt, double angle)
        {
            e.TransformBy(Matrix3d.Rotation(angle, Vector3d.ZAxis, Point3d.Origin));
            e.TransformBy(Matrix3d.Displacement(pt.GetAsVector()));
        }

        public DBObjectCollection Build(RHModel s)
        {
            var col = new DBObjectCollection();

            col.Add(BuildOuter(s));
            col.Add(BuildInner(s));

            return col;
        }

        private Polyline BuildOuter(RHModel s)
        {
            double H = s.Height;
            double W = s.Width;
            double r = s.ThicknessDesignation;

            double hH = H / 2.0;
            double hW = W / 2.0;

            double b = 0.4142;

            var pl = new Polyline();
            int i = 0;

          
            pl.AddVertexAt(i++, new Point2d(hW - r, hH), 0, 0, 0);

         
            pl.AddVertexAt(i++, new Point2d(-hW + r, hH), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-hW, hH - r), 0, 0, 0);

         
            pl.AddVertexAt(i++, new Point2d(-hW, -hH + r), 0, 0, 0);

        
            pl.AddVertexAt(i++, new Point2d(-hW, -hH + r), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-hW + r, -hH), 0, 0, 0);

       
            pl.AddVertexAt(i++, new Point2d(hW - r, -hH), 0, 0, 0);

          
            pl.AddVertexAt(i++, new Point2d(hW - r, -hH), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(hW, -hH + r), 0, 0, 0);

           
            pl.AddVertexAt(i++, new Point2d(hW, hH - r), 0, 0, 0);

        
            pl.AddVertexAt(i++, new Point2d(hW, hH - r), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(hW - r, hH), 0, 0, 0);

            pl.Closed = true;
            return pl;
        }

        private Polyline BuildInner(RHModel s)
        {
            double H = s.Height - 2 * s.ThicknessDesignation;
            double W = s.Width - 2 * s.ThicknessDesignation;

            double r = s.ThicknessDesignation * 0.5;

            double hH = H / 2.0;
            double hW = W / 2.0;

            double b = 0.4142;

            var pl = new Polyline();
            int i = 0;

         
            pl.AddVertexAt(i++, new Point2d(hW - r, hH), 0, 0, 0);

        
            pl.AddVertexAt(i++, new Point2d(-hW + r, hH), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-hW, hH - r), 0, 0, 0);

          
            pl.AddVertexAt(i++, new Point2d(-hW, -hH + r), 0, 0, 0);

           
            pl.AddVertexAt(i++, new Point2d(-hW, -hH + r), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-hW + r, -hH), 0, 0, 0);

          
            pl.AddVertexAt(i++, new Point2d(hW - r, -hH), 0, 0, 0);

           
            pl.AddVertexAt(i++, new Point2d(hW - r, -hH), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(hW, -hH + r), 0, 0, 0);

            pl.AddVertexAt(i++, new Point2d(hW, hH - r), 0, 0, 0);

            
            pl.AddVertexAt(i++, new Point2d(hW, hH - r), b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(hW - r, hH), 0, 0, 0);

            pl.Closed = true;
            return pl;
        }
    }
}
