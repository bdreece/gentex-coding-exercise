public sealed class Polygon : AbstractShape
{
    private List<Coords> coords;
    private const int FIRST_X = 3;
    private const int LAST_Y = 35;
    public Polygon(string[] fields)
    {
        id = int.Parse(fields[0]);
        coords = new List<Coords>();
        for (var i = FIRST_X; i <= LAST_Y; i += 4)
        {
            if (fields[i] == "" || fields[i + 2] == "") break;
            var x = double.Parse(fields[i]);
            var y = double.Parse(fields[i + 2]);
            coords.Add(new(x, y));
        }
    }

    public override double GetArea()
    {
        var area = 0d;
        var size = coords.Count;
        for (var i = 0; i < size - 1; i++)
        {
            area += determinant(coords[i], coords[i + 1]);
        }
        area += determinant(coords[size - 1], coords[0]);
        return area / 2;
    }

    public override double GetPerimeter()
    {
        var perimeter = 0d;
        var size = coords.Count;

        for (var i = 0; i < size - 1; i++)
        {
            perimeter += euclideanDistance(coords[i], coords[i + 1]);
        }
        perimeter += determinant(coords[size - 1], coords[0]);
        return perimeter;

    }

    public override (double, double) GetCentroid()
    {
        var (xAvg, yAvg) = (0d, 0d);
        var size = coords.Count;
        foreach (var coord in coords)
        {
            xAvg += coord.X;
            yAvg += coord.Y;
        }
        return (xAvg / size, yAvg / size);
    }

    private double determinant(Coords a, Coords b)
    {
        return (a.X * b.Y) - (b.X * a.Y);
    }

    private double euclideanDistance(Coords a, Coords b)
    {
        return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
    }
}