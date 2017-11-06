namespace Calculator.Definition.Entities
{
    public class CalculationResult
    {
        public decimal Result { get; set; }

        public string ResultAsString => this.Result.ToString("0.00").Replace(".00", "");
    }
}
