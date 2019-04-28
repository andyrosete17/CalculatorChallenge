
namespace Calculator.Service.Helpers
{
    using Calculator.Common.Interface;
    using Calculator.Domain;
    using Calculator.Service.Interface;
    using System;

    public static class OperandHelper
    {
        /// <summary>
        /// Validate and convert operand
        /// </summary>
        /// <param name="value">value of the operand</param>
        /// <returns>Converted operand</returns>
        public static double? ValidateOperand(this string value, ref string error)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                error = $"Invalid number {value}";
                throw;
            }
        }

        /// <summary>
        /// Convert degree to radiant
        /// </summary>
        /// <param name="value">Degrees to convert</param>
        /// <returns>Radians to return</returns>
        public static double DegreeToRadian(this double value)
        {
            return Math.PI * value / 180.0;
        }

        public static bool ValidateOperation(this string value)
        {
            switch (value)
            {
                case "/":
                case "*":
                case "-":
                case "+":
                case "tan":
                case "cos":
                case "sin":
                    return true;
                default:
                    return false;
            }
        }      
    }
}