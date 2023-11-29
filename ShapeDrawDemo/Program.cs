var parcels = new List<Shape>
{
    new Circle(1.1, "1"),
    new Rectangle(1.2, 1.1, "2"),
    new Triangle(1.1, 2.2, 3.3, "3"),
};

double sum = 0;
parcels.ForEach(shape => sum += shape.Area);
parcels.ForEach(shape => Console.WriteLine(shape.ParcelNumber));

Console.WriteLine(sum);

abstract class Shape
{
    public Shape(string parcelNumber) => ParcelNumber = parcelNumber;
    public abstract double Area { get; }
    public string ParcelNumber { get; }
}

class Circle : Shape
{
    private readonly double _radius;

    public override double Area => _radius * _radius * Math.PI;

    public Circle(double radius, string parcelNumber) : base(parcelNumber) => _radius = radius;
}

class Rectangle : Shape
{
    private readonly double length;
    private readonly double width;

    public override double Area => length * width;

    public Rectangle(double length, double width, string parcelNumber) : base(parcelNumber)
    {
        this.length = length;
        this.width = width;
    }
}

class Triangle : Shape
{
    private readonly double a;
    private readonly double b;
    private readonly double c;

    public override double Area 
    { 
        get 
        {
            double s = (a + b + c)/2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        } 
    }

    public Triangle(double a, double b, double c, string parcelNumber) : base(parcelNumber)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
}