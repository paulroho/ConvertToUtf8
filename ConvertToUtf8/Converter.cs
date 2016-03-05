using System;
using System.IO;
using System.Text;

namespace ConvertToUtf8
{
    public interface IConverter
    {
        void ConvertFile(string inputFile, string outputFile);
        void ConvertFiles(string folder);
    }

    public class Converter : IConverter
    {
        public void ConvertFile(string inputFile, string outputFile)
        {
            using (var reader = new StreamReader(inputFile, Encoding.Unicode))
            {
                using (var writer = new StreamWriter(outputFile, false, Encoding.UTF8))
                {
                    CopyContents(reader, writer);
                }
            }
        }

        public void ConvertFiles(string folder)
        {
            foreach (var file in Directory.EnumerateFiles(folder))
            {
                var tempTargetFile = file + ".tmptgt";
                ConvertFile(file, tempTargetFile);
                File.Copy(tempTargetFile, file, overwrite:true);
                File.Delete(tempTargetFile);
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