using System.IO;
using System.Text;

namespace ConvertToUtf8
{
    static class FileConverter
    {
        static void Main(string[] args)
        {
            var inputFile = args[0];
            var outputFile = args[1];
            using (var reader = new StreamReader(inputFile, Encoding.Unicode))
            {
                using (var writer = new StreamWriter(outputFile, false, Encoding.UTF8))
                {
                    CopyContents(reader, writer);
                }
            }
        }

        static void CopyContents(TextReader input, TextWriter output)
        {
            var buffer = new char[8192];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}