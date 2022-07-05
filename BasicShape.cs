namespace gentex
{
    public abstract class BasicShape : AbstractShape
    {
        protected double centerX { get; set; }
        protected double centerY { get; set; }

        public abstract override double GetArea();
        public abstract override double GetPerimeter();

        /// <summary> Shortcuts calculating centroid for basic shapes </summary>
        /// <remarks> 
        ///     When present, centerX and centerY comprise the centroid of the
        ///     shape, rendering the calculation of which unnecessary.
        /// </remarks>
        /// <returns> The centroid coordinates of the shape </returns>
        public sealed override (double, double) GetCentroid()
        {
            return (centerX, centerY);
        }
    }
}
