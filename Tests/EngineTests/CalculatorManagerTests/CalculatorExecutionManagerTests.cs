using System;

using Calculator.Definition.Entities;
using Calculator.Engine.CalculatorManager;
using Calculator.Engine.FileParserManager;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tests.Definitions;
using Tests.Helper;

namespace Tests.EngineTests.CalculatorManagerTests
{
    [TestClass]
    public class CalculatorExecutionManagerTests
    {
        private readonly ICalculatorExecutionManager calculatorExecutiveManager;

        public CalculatorExecutionManagerTests()
        {
            calculatorExecutiveManager = new CalculatorExecutionManager
            {
                FileParserExecutionManager = new FileParserExecutionManager()
            };
        }

        [TestMethod]
        public void Process_ValidResult_IfFileIsValid()
        {
            var expectedResult = 15;

            var stream = FileHelper.GetTestFileStream(TestFiles.ValidTest);

            var result = calculatorExecutiveManager.Process(new File { Name = TestFiles.ValidTest, Stream = stream });

            Assert.AreEqual(expectedResult, result.Result);
        }
    }
}
