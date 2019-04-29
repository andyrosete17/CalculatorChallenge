
namespace Calculator.Service
{
    using Calculator.Domain;
    using Calculator.Service.DTOs;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculationService
    {
        [OperationContract]
        CalculatorOperation GetData(int id);

        [OperationContract]
        IEnumerable<CalculatorOperation> GetAllData();

        [OperationContract]
        string CalculateResult(CalculateResultRequest request);
    }
}
