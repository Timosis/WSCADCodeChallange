# WSCADCodeChallange

The Project aims to draw shapes such as Triangle(Polygon), Line and Circle(Ellipse). Microsoft WPF .Net 5.0 framework was used.

Solution contains 4 folder.Business,DataFile, DataService and Model.

- Business contains our logic. The purpose of using it is to separate it from data service like n-tier architecture. So orginal data is always accessable.
- DataFile contains Json file which is written shape data.
- DataService is for getting data from file,db,api or another source. Dependcy Injection was implemented for it.
- Model folder contains our Triangle, Line, Circle classes. IShape interface are implemented to these classes for drawing shapes. 
- These classes are also contains shape properties which is read from file. 

```C#
 public interface IShape
 {
   void Draw();
 }
 
public class Triangle : IShape
{
            .
            .
            .
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
```

```C#

public class Circle : IShape
{
            .
            .
            .
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
```

I was struggled with drawing filled triangle. It took almost one night for fix it. It wasted my time. I changed my approach. Firstly, 
i was trying to draw it by using Path class but Path class doesn't support polygon. I succeed drawing fill triangle without using Path.

The second issiue was about fitting the window. I did it!If the Canvas is a child of a Viewbox, the content is automatically scaled to the Viewbox height and width.

- The Factory Pattern is a Design Pattern which defines an interface for creating an object but lets the classes that have a dependency on the interface decide which class to instantiate.
This abstracts the process of object generation so that the type of object to be instantiated can be determined at run-time by the class that want’s to instantiate the object. 
Factory Pattern is useful when there are multiple classes that implement an interface and there is a class that has a dependency on this interface.

```C#
 private async void button_Click(object sender, RoutedEventArgs e)
{
    var shapeList = await fileBusiness.GetShapeFromFile();

    foreach (var shape in shapeList)
    {
        IShape concreteShape = shapeFactory.GetShape(shape);
        .
        .
        .
    }
}

```
I hope you will be happy with this solution. :)

 #### References ####
 - https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/how-to-create-a-shape-by-using-a-pathgeometry?view=netframeworkdesktop-4.8
 - https://www.dofactory.com/net/factory-method-design-pattern
 - https://code-maze.com/strategy/
 - https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/shapes-and-basic-drawing-in-wpf-overview?view=netframeworkdesktop-4.8

