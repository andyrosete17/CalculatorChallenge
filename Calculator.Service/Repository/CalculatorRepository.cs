namespace Calculator.Service.Repository
{
    using Calculator.Commons.Interface;
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

        public TEntity Get(Guid id)
        {
            return this.dbSet.Find(id);
        }

        public TEntity Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public void RemoveData(Guid id)
        {
            var entity = this.dbSet.Find(id);
            this.dbSet.Remove(entity);
        }

        public TEntity Create(Action<TEntity> setupProperty)
        {
            TEntity newEntity = new TEntity();
            setupProperty?.Invoke(newEntity);
            return newEntity;
        }

        public virtual TEntity Create()
        {
            TEntity entity = new TEntity();
            this.dbSet.Add(entity);
            return entity;
        }

        public virtual int CommitContextChanges()
        {
            return this.DataContext.SaveChanges();
        }       
    }
}