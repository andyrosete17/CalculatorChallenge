
namespace Calculator.Service
{
    using Calculator.Domain;
    using Calculator.Service.DTOs;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface CalculationService
    {

        [OperationContract]
        CalculatorOperation GetData(int id);


        [OperationContract]
        IEnumerable<CalculatorOperation> GetAllData();

        // TODO: Add your service operations here
        [OperationContract]
        string CalculateResult(CalculateResultRequest request);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
