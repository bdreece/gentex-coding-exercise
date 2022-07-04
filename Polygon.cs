public class Polygon : Shape
{
    public Polygon(string[] fields)
    {
        id = int.Parse(fields[0]);
    }

    public override double GetArea()
    {
        return 0f;
    }

    public override double GetPerimeter()
    {
        return 0f;
    }

    public override (double, double) GetCentroid()
    {
        return (0f, 0f);
    }
}