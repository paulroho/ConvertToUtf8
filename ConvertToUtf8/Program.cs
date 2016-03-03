using System;

namespace ConvertToUtf8
{
    public static class Program
    {
        public static void Main(params string[] args)
        {
            if (args.Length != 2)
            {
                ShowUsageInfo();
                return;
            }
            var inputFile = args[0];
            var outputFile = args[1];

            var converter = ConverterFactory();
            converter.Convert(inputFile, outputFile);
        }

        private static void ShowUsageInfo()
        {
            Console.WriteLine("This is ConvertToUtf8.exe");
            Console.WriteLine("Usage:");
            Console.WriteLine("ConvertToUtf8.exe <input file> <output file>");
        }

        public static Func<IConverter> ConverterFactory { get; set; }
    }
}