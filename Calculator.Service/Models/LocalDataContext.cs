namespace Calculator.Service.Models
{
    using Domain;
    using System.Data.Entity;
    using Interface;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System;

    public class LocalDataContext : DataContext, ILocalDataContext
    {
        public DbSet<CalculatorOperation> CalculatorOperations { get; set; }
        public DataContext dataContext;

        public LocalDataContext()
        {
            this.dataContext = new DataContext();
        }

        DbSet<T> ILocalDataContext.GetDbSet<T>()
        {
            return this.Set<T>();
        }

        int SaveChanges()
        {
            int ret = -1;

            try
            {
                // Commit the changes
                ret = dataContext.SaveChanges();
            }
            catch (DbEntityValidationException dbve)
            {
                foreach (var validationErrors in dbve.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Show the validation exceptions which have occurred
                        Trace.TraceError("Property: {0}, Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw;
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Exception: {0}", e.Message);
                throw;
            }

            // Return the response
            return (ret);
        }
    }
}