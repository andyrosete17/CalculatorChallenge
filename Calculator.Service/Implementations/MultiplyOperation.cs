namespace Calculator.Service.Implementations
{
    using Calculator.Common.Interface;
    using Calculator.Domain;
    using Calculator.Service.Common;
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;

    public class MultiplyOperation : IMultiplyOperation
    {
        private readonly ICalculatorRepository<CalculatorOperation> repository;
        double? firstOperand, secondOperand;
        string error;

        public MultiplyOperation(
            string firstOperand,
            string secondOperand,
            ICalculatorRepository<CalculatorOperation> repository)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
            this.secondOperand = secondOperand.ValidateOperand(ref error);
            this.repository = repository;
        }

        public string Execute()
        {
            var calculatorCommons = new CalculatorCommons();

            var result = !string.IsNullOrEmpty(error) ? error : (this.firstOperand * this.secondOperand).ToString();
            calculatorCommons.AddCalculatorResult(this.firstOperand, this.secondOperand, result, "*", this.repository);

            return result;
        }
    }
}