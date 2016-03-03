using System;
using System.IO;

namespace ConvertToUtf8.Tests.Tools
{
    public class ConsoleMocker : IDisposable
    {
        private readonly StringWriter _writer;

        public ConsoleMocker()
        {
            _writer = new StringWriter();
            Console.SetOut(_writer);
        }

        public string Content => _writer.ToString();

        public void Dispose()
        {
            Console.SetOut(Console.Out);
            _writer.Dispose();
        }
    }
}