using IntelliCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace OESPlugin.Models.Drawings
{
    public class IBeamDrawer
    {
        public void Draw(IBeamModel steel, Point3d pt, double angle = 0)
        {
            var db = Application.DocumentManager.MdiActiveDocument.Database;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                var pl = BuildPolyline(steel);

                pl.TransformBy(Matrix3d.Rotation(angle, Vector3d.ZAxis, Point3d.Origin));

                pl.TransformBy(Matrix3d.Displacement(pt.GetAsVector()));

                btr.AppendEntity(pl);
                tr.AddNewlyCreatedDBObject(pl, true);

                tr.Commit();
            }
        }

        public Polyline BuildPolyline(IBeamModel s)
        {
            
            double W = s.Width;
            double tw = s.WebThickness;
            double tf = s.FlangeThickness;
            double r = s.RootRadius;

            double D = 2 * tf + s.DepthBetweenFillets + 2 * r;

            double halfB = W / 2.0;
            double halfD = D / 2.0;
            double halfTw = tw / 2.0;

            double b = Math.Tan(Math.PI / 8.0); // 0.4142

            var pl = new Polyline();
            int i = 0;

         
            pl.AddVertexAt(i++, new Point2d(halfB, halfD), 0, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-halfB, halfD), 0, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-halfB, halfD - tf), 0, 0, 0);

         
            pl.AddVertexAt(i++, new Point2d(-halfTw - r, halfD - tf), -b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-halfTw, halfD - tf - r), 0, 0, 0);

      
            pl.AddVertexAt(i++, new Point2d(-halfTw, -halfD + tf + r), 0, 0, 0);

        
            pl.AddVertexAt(i++, new Point2d(-halfTw, -halfD + tf + r), -b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-halfTw - r, -halfD + tf), 0, 0, 0);

         
            pl.AddVertexAt(i++, new Point2d(-halfB, -halfD + tf), 0, 0, 0);
            pl.AddVertexAt(i++, new Point2d(-halfB, -halfD), 0, 0, 0);
            pl.AddVertexAt(i++, new Point2d(halfB, -halfD), 0, 0, 0);
            pl.AddVertexAt(i++, new Point2d(halfB, -halfD + tf), 0, 0, 0);

         
            pl.AddVertexAt(i++, new Point2d(halfTw + r, -halfD + tf), -b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(halfTw, -halfD + tf + r), 0, 0, 0);

         
            pl.AddVertexAt(i++, new Point2d(halfTw, halfD - tf - r), 0, 0, 0);

          
            pl.AddVertexAt(i++, new Point2d(halfTw, halfD - tf - r), -b, 0, 0);
            pl.AddVertexAt(i++, new Point2d(halfTw + r, halfD - tf), 0, 0, 0);

          
            pl.AddVertexAt(i++, new Point2d(halfB, halfD - tf), 0, 0, 0);

            pl.Closed = true;
           
            return pl;
        }
    }
}
