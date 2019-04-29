﻿namespace Calculator.Service
{
    using Calculator.Domain;
    using Calculator.Service.DTOs;
    using Calculator.Service.Implementations;
    using Calculator.Service.Interface;
    using Calculator.Service.IOCRegistry;
    using Calculator.Service.Models;
    using System;
    using System.Collections.Generic;
    using Unity;
    using Unity.Injection;
    using Unity.Resolution;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CalculationServiceImpl : ICalculationService
    {
        CalculationServiceImplementation service;
        private readonly ICalculatorRepository<CalculatorOperation> _repository;
        private LocalDataContext localDataContext;
        public CalculationServiceImpl()
        {
            localDataContext = new LocalDataContext();
            ///IOC register initialization
            CalculatorServiceRegistry.RegisterComponents();
            _repository= CalculatorServiceRegistry.container.Resolve<ICalculatorRepository<CalculatorOperation>>(new ResolverOverride[]
                                                            {
                                                                new ParameterOverride("dataContext", localDataContext)
                                                            });

            this.service= new CalculationServiceImplementation();
        }

        public CalculatorOperation CalculateResult(CalculateResultRequest request)
        {
            return this.service.CalculateResult(request, _repository);
        }

        public CalculatorOperation GetDataFromGuid(Guid id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<CalculatorOperation> GetAllData()
        {
            return _repository.GetAll();
        }

        public CalculatorOperation GetData(int id)
        {
            return _repository.Get(id);
        }
    }
}
