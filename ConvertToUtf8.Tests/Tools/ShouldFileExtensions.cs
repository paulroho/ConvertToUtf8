using System.IO;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace ConvertToUtf8.Tests.Tools
{
    public static class ShouldFileExtensions
    {
        public static void BeTheNameOfAnExistingFile(this StringAssertions assertions, string because = "")
        {
            var fileExists = File.Exists(assertions.Subject);

            fileExists.Should().BeTrue(because);
        }
    }
}