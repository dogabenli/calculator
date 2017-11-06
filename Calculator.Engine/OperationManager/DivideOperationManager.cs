using System.Diagnostics;

using Calculator.Definition.Entities;
using Calculator.Definition.Resources;

namespace Calculator.Engine.OperationManager
{
    public class DivideOperationManager : IOperationManager
    {
        public decimal Calculate(decimal item1, decimal item2)
        {
            if (item2 == 0) throw new BusinessException(ErrorMessages.InvalidDividedInput, TraceLevel.Warning);

            return item1 / item2;
        }
    }
}
