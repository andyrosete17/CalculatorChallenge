namespace Calculator.Service.Interface
{
    using Calculator.Commons.Interface;
    using System.Data.Entity;

    public interface ILocalDataContext
    {
        DbSet<T> GetDbSet<T>() where T : class, IEntity;

        int SaveChanges();
    }
}