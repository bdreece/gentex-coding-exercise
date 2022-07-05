namespace gentex
{
    public sealed class ShapeFactory
    {
        public AbstractShape CreateShape(string record)
        {
            var fields = record.Split(',');
            var shapeType = fields[1];
            switch (shapeType)
            {
                case "Circle":
                    return new Circle(fields);
                case "Ellipse":
                    return new Ellipse(fields);
                case "Square":
                    return new Square(fields);
                case "Equilateral Triangle":
                    return new Triangle(fields);
                default:
                    return new Polygon(fields);
            }
        }
    }
}