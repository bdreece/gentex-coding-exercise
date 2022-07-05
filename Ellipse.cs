namespace gentex
{
    public sealed class Ellipse : BasicShape
    {
        private double r1, r2, orientation;

        public Ellipse(string[] fields)
        {
            id = int.Parse(fields[0]);
            centerX = double.Parse(fields[3]);
            centerY = double.Parse(fields[5]);
            r1 = double.Parse(fields[7]);
            r2 = double.Parse(fields[9]);
            orientation = double.Parse(fields[11]);
        }

        /// <summary> Calculates the area of the ellipse </summary>
        /// <returns> The area of the ellipse </returns>
        public override double GetArea()
        {
            return Math.PI * r1 * r2;
        }

        /// <summary> Calculates the perimeter of the ellipse </summary>
        /// <returns> The perimeter of the ellipse </returns>
        /// <remarks>
        ///     This method of calculating the perimeter is accurate to
        ///     within 5% of the true value. Other potential implementations
        ///     may result in more accurate results at the cost of performance.
        /// </remarks>
        /// <see>https://www.mathsisfun.com/geometry/ellipse-perimeter.html</see>
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(r1, 2) + Math.Pow(r2, 2)) / 2);
        }
    }
}
