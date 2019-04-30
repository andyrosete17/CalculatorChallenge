namespace Calculator.Service
{
    using Calculator.Domain;
    using Calculator.Service.DTOs;
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculationService
    {
        [OperationContract]
        CalculatorOperation GetData(int id);

        [OperationContract]
        CalculatorOperation GetDataFromGuid(Guid id);

        [OperationContract]
        IEnumerable<CalculatorOperation> GetAllData();

        [OperationContract]
        CalculatorOperation CalculateResult(CalculateResultRequest request);

        [OperationContract]
        void RemoveData(Guid id);

        [OperationContract]
        Root CalculateRoots(decimal a, decimal b, decimal c);
    }
}