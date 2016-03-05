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
                ConsoleFrontend.Main(inputFile.FullPath, outputFile.FullPath);

                outputFile.FullPath.Should().BeTheNameOfAnExistingFile("the output file should have been created");
            }
        }

        [TestMethod]
        public void CalledWithFolder_ConvertsEachFileInFolderInPlace()
        {
            using (var testFolder = new TemporaryFolder())
            using (var file1 = testFolder.CreateTemporaryFile())
            using (var file2 = testFolder.CreateTemporaryFile())
            {
                file1.SetContentFromFile("SampleFiles\\SampleFile1_UCS2_LE_BOM.txt");
                file2.SetContentFromFile("SampleFiles\\SampleFile2_UCS2_LE_BOM.txt");

                // Act
                ConsoleFrontend.Main(testFolder.Path);

                file1.Should().HaveSameContentAsIn("SampleFiles\\SampleFile1_UTF8.txt");
                file2.Should().HaveSameContentAsIn("SampleFiles\\SampleFile2_UTF8.txt");
            }
        }
    }
}