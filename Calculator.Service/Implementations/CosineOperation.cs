namespace Calculator.Service.Implementations
{
    using Calculator.Domain;
    using Calculator.Service.Common;
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;
    using System;

    public class CosineOperation : CalculatorCommons, ICosineOperation
    {
        private readonly ICalculatorRepository<CalculatorOperation> repository;
        private double? firstOperand;
        private readonly string error;

        public CosineOperation(
            string firstOperand,
            ICalculatorRepository<CalculatorOperation> repository)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
            this.repository = repository;
        }

        public CalculatorOperation Execute()
        {
            var result = new CalculatorOperation
            {
                Result = !string.IsNullOrEmpty(error) ? error : Math.Cos(this.firstOperand.Value.DegreeToRadian()).ToString()
            };
            AddCalculatorResult(this.firstOperand, null, result.Result, "cos", this.repository);

            return result;
        }
    }
}