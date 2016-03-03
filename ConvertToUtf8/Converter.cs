using System.IO;
using System.Text;

namespace ConvertToUtf8
{
    public interface IConverter
    {
        void Convert(string inputFile, string outputFile);
    }

    public class Converter : IConverter
    {
        public void Convert(string inputFile, string outputFile)
        {
            using (var reader = new StreamReader(inputFile, Encoding.Unicode))
            {
                using (var writer = new StreamWriter(outputFile, false, Encoding.UTF8))
                {
                    CopyContents(reader, writer);
                }
            }
        }

        private void CopyContents(TextReader input, TextWriter output)
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