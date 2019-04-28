namespace Calculator.Service.Models
{
    using Domain;
    using System.Data.Entity;
    using Interface;
    public class LocalDataContext : DataContext, ILocalDataContext
    {
        public DbSet<CalculatorOperation> CalculatorOperations { get; set; }

        DbSet<T> ILocalDataContext.GetDbSet<T>()
        {
            return this.Set<T>();
        }
    }
}