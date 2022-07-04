public class Square : BasicShape
{
    private double sideLength, orientation;
    public Square(string[] fields)
    {
        id = int.Parse(fields[0]);
        centerX = double.Parse(fields[3]);
        centerY = double.Parse(fields[5]);
        sideLength = double.Parse(fields[7]);
        orientation = double.Parse(fields[9]);
    }

    public override double GetArea()
    {
        return Math.Pow(sideLength, 2);
    }

    public override double GetPerimeter()
    {
        return sideLength * 4;
    }
}