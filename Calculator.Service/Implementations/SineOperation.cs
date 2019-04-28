namespace Calculator.Service.Implementations
{
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;
    using System;

    public class SineOperation : ISineOperation
    {
        double? firstOperand;
        string error;

        public SineOperation(string firstOperand)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
        }

        public string Execute()
        {
            var result = !string.IsNullOrEmpty(error) ? error : Math.Sin(this.firstOperand.Value.DegreeToRadian()).ToString();

            return result;
        }
    }
}
