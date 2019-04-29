
namespace Calculator.Service.Implementations
{
    using Calculator.Domain;
    using Calculator.Service.Common;
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;

    public class MinusOperation : IMinusOperation
    {
        private readonly ICalculatorRepository<CalculatorOperation> repository;
        double? firstOperand, secondOperand;
        string error;

        public MinusOperation(
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
            var calculatorCommons = new CalculatorCommons();
            var result = new CalculatorOperation();

            result.Result = !string.IsNullOrEmpty(error) ? error : (this.firstOperand - this.secondOperand).ToString();
            result= calculatorCommons.AddCalculatorResult(this.firstOperand, this.secondOperand, result.Result, "-", this.repository);

            return result;
        }
    }
}