﻿using System;
using System.IO;

namespace ConvertToUtf8.Tests.Tools
{
    public class TemporaryFile : IDisposable
    {
        public TemporaryFile(bool createFile = true)
        {
            FullPath = Path.GetTempFileName();
            if (!createFile)
            {
                File.Delete(FullPath);
            }
        }

        public string FullPath { get; }

        public void Dispose()
        {
            EnsureDoesNotExist(FullPath);
        }

        public static void EnsureDoesNotExist(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}