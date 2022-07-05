public abstract class AbstractShape
{
    protected int id { get; set; }

    public abstract double GetArea();
    public abstract double GetPerimeter();
    public abstract (double, double) GetCentroid();

    public string IntoCsv()
    {
        var area = GetArea();
        var perimeter = GetPerimeter();
        var (centroidX, centroidY) = GetCentroid();
        return String.Format("{0},Area,{1},Perimeter,{2},CentroidX,{3},CentroidY,{4},", id, area, perimeter, centroidX, centroidY);
    }
}