using System;
using System.Diagnostics;

using Calculator.Definition.Entities;
using Calculator.Definition.Enums;
using Calculator.Definition.Resources;

namespace Calculator.Engine.OperationManager
{
    public class OperationFactory
    {
        public static IOperationManager Create(InstructionType instructionType)
        {
            IOperationManager manager;

            switch (instructionType)
            {
                case InstructionType.Add:
                    manager = new AddOperationManager();
                    break;
                case InstructionType.Substract:
                    manager = new SubstractOperationManager();
                    break;
                case InstructionType.Divide:
                    manager = new DivideOperationManager();
                    break;
                case InstructionType.Multiply:
                    manager = new MultiplyOperationManager();
                    break;
                default:
                    throw new BusinessException(ErrorMessages.IncorrectOperation, TraceLevel.Warning);
            }

            return manager;
        }
    }
}
