using Calculator.Definition.Entities;
using Calculator.Engine.FileParserManager;
using Calculator.Engine.OperationManager;

using Ninject;

namespace Calculator.Engine.CalculatorManager
{
    public class CalculatorExecutionManager : ICalculatorExecutionManager
    {
        [Inject]
        public IFileParserExecutionManager FileParserExecutionManager { get; set; }

        public CalculationResult Process(File file)
        {
            //file parser manager is responsible to parse file and return workable data
            var calculationItemsResult = FileParserExecutionManager.Process(file);

            var applyNumber = calculationItemsResult.InitialNumber;

            //validated ready to use instructions
            foreach (var calculationItem in calculationItemsResult.Instructions)
            {
                // although there are simple math operations, it is good practice to separate operations
                // rather then doing it with in if else statements
                // this will help a lot if we need to extend operations or/and change something 
                var operationManager = OperationFactory.Create(calculationItem.InstructionType);

                applyNumber = operationManager.Calculate(applyNumber, calculationItem.Number);
            }

            var result = new CalculationResult
            {
                Result = applyNumber
            };

            return result;
        }
    }
}
