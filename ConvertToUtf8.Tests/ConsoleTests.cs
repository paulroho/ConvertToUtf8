using ConvertToUtf8.Tests.Tools;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConvertToUtf8.Tests
{
    [TestClass]
    public class ConsoleTests
    {
        private Program _program;
        private ConsoleMocker _console;
        private Mock<IConverter> _converterMock;

        [TestInitialize]
        public void SetupMocks()
        {
            _converterMock = new Mock<IConverter>();
            _program = new Program(_converterMock.Object);
            _console = new ConsoleMocker();
        }

        [TestCleanup]
        public void ShutdownMocks()
        {
            _console.Dispose();
        }

        [TestMethod]
        public void CallingWithNoArgumentShowsUsageInfo()
        {
            // Act
            _program.Main();

            _console.Content.Should().Contain("ConvertToUtf8.exe");
            _console.Content.Should().Contain("Usage");
            _console.Content.Should().Contain("input file");
            _console.Content.Should().Contain("output file");
        }

        [TestMethod]
        public void CallingWithTwoArgumentsPassesThemCorrectlyToConverter()
        {
            // Act
            _program.Main("C:\\FileIn.txt", "C:\\FileOut.txt");

            _converterMock.Verify(cvtr => cvtr.Convert("C:\\FileIn.txt", "C:\\FileOut.txt"));
        }
    }
}
