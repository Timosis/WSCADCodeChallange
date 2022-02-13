using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
    internal class Triangle : IShape
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

            // following variables are splitted for getting triangle's A,B,C egde coordinates with separeting ;
            string[] a_coordinates = Regex.Split(Convert.ToString(c_object.a), "; ", RegexOptions.IgnoreCase);            
            string[] b_Coordinates = Regex.Split(Convert.ToString(c_object.b), "; ", RegexOptions.IgnoreCase);            
            string[] c_coordinates = Regex.Split(Convert.ToString(c_object.c), "; ", RegexOptions.IgnoreCase);


            // following lines shows that getting triangle edges' points and assign these to related variable
            this.AX = Convert.ToDouble(a_coordinates[0]);
            this.AY = Convert.ToDouble(a_coordinates[1]);

            this.BX = Convert.ToDouble(b_Coordinates[0]);
            this.BY = Convert.ToDouble(b_Coordinates[1]);

            this.CX = Convert.ToDouble(c_coordinates[0]);
            this.CY = Convert.ToDouble(c_coordinates[1]);
        }


        /// <summary>
        /// The method aims to drawing polygon by using points
        /// Note: Triangle also is a polygon
        /// </summary>
        public void Draw()
        {
            var polygon = new Polygon();
            polygon.Fill = SColor;
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            polygon.StrokeThickness = 1;
            var polygonPoints = new PointCollection();
            polygonPoints.Add(new Point(this.AX, this.AY));
            polygonPoints.Add(new Point(this.BX, this.BY));
            polygonPoints.Add(new Point(this.CX, this.CY));
            polygon.Points = polygonPoints;

            Helper.DrawIntoCanvas(polygon);
        }
    }
}
