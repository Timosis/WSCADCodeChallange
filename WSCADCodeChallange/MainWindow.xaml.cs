using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSCADCodeChallange.Business.File;
using WSCADCodeChallange.Business.Shape;
using WSCADCodeChallange.Model.Factory;

namespace WSCADCodeChallange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IFileBusiness fileBusiness;
        public IShapeFactory shapeFactory;

        public MainWindow(
            IFileBusiness fileBusiness,
            IShapeFactory shapeFactory
            )
        {
            InitializeComponent();            
            this.fileBusiness = fileBusiness;
            this.shapeFactory = shapeFactory;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var shapeList = await fileBusiness.GetShapeFromFile();

            foreach (var shape in shapeList)
            {
                IShape concreteShape = shapeFactory.GetShape(shape);

                DrawingShape drawObject = new DrawingShape(concreteShape);
                drawObject.DrawBusiness = new DrawingShapePoints();
                drawObject.DrawPoints();
            }
        }
    }
}
