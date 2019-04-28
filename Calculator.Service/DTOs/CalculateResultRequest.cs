namespace Calculator.Service.DTOs
{
    public class CalculateResultRequest
    {
        public string Operator { get; set; }
        public string FirstOperand { get; set; }
        public string SecondOperand { get; set; }
    }
}