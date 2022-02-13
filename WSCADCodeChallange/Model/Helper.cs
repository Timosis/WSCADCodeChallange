using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WSCADCodeChallange.Model
{
    internal class Helper
    {
        public static SolidColorBrush ConvertArgbToColor(string Argb)
        {
            string[] ArgbArray = Regex.Split(Argb, "; ",
                                RegexOptions.IgnoreCase,
                                TimeSpan.FromMilliseconds(500));
            return new SolidColorBrush(Color.FromArgb(Convert.ToByte(ArgbArray[0]), Convert.ToByte(ArgbArray[1]), Convert.ToByte(ArgbArray[2]), Convert.ToByte(ArgbArray[3])));
        }

        /// <summary>
        /// Draws the path object to the mainwindow
        /// </summary>
        /// <param name="path"></param>
        public static void DrawToMainWindow(System.Windows.Shapes.Path path)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canvas.Children.Add(path);
        }

        /// <summary>
        /// Draws the path object to the mainwindow
        /// </summary>
        /// <param name="path"></param>
        public static void DrawIntoCanvas(System.Windows.Shapes.Polygon polygon)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canvas.Children.Add(polygon);
        }

        /// <summary>
        /// Draws the ellipse object to the mainwindow
        /// </summary>
        /// <param name="ellipse"></param>
        public static void DrawIntoCanvas(System.Windows.Shapes.Ellipse ellipse)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canvas.Children.Add(ellipse);
        }

        /// <summary>
        /// Draws the line object to the mainwindow
        /// </summary>
        /// <param name="line"></param>
        public static void DrawIntoCanvas(System.Windows.Shapes.Line line)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canvas.Children.Add(line);
        }

        /// <summary>
        /// Draws the rectangle object to the mainwindow
        /// </summary>
        /// <param name="path"></param>
        public static void DrawIntoCanvas(System.Windows.Shapes.Rectangle rectangle)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canvas.Children.Add(rectangle);
        }

    }
}
