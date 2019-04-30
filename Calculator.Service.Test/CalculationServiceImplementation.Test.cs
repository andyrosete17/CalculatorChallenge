namespace Calculator.Service_Test
{
    using Calculator.Domain;
    using Calculator.Service.DTOs;
    using Calculator.Service.Implementations;
    using Calculator.Service.Interface;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;

    [TestClass]
    public sealed class CalculationServiceImplementationTest
    {
        private Guid calculatorId = Guid.NewGuid();
        private Mock<ICalculatorRepository<CalculatorOperation>> mockRepository = new Mock<ICalculatorRepository<CalculatorOperation>>();
        private Mock<FactoryPatterImplementation> factory = new Mock<FactoryPatterImplementation>();
        private CalculateResultRequest calculateResultRequest;
        private CalculatorOperation calculatorOperation;
        private Mock<IExecuteOperation> mockOperation = new Mock<IExecuteOperation>();

        [TestInitialize]
        public void Initialize()
        {
            this.calculateResultRequest = new CalculateResultRequest
            {
                FirstOperand = "45",
                SecondOperand = "5",
                Operator = "+"
            };

            this.calculatorOperation = new CalculatorOperation
            {
                CalculatorId = this.calculatorId,
                FirstOperand = this.calculateResultRequest.FirstOperand,
                SecondOperand = this.calculateResultRequest.SecondOperand,
                Operation = this.calculateResultRequest.Operator,
                Result = "OK"
            };
        }

        [TestMethod]
        public void CalculateResult_Request_Invalid()
        {
            // Arrange
            var sut = new CalculationServiceImplementation();

            double? first = double.Parse(this.calculateResultRequest.FirstOperand);
            double? second = double.Parse(this.calculateResultRequest.FirstOperand);
            this.calculateResultRequest.Operator = "***";
            
            // Act
            var response = sut.CalculateResult(this.calculateResultRequest, this.mockRepository.Object);

            // Assert
            response.Result.Should().Be($"Unknown operation: {this.calculateResultRequest.Operator}"); ;
        }
    }
}
