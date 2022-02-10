using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADCodeChallange.Model.Factory
{
    /// <summary>
    /// To abstract the instantiation of the correct Shape object at runtime, 
    /// we created a ShapeFactory class who’s responsibility is to resolve which concrete class is required to be instantiated
    /// </summary>
    public interface IShapeFactory
    {
        IShape GetShape(dynamic type);
    }
}
