namespace gentex
{
    public abstract class BasicShape : AbstractShape
    {
        protected double centerX { get; set; }
        protected double centerY { get; set; }

        public abstract override double GetArea();
        public abstract override double GetPerimeter();

        public sealed override (double, double) GetCentroid()
        {
            return (centerX, centerY);
        }
    }
}