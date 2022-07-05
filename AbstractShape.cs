namespace gentex
{
    public abstract class AbstractShape
    {
        protected int id { get; set; }

        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract (double, double) GetCentroid();

        /// <summary> Calculates and formats fields for output CSV record </summary>
        /// <returns> The shape's geometric properties in CSV format </returns>
        public string IntoCsv()
        {
            var area = GetArea();
            var perimeter = GetPerimeter();
            var (centroidX, centroidY) = GetCentroid();
            return String.Format("{0},Area,{1:F3},Perimeter,{2:F3},CentroidX,{3:F3},CentroidY,{4:F3},", id, area, perimeter, centroidX, centroidY);
        }
    }
}
