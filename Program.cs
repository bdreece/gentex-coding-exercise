namespace gentex
{
    class Program
    {
        private StreamReader reader;
        private StreamWriter writer;
        private ShapeFactory factory;
        private List<Task<string>> tasks;

        // Pass INPUT_FILE and OUTPUT_FILE to main task
        static async Task Main(string[] args) => await new Program(args[1], args[2]).MainAsync();

        public Program(string inputFile, string outputFile)
        {
            reader = new StreamReader(inputFile);
            writer = new StreamWriter(outputFile);
            factory = new ShapeFactory();
            tasks = new List<Task<string>>();
        }

        public async Task MainAsync()
        {
            // Read all lines from input file
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line == null) break;
                tasks.Add(Transform(line));
            }

            // Calculate geometric properties
            string[] outputs = await Task.WhenAll(tasks);

            // Write all output lines to file.
            foreach (string output in outputs)
            {
                writer.WriteLine(output);
            }
        }

        public async Task<string> Transform(string line)
        {
            return await Task.Run(() =>
            {
                // Parse shape from CSV
                var shape = factory.CreateShape(line);
                // Calculate properties and format to CSV
                var output = shape.IntoCsv();
                return output;
            });
        }
    }
}
