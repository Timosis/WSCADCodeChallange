using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADCodeChallange.Model.Factory
{
    /// <summary>
    ///  ShapeFactory only resolves which concrete class needs to be instantiated but should ask the built-in service container of 
    ///  to get the instance and resolve its dependencies.
    ///  This is because we want to rely on IoC container to resolve our dependencies and don’t want to make changes
    ///  in out factory every single time a new dependency is introduced in either of Cube or Sphere classes.
    ///  This further decouples the code and makes it easier to manage.
    /// </summary>
    public class ShapeFactory : IShapeFactory
    {
        public IShape GetShape(dynamic currentShape)
        {
            IShape shape = null;

            if (currentShape.type == "circle")
            {
                IShape circle = new Circle(currentShape);
                return circle;
            }
            else if (currentShape.type == "line")
            {
                IShape line = new Line(currentShape);
                return line;
            }
            else if (currentShape.type == "triangle")
            {
                IShape triangle = new Triangle(currentShape);
                return triangle;
            }


            return shape;           
        }
    }
}
