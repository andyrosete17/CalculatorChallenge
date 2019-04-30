namespace Calculator.Service.Implementations
{
    using Calculator.Domain;
    using Calculator.Service.Common;
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;
    using System;

    public class SineOperation : ISineOperation
    {
        private readonly ICalculatorRepository<CalculatorOperation> repository;
        private double? firstOperand;
        private readonly string error;

        public SineOperation(
            string firstOperand,
            ICalculatorRepository<CalculatorOperation> repository)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
            this.repository = repository;
        }

        public CalculatorOperation Execute()
        {
            var calculatorCommons = new CalculatorCommons();
            var result = new CalculatorOperation
            {
                Result = !string.IsNullOrEmpty(error) ? error : Math.Sin(this.firstOperand.Value.DegreeToRadian()).ToString()
            };
            calculatorCommons.AddCalculatorResult(this.firstOperand, null, result.Result, "sin", this.repository);

            return result;
        }
    }
}