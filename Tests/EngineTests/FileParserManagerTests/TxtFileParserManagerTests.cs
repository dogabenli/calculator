using System;

using Calculator.Definition.Resources;
using Calculator.Engine.FileParserManager;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MSTestExtensions;

using Tests.Definitions;
using Tests.Helper;

namespace Tests.EngineTests.FileParserManagerTests
{
    [TestClass]
    public class TxtFileParserManagerTests : BaseTest
    {
        private readonly IFileParserManager fileParserManager;

        public TxtFileParserManagerTests()
        {
            fileParserManager = new TxtFileParserManager();
        }

        [TestMethod]
        public void Execute_Exception_IfFileIsEmpty()
        {
            var exceptionMessage = ErrorMessages.FileIsEmpty;

            var test = FileHelper.GetTestFileStream(TestFiles.InvalidTestFileIsEmpty);

            var result = Assert.Throws(() => { fileParserManager.Execute(test); });

            Assert.AreEqual(exceptionMessage, result.Message);
        }

        [TestMethod]
        public void Execute_Exception_IfFileHasInvalidLine()
        {
            var exceptionMessage = ErrorMessages.FileIncludesInvalidData;

            var test = FileHelper.GetTestFileStream(TestFiles.InvalidTestFileHasInvalidLine);

            var result = Assert.Throws(() => { fileParserManager.Execute(test); });

            Assert.AreEqual(exceptionMessage, result.Message);
        }

        [TestMethod]
        public void Execute_Exception_IfFileHasInvalidInstruction()
        {
            var exceptionMessage = string.Format(ErrorMessages.FileIncludesInvalidInstruction, "plus");

            var test = FileHelper.GetTestFileStream(TestFiles.InvalidTestFileHasInvalidInstruction);

            var result = Assert.Throws(() => { fileParserManager.Execute(test); });

            Assert.AreEqual(exceptionMessage, result.Message);
        }

        [TestMethod]
        public void Execute_SuccessfullyParsed_IfStreamIsValid()
        {
            try
            {
                var stream = FileHelper.GetTestFileStream(TestFiles.ValidTest);

                fileParserManager.Execute(stream);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
