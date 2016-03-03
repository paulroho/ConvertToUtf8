namespace ConvertToUtf8
{
    static class Program
    {
        static void Main(string[] args)
        {
            var inputFile = args[0];
            var outputFile = args[1];

            var converter = new Converter();
            converter.Convert(inputFile, outputFile);
        }
    }
}