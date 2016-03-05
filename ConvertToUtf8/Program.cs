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
            switch (args.Length)
            {
                case 1:
                    var folder = args[0];
                    _converter.ConvertFiles(folder);
                    break;

                case 2:
                    var inputFile = args[0];
                    var outputFile = args[1];
                    _converter.ConvertFile(inputFile, outputFile);
                    break;

                default:
                    ShowUsageInfo();
                    break;
            }
        }

        private void ShowUsageInfo()
        {
            Console.WriteLine("This is ConvertToUtf8.exe");
            Console.WriteLine("Usage for single file conversion:");
            Console.WriteLine("\tConvertToUtf8.exe <input file> <output file>");
            Console.WriteLine("Usage for multiple file in-place conversion:");
            Console.WriteLine("\tConvertToUtf8.exe <folder>");
        }
    }
}