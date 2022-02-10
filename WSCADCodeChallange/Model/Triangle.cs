using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCADCodeChallange.Model.Factory;

namespace WSCADCodeChallange.Model
{
    public class Triangle : IShape
    {
        public string Type { get; set; }
        public SolidColorBrush SColor { get; set; }
        private bool Filled { get; set; }
        private double AX { get; set; }
        private double AY { get; set; }
        private double BX { get; set; }
        private double BY { get; set; }
        private double CX { get; set; }        
        private double CY { get; set; }


        public Triangle(dynamic c_object)
        {
            this.Type = c_object.type;
            this.SColor = Helper.ConvertArgbToColor(Convert.ToString(c_object.color));
            this.Filled = c_object.filled;

            // getting triangle's A edge coordinates with separeting ;
            string[] a_coordinates = Regex.Split(Convert.ToString(c_object.a), "; ", RegexOptions.IgnoreCase);

            // getting triangle's B edge coordinates with separeting ;
            string[] b_Coordinates = Regex.Split(Convert.ToString(c_object.b), "; ", RegexOptions.IgnoreCase);

            // getting triangle's C edge coordinates with separeting ;
            string[] c_coordinates = Regex.Split(Convert.ToString(c_object.c), "; ", RegexOptions.IgnoreCase);



            this.AX = Convert.ToDouble(a_coordinates[0]);
            this.AY = Convert.ToDouble(a_coordinates[1]);

            this.BX = Convert.ToDouble(b_Coordinates[0]);
            this.BY = Convert.ToDouble(b_Coordinates[1]);

            this.CX = Convert.ToDouble(c_coordinates[0]);
            this.CY = Convert.ToDouble(c_coordinates[1]);
        }


        public void Draw()
        {
            LineGeometry line1 = new LineGeometry();
            line1.StartPoint = new Point(this.AX, this.AY);
            line1.EndPoint = new Point(this.BX, this.BY);

            LineGeometry line2 = new LineGeometry();
            line2.StartPoint = new Point(this.BX, this.BY);
            line2.EndPoint = new Point(this.CX, this.CY);

            LineGeometry line3 = new LineGeometry();
            line3.StartPoint = new Point(this.CX, this.CY);
            line3.EndPoint = new Point(this.AX, this.AY);

            GeometryGroup geometryGroup = new GeometryGroup();
            geometryGroup.Children.Add(line1);
            geometryGroup.Children.Add(line2);
            geometryGroup.Children.Add(line3);

            Path path = new Path();
            path.Stroke = this.SColor;
            path.Data = geometryGroup;

            Helper.DrawToMainWindow(path);

            return;
        }
    }
}
