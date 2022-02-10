using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCADCodeChallange.Model.Factory;

namespace WSCADCodeChallange.Business.Shape
{
    public class DrawingShape
    {
        public IDrawingShapeBusiness DrawBusiness { get; set; }
        private IShape ShapeData { get; set; }
        public DrawingShape(IShape _shape)
        {
            ShapeData = _shape;
        }

        public void DrawPoints()
        {
            DrawBusiness.DrawShapes(ShapeData);
        }
    }
}
