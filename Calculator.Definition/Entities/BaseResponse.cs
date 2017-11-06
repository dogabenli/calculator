namespace Calculator.Definition.Entities
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public object Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}
