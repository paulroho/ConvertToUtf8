using System;
using System.IO;
using System.Text;

class FileConverter
{
    static void Main(string[] args)
    {
        string inputFile = args[0];
        string outputFile = args[1];
        using (StreamReader reader = new StreamReader(inputFile, Encoding.Unicode))
        {
            using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                CopyContents(reader, writer);
            }
        }
    }

    static void CopyContents(TextReader input, TextWriter output)
    {
        char[] buffer = new char[8192];
        int len;
        while ((len = input.Read(buffer, 0, buffer.Length)) != 0)
        {
            output.Write(buffer, 0, len);
        }
    }
}