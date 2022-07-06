namespace gentex
{
    class Program
    {
        private string inputFile, outputFile;
        private ShapeFactory factory;
        private HashSet<Task<string>> tasks;

        // Pass INPUT_FILE and OUTPUT_FILE to main task
        static async Task Main(string[] args) => await new Program(args[1], args[2]).MainAsync();

        public Program(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
            factory = new ShapeFactory();
            tasks = new HashSet<Task<string>>();
        }

        public async Task MainAsync()
        {
            using (StreamReader reader = new StreamReader(inputFile))
            {
                // Read all lines from input file, register transformation tasks
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null || line == "") continue;
                    tasks.Add(Transform(line));
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                // Await each transformation and write its output
                while (tasks.Count > 0) {
                  var task = await Task.WhenAny(tasks);
                  tasks.Remove(task);
                  var output = await task;
                  await writer.WriteLineAsync(output);
                }
            }
        }

        public async Task<string> Transform(string line)
        {
            return await Task.Run(() =>
            {
                // Parse abstract shape from CSV
                var shape = factory.CreateShape(line);
                // Calculate properties and format to CSV
                var output = shape.IntoCsv();
                return output;
            });
        }
    }
}
