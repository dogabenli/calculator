using Calculator.Definition.Entities;

namespace Calculator.Engine.CalculatorManager
{
    public interface ICalculatorExecutionManager
    {
        CalculationResult Process(File file);
    }
}
