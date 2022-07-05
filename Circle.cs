namespace gentex
{
    public sealed class Circle : BasicShape
    {
        private double radius;

        public Circle(string[] fields)
        {
            id = int.Parse(fields[0]);
            centerX = double.Parse(fields[3]);
            centerY = double.Parse(fields[5]);
            radius = double.Parse(fields[7]);
        }

        /// <summary> Calculates the area of the circle </summary>
        /// <returns> The area of the circle </returns>
        public override double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        /// <summary> Calculates the perimeter of the circle </summary>
        /// <returns> The perimeter of the circle </returns>
        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}
