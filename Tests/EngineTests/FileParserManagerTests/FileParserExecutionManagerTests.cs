using System;

using Calculator.Definition.Entities;
using Calculator.Definition.Resources;
using Calculator.Engine.FileParserManager;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MSTestExtensions;

using Tests.Definitions;
using Tests.Helper;

namespace Tests.EngineTests.FileParserManagerTests
{
    [TestClass]
    public class FileParserExecutionManagerTests : BaseTest
    {
        private readonly IFileParserExecutionManager fileParserExecutiveManager;

        public FileParserExecutionManagerTests()
        {
            fileParserExecutiveManager = new FileParserExecutionManager();
        }

        [TestMethod]
        public void Process_Exception_IfFileNameIsInvalid()
        {
            var exceptionMessage = ErrorMessages.FileNameIsInvalid;

            var result = Assert.Throws(() => { fileParserExecutiveManager.Process(new File()); });

            Assert.AreEqual(exceptionMessage, result.Message);
        }

        [TestMethod]
        public void Process_Exception_IfFileFormatIsNotSupported()
        {
            var exceptionMessage = ErrorMessages.FileFormatNotSupported;

            var result = Assert.Throws(() => { fileParserExecutiveManager.Process(new File { Name = "test.csv" }); });

            Assert.AreEqual(exceptionMessage, result.Message);
        }

        [TestMethod]
        public void Execute_SuccesfullyExecuted_IfFileIsValid()
        {
            try
            {
                var stream = FileHelper.GetTestFileStream(TestFiles.ValidTest);

                fileParserExecutiveManager.Process(new File { Name = TestFiles.ValidTest, Stream = stream });
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
