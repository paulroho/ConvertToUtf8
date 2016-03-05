using System.IO;
using FluentAssertions;

namespace ConvertToUtf8.Tests.Tools
{
    public static class TemporaryFileShouldExtensions
    {
        public static TemporaryFileAssertions Should(this TemporaryFile temporaryFile)
        {
            return new TemporaryFileAssertions(temporaryFile);
        }
    }

    public class TemporaryFileAssertions
    {
        public TemporaryFileAssertions(TemporaryFile temporaryFile)
        {
            TemporaryFile = temporaryFile;
        }

        public TemporaryFile TemporaryFile { get; set; }

        public void HaveSameContentAsIn(string templateFile, string because = "")
        {
            var expectedContent = File.ReadAllBytes(templateFile);
            var actualContent = File.ReadAllBytes(TemporaryFile.FullPath);

            actualContent.Should().BeEquivalentTo(expectedContent, because);
        }
    }
}