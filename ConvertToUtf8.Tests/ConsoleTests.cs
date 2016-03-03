using ConvertToUtf8.Tests.Tools;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConvertToUtf8.Tests
{
    [TestClass]
    public class ConsoleTests
    {
        private ConsoleMocker _console;

        [TestInitialize]
        public void MockConsole()
        {
            _console = new ConsoleMocker();
        }

        [TestCleanup]
        public void UnmockConsole()
        {
            _console.Dispose();
        }

        [TestMethod]
        public void CallingWithNoArgumentShowsUsageInfo()
        {
            // Act
            Program.Main();

            _console.Content.Should().Contain("ConvertToUtf8.exe");
            _console.Content.Should().Contain("Usage");
            _console.Content.Should().Contain("input file");
            _console.Content.Should().Contain("output file");
        }

        [TestMethod]
        public void CallingWithTwoArgumentsPassesThemCorrectlyToConverter()
        {
            var converterMock = new Mock<IConverter>();
            Program.ConverterFactory = () => converterMock.Object;

            // Act
            Program.Main("C:\\FileIn.txt", "C:\\FileOut.txt");

            converterMock.Verify(cvtr => cvtr.Convert("C:\\FileIn.txt", "C:\\FileOut.txt"));
        }
    }
}
