namespace Calculator.Service.Common
{
    using Calculator.Domain;
    using Calculator.Service.Interface;

    public class CalculatorCommons
    {
        /// <summary>
        /// Build calculator operation dto
        /// </summary>
        /// <param name="firstOperand">first operand</param>
        /// <param name="secondOperand">second operand</param>
        /// <param name="result">final result</param>
        /// <param name="operation">operation</param>
        /// <param name="repository">repository</param>
        public void AddCalculatorResult(double? firstOperand, double? secondOperand, string result, string operation, ICalculatorRepository<CalculatorOperation> repository)
        {
            var calculatorOperation = repository.Create();
            calculatorOperation.FirstOperand = firstOperand.ToString();
            calculatorOperation.SecondOperand = secondOperand.ToString();
            calculatorOperation.Operation = operation;
            calculatorOperation.Result = result;
        }

    }
}