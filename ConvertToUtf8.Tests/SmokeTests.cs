using ConvertToUtf8.Tests.Tools;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertToUtf8.Tests
{
    [TestClass]
    public class SmokeTests
    {
        [TestMethod]
        public void CalledWithInputAndOutputFile_CreatesTheOutputFile()
        {
            using (var inputFile = new TemporaryFile())
            using (var outputFile = new TemporaryFile(createFile: false))
            {
                // Act
                Program.Main(inputFile.FullPath, outputFile.FullPath);

                outputFile.FullPath.Should().BeTheNameOfAnExistingFile("the output file should have been created");
            }
        }
    }
}