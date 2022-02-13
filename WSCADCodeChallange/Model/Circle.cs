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
    /// <summary>
    /// Circle class that derived from Shape interface 
    /// </summary>
    internal class Circle : IShape
    {
        public string Type { get; set; }
        public SolidColorBrush SColor { get; set; }
        private double Radius { get; set; }
        private string Center { get; set; }
        private bool Filled { get; set; }
        private double CenterX { get; set; }
        private double CenterY { get; set; }

        /// <summary>
        /// Constructor for Circle
        /// </summary>
        /// <param name="c_object"></param>
        public Circle(dynamic c_object)
        {
            this.Type = c_object.type;
            this.SColor = Helper.ConvertArgbToColor(Convert.ToString(c_object.color));
            this.Radius = c_object.radius;
            this.Center = c_object.center;
            this.Filled = c_object.filled;

            string[] coordinates = Regex.Split(Convert.ToString(c_object.center), ";" ,RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500));

            this.CenterX = Convert.ToDouble(coordinates[0]);
            this.CenterY = Convert.ToDouble(coordinates[1]);

        }

        /// <summary>
        /// Drawing circle method
        /// </summary>
        public void Draw()
        {
            EllipseGeometry ellipse = new EllipseGeometry();

            ellipse.Center = new Point(this.CenterX, this.CenterY);
            ellipse.RadiusX = this.Radius;
            ellipse.RadiusY = this.Radius;
           
            Path path = new Path();
            path.Stroke = this.SColor;
            path.StrokeThickness = 1;

            path.Fill = this.Filled == true ? this.SColor : new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            path.Data = ellipse;
            Helper.DrawToMainWindow(path);
        }
    }
}
