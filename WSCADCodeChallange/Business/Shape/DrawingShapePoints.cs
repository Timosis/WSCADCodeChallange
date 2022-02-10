using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCADCodeChallange.Model.Factory;

namespace WSCADCodeChallange.Business.Shape
{
    public class DrawingShapePoints : IDrawingShapeBusiness
    {
        public void DrawShapes(IShape shape)
        {
            shape.Draw();
        }
    }
}
