
namespace Calculator.Service_Test
{
    using Calculator.Domain;
    using Calculator.Service;
    using Calculator.Service.Common;
    using Calculator.Service.DTOs;
    using Calculator.Service.Implementations;
    using Calculator.Service.Interface;
    using Calculator.Service.Models;
    using Calculator.TestUtilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;

    [TestClass]
    public sealed partial class CalculatorServiceTest : BaseTestHelper<CalculationServiceImpl>
    {
        private Guid calculatorId = Guid.NewGuid();
        private Mock<ICalculatorRepository<CalculatorOperation>> mockRepository = new Mock<ICalculatorRepository<CalculatorOperation>>();
        private Mock<LocalDataContext> mockDataContext = new Mock<LocalDataContext>();
        private Mock<FactoryPatterImplementation> factory = new Mock<FactoryPatterImplementation>();
        private CalculateResultRequest calculateResultRequest;
        private CalculatorOperation calculatorOperation;
        private Mock<CalculatorCommons>  calculationCommons = new Mock<CalculatorCommons>();

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

        public override CalculationServiceImpl CreateSut()
        {
            return new CalculationServiceImpl(mockRepository.Object, mockDataContext.Object);
        }
    }
}
