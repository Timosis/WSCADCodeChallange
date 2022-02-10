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
        public SolidColorBrush Color { get; set; }
        private double X1 { get; set; }
        private double Y1 { get; set; }
        private double X2 { get; set; }
        private double Y2 { get; set; }

        public Line(dynamic shapeObject)
        {
            this.Type = shapeObject.type;
            this.Color = Helper.ConvertArgbToColor(Convert.ToString(shapeObject.color));

            // property a seperated with ;
            string[] X1Y1Array = Regex.Split(Convert.ToString(shapeObject.a), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            // property b seperated with ;
            string[] X2Y2Array = Regex.Split(Convert.ToString(shapeObject.b), "; ",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(500));

            this.X1 = Convert.ToDouble(X1Y1Array[0]);
            this.Y1 = Convert.ToDouble(X1Y1Array[1]);

            this.X2 = Convert.ToDouble(X2Y2Array[0]);
            this.Y2 = Convert.ToDouble(X2Y2Array[1]);
        }

        public void Draw()
        {
            LineGeometry line = new LineGeometry();
            line.StartPoint = new Point(this.X1, this.Y1);
            line.EndPoint = new Point(this.X2, this.Y2);

            Path path = new Path();
            path.Stroke = this.Color;

            path.Data = line;

            Helper.DrawToMainWindow(path);

            return;
        }
    }
}
