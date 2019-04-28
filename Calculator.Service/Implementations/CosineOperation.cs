namespace Calculator.Service.Implementations
{
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;
    using System;

    public class CosineOperation : ICosineOperation
    {
        double? firstOperand;
        string error;

        public CosineOperation(string firstOperand)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
        }

        public string Execute()
        {
            var result = !string.IsNullOrEmpty(error) ? error : Math.Cos(this.firstOperand.Value.DegreeToRadian()).ToString();

            return result;
        }
    }
}