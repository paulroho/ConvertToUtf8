using System;

namespace ConvertToUtf8
{
    public class Program
    {
        private readonly IConverter _converter;

        public Program(IConverter converter)
        {
            _converter = converter;
        }

        public void Main(params string[] args)
        {
            if (args.Length != 2)
            {
                ShowUsageInfo();
                return;
            }
            var inputFile = args[0];
            var outputFile = args[1];

            _converter.Convert(inputFile, outputFile);
        }

        private void ShowUsageInfo()
        {
            Console.WriteLine("This is ConvertToUtf8.exe");
            Console.WriteLine("Usage:");
            Console.WriteLine("ConvertToUtf8.exe <input file> <output file>");
        }
    }
}