using System;

namespace CalculatorChallenge.Models
{
    public class CalculationModel
    {
        #region CTor
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

        public string Result { get; set; }

        public Guid CalculatorId { get; set; }
        #endregion
    }
}