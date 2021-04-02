using Calculator.Model;
using Calculator.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {
            return _context.persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
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

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

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

        private bool Exists(long id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
}
