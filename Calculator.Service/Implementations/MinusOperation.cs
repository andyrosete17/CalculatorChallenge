
namespace Calculator.Service.Implementations
{
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;

    public class MinusOperation : IMinusOperation
    {
        double? firstOperand, secondOperand;
        string error;

        public MinusOperation(string firstOperand, string secondOperand)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
            this.secondOperand = secondOperand.ValidateOperand(ref error);
        }

        public string Execute()
        {
            var result = !string.IsNullOrEmpty(error) ? error : (this.firstOperand - this.secondOperand).ToString();

            return result;
        }
      
    }
}