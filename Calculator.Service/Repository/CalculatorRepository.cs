namespace Calculator.Service.Repository
{
    using Interface;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class CalculatorRepository<TEntity> : ICalculatorRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public CalculatorRepository(ILocalDataContext dataContext)
        {
            this.DataContext = dataContext;
            this.dbSet = this.DataContext.GetDbSet<TEntity>();
        }

        protected ILocalDataContext DataContext { get; private set; }
        private DbSet<TEntity> dbSet;

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet;
        }

        public TEntity Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public TEntity Create(Action<TEntity> setupProperty)
        {
            TEntity newEntity = new TEntity();
            setupProperty?.Invoke(newEntity);
            return newEntity;
        }
    }
}