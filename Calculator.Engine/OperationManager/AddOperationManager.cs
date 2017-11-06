namespace Calculator.Engine.OperationManager
{
    public class AddOperationManager : IOperationManager
    {
        public decimal Calculate(decimal item1, decimal item2)
        {
            return item1 + item2;
        }
    }
}
