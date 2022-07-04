namespace gentex
{
    using System.Collections;
    class Program
    {
        static async Task Main(string[] args) => await new Program(args[1], args[2]).MainAsync();
        private string inputFile, outputFile;
        private ShapeFactory factory;
        public Program(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
            factory = new ShapeFactory();
        }

        public async Task MainAsync()
        {
            var shapes = new ArrayList();
            using (var reader = new StreamReader(inputFile))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    shapes.Add(factory.CreateShape(line));
                }
            }

            using (var writer = new StreamWriter(outputFile))
            {
                foreach (Shape shape in shapes)
                {
                    await writer.WriteLineAsync(shape.IntoCsv());
                }
            }
        }
    }
}