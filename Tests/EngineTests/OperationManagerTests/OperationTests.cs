using System;

using Calculator.Definition.Resources;
using Calculator.Engine.OperationManager;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MSTestExtensions;

using Tests.Definitions;
using Tests.Helper;

namespace Tests.EngineTests.OperationManagerTests
{
    [TestClass]
    public class OperationTests : BaseTest
    {
        [TestMethod]
        public void Calculate_ValidResult_AddOperation()
        {
            var expectedResult = 9;

            var manager = new AddOperationManager();

            var result = manager.Calculate(3, 6);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate_ValidResult_SubstractOperation()
        {
            var expectedResult = -3;

            var manager = new SubstractOperationManager();

            var result = manager.Calculate(3, 6);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate_ValidResult_DivideOperation()
        {
            var expectedResult = (decimal)0.5;

            var manager = new DivideOperationManager();

            var result = manager.Calculate(3, 6);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Calculate_Exception_IfDividedIsZero()
        {
            var manager = new DivideOperationManager();

            var exceptionMessage = ErrorMessages.InvalidDividedInput;

            var result = Assert.Throws(() => { manager.Calculate(3, 0); });

            Assert.AreEqual(exceptionMessage, result.Message);
        }

        [TestMethod]
        public void Calculate_ValidResult_MultiplyOperation()
        {
            var expectedResult = 18;

            var manager = new MultiplyOperationManager();

            var result = manager.Calculate(3, 6);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
