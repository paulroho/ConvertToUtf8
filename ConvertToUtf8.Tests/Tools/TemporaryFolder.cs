using System;
using System.IO;

namespace ConvertToUtf8.Tests.Tools
{
    public class TemporaryFolder : IDisposable
    {
        public TemporaryFolder()
        {
            var name = Guid.NewGuid().ToString();
            var tempPath = System.IO.Path.GetTempPath();
            Path = System.IO.Path.Combine(tempPath, name);
            Directory.CreateDirectory(Path);
        }

        public string Path { get; }

        public TemporaryFile CreateTemporaryFile(bool createFile = true)
        {
            return new TemporaryFile(Path, createFile);
        }

        public void Dispose()
        {
            if (Directory.Exists(Path))
            {
                Directory.Delete(Path, recursive: true);
            }
        }
    }
}