using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCADCodeChallange.Model.Factory;

namespace WSCADCodeChallange.Model
{
    public class Line : IShape
    {
        public string Type { get; set; }
        public SolidColorBrush SColor { get; set; }
        private double X1 { get; set; }
        private double Y1 { get; set; }
        private double X2 { get; set; }
        private double Y2 { get; set; }
     
        public Line(dynamic shapeObject)
        {
            this.Type = shapeObject.type;
            this.SColor = Helper.ConvertArgbToColor(Convert.ToString(shapeObject.color));

            // property a seperated with ;
            string[] X1Y1Points = Regex.Split(Convert.ToString(shapeObject.a), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            // property b seperated with ;
            string[] X2Y2Points = Regex.Split(Convert.ToString(shapeObject.b), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            this.X1 = Convert.ToDouble(X1Y1Points[0]);
            this.Y1 = Convert.ToDouble(X1Y1Points[1]);

            this.X2 = Convert.ToDouble(X2Y2Points[0]);
            this.Y2 = Convert.ToDouble(X2Y2Points[1]);
        }

        public void Draw()
        {            
            System.Windows.Shapes.Line myline = new System.Windows.Shapes.Line();
            myline.X1 = X1;
            myline.Y1 = Y1;

            myline.X2 = X2;
            myline.Y2 = Y2;

            myline.Stroke = SColor;
            myline.StrokeThickness = 1;

            Helper.DrawIntoCanvas(myline);
        }
    }
}
