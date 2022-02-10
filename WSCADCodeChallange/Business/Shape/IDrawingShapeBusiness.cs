using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCADCodeChallange.Model.Factory;

namespace WSCADCodeChallange.Business.Shape
{
    public interface IDrawingShapeBusiness
    {
        void DrawShapes(IShape shapeData);
    }
}
