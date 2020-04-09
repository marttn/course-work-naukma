using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace coursework.Repositories
{
    public abstract class Repository : IDisposable
    {

        private HrisDbContext _context;
        protected HrisDbContext Context => _context ?? (_context = new HrisDbContext());
        protected Database Db => Context.Database;

        protected DbRawSqlQuery<T> Query<T>(string sql, params object[] parameters)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            return Db.SqlQuery<T>(sql, parameters);
        }

        protected void ExecuteNonQuery(string sql, params object[] parameters)
        {
            Db.ExecuteSqlCommand(sql, parameters);
        }

        
        public void Dispose()
        {
            ((IDisposable)_context)?.Dispose();
        }

        protected void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}