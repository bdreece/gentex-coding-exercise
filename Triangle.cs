public class Triangle : BasicShape
{
    private double sideLength, orientation;
    public Triangle(string[] fields)
    {
        this.id = int.Parse(fields[0]);
        this.centerX = double.Parse(fields[3]);
        this.centerY = double.Parse(fields[5]);
        this.sideLength = double.Parse(fields[7]);
        this.orientation = double.Parse(fields[9]);
    }

    public override double GetArea()
    {
        var magic = Math.Sqrt(3) / 4;
        return magic * Math.Pow(sideLength, 2);
    }

    public override double GetPerimeter()
    {
        return 3 * sideLength;
    }
}