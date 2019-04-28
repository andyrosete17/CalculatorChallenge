﻿namespace Calculator.Service.Interface
{
    using System;
    using System.Collections.Generic;

    public interface ICalculatorRepository<TEntity>
         where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Create(Action<TEntity> setupProperty);
    }
}