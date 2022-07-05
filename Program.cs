namespace gentex
{
    class Program
    {
        private StreamReader reader;
        private StreamWriter writer;
        private ShapeFactory factory;
        private List<Task<string>> tasks;

        static async Task Main(string[] args) => await new Program(args[1], args[2]).MainAsync();

        public Program(string inputFile, string outputFile)
        {
            Console.WriteLine("Input File: {0}", inputFile);
            Console.WriteLine("Output File: {0}", outputFile);
            factory = new ShapeFactory();
            reader = new StreamReader(inputFile);
            writer = new StreamWriter(outputFile);
            tasks = new List<Task<string>>();
        }

        public async Task MainAsync()
        {
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line == null) break;
                tasks.Add(Transform(line));
            }
            string[] outputs = await Task.WhenAll(tasks);
            foreach (string output in outputs)
            {
                writer.WriteLine(output);
                Console.WriteLine("Output Line: {0}", output);
            }
        }

        public async Task<string> Transform(string line)
        {
            return await Task.Run(() =>
            {
                Console.WriteLine("Input Line: {0}", line);
                var shape = factory.CreateShape(line);
                var output = shape.IntoCsv();
                return output;
            });
        }
    }
}