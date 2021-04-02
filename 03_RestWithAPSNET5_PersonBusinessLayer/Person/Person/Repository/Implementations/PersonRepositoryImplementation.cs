using Person.Model;
using Person.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Person.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {

        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public List<Model.Person> FindAll()
        {
            return _context.persons.ToList();
        }

        public Model.Person FindById(long id)
        {
            return _context.persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Model.Person Create(Model.Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Model.Person Update(Model.Person person)
        {
            if (!Exists(person.Id)) return new Model.Person();

            var result = FindById(person.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
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

        public bool Exists(long id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
}
