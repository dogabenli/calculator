using System;

using Calculator.Definition.Enums;
using Calculator.Definition.Resources;
using Calculator.Engine.OperationManager;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MSTestExtensions;

namespace Tests.EngineTests.OperationManagerTests
{
    [TestClass]
    public class OperationFactoryTests : BaseTest
    {
        [TestMethod]
        public void Create_Exception_IfThereIsUnknownOperation()
        {
            var exceptionMessage = ErrorMessages.IncorrectOperation;

            var result1 = Assert.Throws(() => { OperationFactory.Create(InstructionType.Undefined); });

            Assert.AreEqual(exceptionMessage, result1.Message);

            var result2 = Assert.Throws(() => { OperationFactory.Create(InstructionType.Apply); });

            Assert.AreEqual(exceptionMessage, result2.Message);
        }

        [TestMethod]
        public void Create_InstancesCreated_IfInstructionTypeIsValid()
        {
            var addManager = OperationFactory.Create(InstructionType.Add);

            Assert.IsInstanceOfType(addManager, typeof(AddOperationManager));

            var divideManager = OperationFactory.Create(InstructionType.Divide);

            Assert.IsInstanceOfType(divideManager, typeof(DivideOperationManager));

            var substractManager = OperationFactory.Create(InstructionType.Substract);

            Assert.IsInstanceOfType(substractManager, typeof(SubstractOperationManager));

            var multiplyManager = OperationFactory.Create(InstructionType.Multiply);

            Assert.IsInstanceOfType(multiplyManager, typeof(MultiplyOperationManager));
        }
    }
}
