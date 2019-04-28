namespace Calculator.Service
{
    using Calculator.Domain;
    using Calculator.Service.DTOs;
    using Calculator.Service.Implementations;
    using Calculator.Service.Interface;
    using Calculator.Service.IOCRegistry;
    using System.Collections.Generic;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CalculationServiceImpl : CalculationService
    {
        CalculationServiceImplementation service = new CalculationServiceImplementation();
        private readonly ICalculatorRepository<CalculatorOperation> _repository;
        public CalculationServiceImpl()
        {
            ///IOC register initialization
            CalculatorServiceRegistry.RegisterComponents();
        }

        public string CalculateResult(CalculateResultRequest request)
        {
            return service.CalculateResult(request, _repository);
        }

        public CalculatorOperation GetData(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<CalculatorOperation> GetAllData()
        {
            return _repository.GetAll();
        }
    }
}
