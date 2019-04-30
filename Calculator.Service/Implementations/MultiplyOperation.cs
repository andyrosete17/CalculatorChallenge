namespace Calculator.Service.Implementations
{
    using Calculator.Domain;
    using Calculator.Service.Common;
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;

    public class MultiplyOperation : CalculatorCommons, IMultiplyOperation
    {
        private readonly ICalculatorRepository<CalculatorOperation> repository;
        private double? firstOperand, secondOperand;
        private readonly string error;

        public MultiplyOperation(
            string firstOperand,
            string secondOperand,
            ICalculatorRepository<CalculatorOperation> repository)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
            this.secondOperand = secondOperand.ValidateOperand(ref error);
            this.repository = repository;
        }

        public CalculatorOperation Execute()
        {
            var result = new CalculatorOperation
            {
                Result = !string.IsNullOrEmpty(error) ? error : (this.firstOperand * this.secondOperand).ToString()
            };
            result = AddCalculatorResult(this.firstOperand, this.secondOperand, result.Result, "*", this.repository);

            return result;
        }
    }
}