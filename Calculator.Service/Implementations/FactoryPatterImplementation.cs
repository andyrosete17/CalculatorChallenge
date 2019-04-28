namespace Calculator.Service.Implementations
{
    using Calculator.Service.Interface;
    using System;

    public class FactoryPatterImplementation
    {
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
                case "+": return new PlusOperation(firstOperand, secondOperand);
                case "-": return new MinusOperation(firstOperand, secondOperand);
                case "*": return new MultiplyOperation(firstOperand, secondOperand);
                case "/": return new DivideOperation(firstOperand, secondOperand);
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
                case "sin": return new SineOperation(firstOperand);
                case "cos": return new CosineOperation(firstOperand);
                case "tan": return new TangentOperation(firstOperand);
                default:
                    throw new Exception("No handle error");
            }
        }
    }
}