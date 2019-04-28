using Calculator.Service.Interface;
using Calculator.Service.Repository;
using Unity;

namespace Calculator.Service.IOCRegistry
{
    public static class CalculatorServiceRegistry
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            ///Register generic repository
            container.RegisterType(typeof(ICalculatorRepository<>), typeof(CalculatorRepository<>));

        }
    }
}