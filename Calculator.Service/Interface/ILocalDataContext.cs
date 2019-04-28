namespace Calculator.Service.Interface
{
    using System.Data.Entity;
    public interface ILocalDataContext
    {
        DbSet<T> GetDbSet<T>() where T : class, IEntity;
    }
}