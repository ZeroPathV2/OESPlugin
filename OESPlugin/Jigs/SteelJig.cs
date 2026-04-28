using IntelliCAD.EditorInput;
using System;
using Teigha.DatabaseServices;
using Teigha.Geometry;
using Teigha.GraphicsInterface;

public class SteelJig : DrawJig
{
    private DBObjectCollection _entities;

    private Point3d _position = Point3d.Origin;
    private double _angle = 0;

    public Point3d Position => _position;
    public double Angle => _angle;

    public SteelJig(DBObjectCollection entities)
    {
        _entities = entities;
    }

    protected override SamplerStatus Sampler(JigPrompts prompts)
    {
        var opts = new JigPromptPointOptions("\nPick insertion point: ");

        var res = prompts.AcquirePoint(opts);

        if (res.Status != PromptStatus.OK)
            return SamplerStatus.Cancel;

        if (res.Value == _position)
            return SamplerStatus.NoChange;

        _position = res.Value;
        return SamplerStatus.OK;
    }

    protected override bool WorldDraw(WorldDraw draw)
    {
        var mat =
            Matrix3d.Rotation(_angle, Vector3d.ZAxis, Point3d.Origin) *
            Matrix3d.Displacement(_position.GetAsVector());

        foreach (Entity ent in _entities)
        {
            ent.TransformBy(mat);
            draw.Geometry.Draw(ent);
            ent.TransformBy(mat.Inverse());

        }

        return true;
    }
}