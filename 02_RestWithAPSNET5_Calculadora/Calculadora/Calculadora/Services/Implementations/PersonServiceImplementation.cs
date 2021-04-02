using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person {Id = id, 
                               FirstName = "Moises",
                               LasttName = "Pereira", 
                               Address = "Rua Vai e Vem  - São Paulo - SP",
                               Gender = "Male"
                              };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "FirsName " + i,
                LasttName = "LastName " + i,
                Address = "Same Address " + i,
                Gender = ((i % 2) == 0 ? "Male" : "Female")
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
