
namespace Calculator.Service.Implementations
{
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;
    using System;

    public class TangentOperation : ITangentOperation
    {
        double? firstOperand;
        string error;

        public TangentOperation(string firstOperand)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
        }

        public string Execute()
        {
            var result = !string.IsNullOrEmpty(error) ? error : Math.Tan(this.firstOperand.Value.DegreeToRadian()).ToString();

            return result;
        }
    }
}