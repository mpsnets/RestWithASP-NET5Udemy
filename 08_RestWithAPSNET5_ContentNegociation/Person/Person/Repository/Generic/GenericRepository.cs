using Microsoft.EntityFrameworkCore;
using Person.Model.Base;
using Person.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T item)
        {
            var result = FindById(item.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            } else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = FindById(id);

            if (result != null)
            {
                try
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public bool Exists(long id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
}
