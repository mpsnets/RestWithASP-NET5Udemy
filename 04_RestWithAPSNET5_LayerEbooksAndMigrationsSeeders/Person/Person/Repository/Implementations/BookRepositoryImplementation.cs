using Person.Model;
using Person.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Model.Book Create(Model.Book book)
        {
            try
            {
                _context.books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        public Model.Book Update(Model.Book book)
        {
            var result = FindById(book.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = FindById(id);

            if (result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Model.Book> FindAll()
        {
            return _context.books.ToList();
        }

        public Model.Book FindById(long id)
        {
            return _context.books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public bool Exists(long id)
        {
            return _context.books.Any(p => p.Id.Equals(id));
        }

    }
}
