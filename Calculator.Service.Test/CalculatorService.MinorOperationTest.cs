namespace Calculator.Service_Test
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public sealed partial class CalculatorServiceTest
    {
        [TestMethod]
        public void CalculatorService_ExecuteMinorOperation_Success()
        {
            // Arrange
            var sut = this.CreateSut();
            double? first = double.Parse(this.calculateResultRequest.FirstOperand);
            double? second = double.Parse(this.calculateResultRequest.FirstOperand);
            this.calculateResultRequest.Operator = "-";
            this.mockRepository.Setup(x => x.Create()).Returns(this.calculatorOperation).Verifiable();
            this.mockRepository.Setup(x => x.CommitContextChanges()).Returns(1).Verifiable();

            // Act
           var response = sut.CalculateResult(calculateResultRequest);

            // Assert
            response.CalculatorId.Should().Be(this.calculatorOperation.CalculatorId);
            response.Result.Should().Be((double.Parse(this.calculatorOperation.FirstOperand) - double.Parse(this.calculatorOperation.SecondOperand)).ToString()); ;
            this.mockRepository.VerifyAll();
        }
    }
}
