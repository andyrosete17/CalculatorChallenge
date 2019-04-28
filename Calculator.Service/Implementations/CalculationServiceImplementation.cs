namespace Calculator.Service.Implementations
{
    using Calculator.Service.DTOs;
    using Calculator.Service.Helpers;

    public class CalculationServiceImplementation
    {
        public string CalculateResult(CalculateResultRequest request)
        {
            var result = string.Empty;
            if (request.Operator.ValidateOperation())
            {
                result = $"Unknown operation: {request.Operator}";
            }
            else
            {
                var factory = new FactoryPatterImplementation();
                if (string.IsNullOrEmpty(request.SecondOperand))
                {
                    var operation = factory.GetOperation(request.Operator, request.FirstOperand);
                    result = operation.Execute();
                }
                else
                {
                    var operation = factory.GetOperation(request.Operator, request.FirstOperand, request.SecondOperand);
                    result = operation.Execute();
                }
            }

            return result;
        }
    }
}