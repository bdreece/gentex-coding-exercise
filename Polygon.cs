namespace gentex
{
    public sealed class Polygon : AbstractShape
    {
        private List<Coords> coords;

        // CSV Schema: ID, SHAPE_TYPE, X0, xxx.xx, Y0, ... , X9, xxx.xx, Y9, xxx.xx,
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

        /// <summary> Calculates the area of the polygon </summary>
        /// <remarks>
        ///     This implementation utilizes the shoelace formula for
        ///     calculating the area of irregular polygons.
        /// </remarks>
        /// <returns> The area of the polygon </returns>
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

        /// <summary> Calculates the perimeter of the polygon </summary>
        /// <remarks>
        ///     This implementation sums the Euclidean distances between
        ///     each of the vertices, including from the last vertex
        ///     to the first.
        /// </remarks>
        /// <returns> The perimeter of the polygon </returns>
        public override double GetPerimeter()
        {
            var perimeter = 0d;
            var size = coords.Count;

            for (var i = 0; i < size - 1; i++)
            {
                perimeter += euclideanDistance(coords[i], coords[i + 1]);
            }
            perimeter += euclideanDistance(coords[size - 1], coords[0]);
            return perimeter;

        }

        /// <summary> Calculates the centroid of the polygon </summary>
        /// <remarks>
        ///     This implementation calculates the mean X and Y coordinates
        ///     of every vertex in the polygon.
        /// </remarks>
        /// <returns> The centroid of the polygon </returns>
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
}
