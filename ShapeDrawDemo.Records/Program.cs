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

abstract record Shape(string ParcelNumber)
{
    public abstract double Area { get; }
};

record Circle(double Radius, string ParcelNumber) : Shape(ParcelNumber)
{
    public override double Area => Radius * Radius * Math.PI;
}

record Rectangle(double Length, double Width, string ParcelNumber) : Shape(ParcelNumber)
{
    public override double Area => Length * Width;
}

record Triangle(double a, double b, double c, string ParcelNumber) : Shape(ParcelNumber)
{
    public override double Area
    {
        get
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}