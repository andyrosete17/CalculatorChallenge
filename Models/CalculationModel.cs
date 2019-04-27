using System;

namespace CalculatorChallenge.Models
{
    public class CalculationModel
    {
        #region CTor

        public CalculationModel(string firstOperand, string secondOperand, string operation)
        {
            ValidateOperand(firstOperand);
            ValidateOperand(secondOperand);
            ValidateOperation(operation);

            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
            Result = string.Empty;
        }

        public CalculationModel(string firstOperand, string operation)
        {
            ValidateOperand(firstOperand);
            ValidateOperation(operation);

            FirstOperand = firstOperand;
            SecondOperand = string.Empty;
            Operation = operation;
            Result = string.Empty;
        }

        public CalculationModel()
        {
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            Operation = string.Empty;
            Result = string.Empty;
        }

        #endregion

        #region Properties

        public string FirstOperand { get; set; }

        public string SecondOperand { get; set; }

        public string Operation { get; set; }

        public string Result { get; private set; }

        #endregion

        #region Methods

        public void CalculateResult()
        {
            ValidateData();

            try
            {
                switch (Operation)
                {
                    case "+":
                        Result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case "-":
                        Result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case "*":
                        Result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case "/":
                        Result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case "sin":
                        Result = Math.Sin(DegreeToRadian(Convert.ToDouble(FirstOperand))).ToString();
                        break;

                    case "cos":
                        Result = Math.Cos(DegreeToRadian(Convert.ToDouble(FirstOperand))).ToString();
                        break;

                    case "tan":
                        Result = Math.Tan(DegreeToRadian(Convert.ToDouble(FirstOperand))).ToString();
                        break;
                }
            }
            catch (Exception)
            {
                Result = "Error whilst calculating";
                throw;
            }
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private void ValidateOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch (Exception)
            {
                Result = "Invalid number: " + operand;
                throw;
            }
        }

        private void ValidateOperation(string operation)
        {
            switch (operation)
            {
                case "/":
                case "*":
                case "-":
                case "+":
                case "tan":
                case "cos":
                case "sin":
                    break;
                default:
                    Result = "Unknown operation: " + operation;
                    throw new ArgumentException($"Unknown Operation: {operation} operation");
            }
        }

        private void ValidateData()
        {
            switch (Operation)
            {
                case "/":
                case "*":
                case "-":
                case "+":
                    ValidateOperand(FirstOperand);
                    ValidateOperand(SecondOperand);
                    break;
                case "tan":
                case "cos":
                case "sin":
                    ValidateOperand(FirstOperand);
                    break;
                default:
                    Result = "Unknown operation: " + Operation;
                    throw new ArgumentException($"Unknown Operation: {Operation} operation");
            }
        }
        
        #endregion
    }
}
