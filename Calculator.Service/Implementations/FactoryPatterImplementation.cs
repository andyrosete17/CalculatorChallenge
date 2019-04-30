namespace Calculator.Service.Implementations
{
    using Calculator.Domain;
    using Calculator.Service.Interface;
    using System;

    public class FactoryPatterImplementation
    {
        private readonly ICalculatorRepository<CalculatorOperation> _repository;

        public FactoryPatterImplementation(ICalculatorRepository<CalculatorOperation> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Factory pattern to get operation interface
        /// </summary>
        /// <param name="operation">Operation operator</param>
        /// <param name="firstOperand">First Parameter</param>
        /// <param name="secondOperand">Second Parametr</param>
        /// <returns>Operation interface</returns>
        public IExecuteOperation GetOperation(string operation, string firstOperand, string secondOperand)
        {
            switch (operation)
            {
                case "+": return new PlusOperation(firstOperand, secondOperand, this._repository);
                case "-": return new MinusOperation(firstOperand, secondOperand, this._repository);
                case "*": return new MultiplyOperation(firstOperand, secondOperand, this._repository);
                case "/": return new DivideOperation(firstOperand, secondOperand, this._repository);
                default:
                    throw new Exception("No handle error");
            }
        }

        /// <summary>
        /// Factory pattern to get operation interface
        /// </summary>
        /// <param name="operation">Operation operator</param>
        /// <param name="firstOperand">First Parameter</param>
        /// <returns>Operation interface</returns>
        public IExecuteOperation GetOperation(string operation, string firstOperand)
        {
            switch (operation)
            {
                case "sin": return new SineOperation(firstOperand, this._repository);
                case "cos": return new CosineOperation(firstOperand, this._repository);
                case "tan": return new TangentOperation(firstOperand, this._repository);
                default:
                    throw new Exception("No handle error");
            }
        }
    }
}