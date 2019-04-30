namespace Calculator.Service.IOCRegistry
{
    using Calculator.Service.Interface;
    using Calculator.Service.Repository;
    using Unity;
    using Unity.Lifetime;

    public static class CalculatorServiceRegistry
    {
        public static UnityContainer container = new UnityContainer();

        public static void RegisterComponents()
        {
            ///Register generic repository
            container.RegisterType(typeof(ICalculatorRepository<>), typeof(CalculatorRepository<>), new TransientLifetimeManager());
        }
    }
}