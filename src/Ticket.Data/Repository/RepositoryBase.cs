using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Ticket.Domain.Exceptions;
using Ticket.Domain.Interfaces.Repository;

namespace Ticket.Data.Repository
{
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        private readonly SqlContext _context;
        

        public RepositoryBase(SqlContext context)
        {
            _context = context; 
        }

        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new AppException(ex.Message);
            }
            
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new AppException(ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new AppException(ex.Message);
            }
        }
    }
}
