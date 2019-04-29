namespace Calculator.Service.Implementations
{
    using Calculator.Domain;
    using Calculator.Service.Common;
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;
    using System;

    public class CosineOperation : ICosineOperation
    {
        private readonly ICalculatorRepository<CalculatorOperation> repository;
        double? firstOperand;
        string error;

        public CosineOperation(
            string firstOperand,
            ICalculatorRepository<CalculatorOperation> repository)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
            this.repository = repository;
        }

        public CalculatorOperation Execute()
        {
            var calculatorCommons = new CalculatorCommons();
            var result = new CalculatorOperation();

            result.Result = !string.IsNullOrEmpty(error) ? error : Math.Cos(this.firstOperand.Value.DegreeToRadian()).ToString();
            calculatorCommons.AddCalculatorResult(this.firstOperand, null, result.Result, "cos", this.repository);

            return result;
        }
    }
}