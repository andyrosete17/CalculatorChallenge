﻿namespace Calculator.Service.Implementations
{
    using Calculator.Domain;
    using Calculator.Service.Common;
    using Calculator.Service.Helpers;
    using Calculator.Service.Interface;
    using System;

    public class TangentOperation : ITangentOperation
    {
        private readonly ICalculatorRepository<CalculatorOperation> repository;
        double? firstOperand;
        string error;

        public TangentOperation(
            string firstOperand,
            ICalculatorRepository<CalculatorOperation> repository)
        {
            this.firstOperand = firstOperand.ValidateOperand(ref error);
            this.repository = repository;
        }

        public string Execute()
        {
            var calculatorCommons = new CalculatorCommons();

            var result = !string.IsNullOrEmpty(error) ? error : Math.Tan(this.firstOperand.Value.DegreeToRadian()).ToString();
            calculatorCommons.AddCalculatorResult(this.firstOperand, null, result, "tan", this.repository);

            return result;
        }
    }
}