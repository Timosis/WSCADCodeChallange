using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

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
        /// Convert hexadecimal code to known color if it is exists
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ConvertToKnownColorName(string color)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(color.ToString());
            if (col.IsKnownColor == true)
                return col.ToKnownColor().ToString();
            else
                return color.ToString();

        }

        /// <summary>
        /// Draws the path object to the mainwindow
        /// </summary>
        /// <param name="path"></param>
        public static void DrawToMainWindow(System.Windows.Shapes.Path path)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Canvas.Children.Add(path);
        }
    }
}
